using System.Text;
using FileAlgorithms.Sorter.Algorithms.Memory;

namespace FileAlgorithms.Sorter.Algorithms.IO;

public class ExternalMergeFileSorter(ISorter sorter) : IFileSorter
{
    private const int ChunkSize = 100 * 1024 * 1024; // 100 MB chunks

    public async Task SortFileAsync(string inputFilePath, string outputFilePath)
    {
        var tempDir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        Directory.CreateDirectory(tempDir);

        try
        {
            var chunkFiles = await SplitAndSortChunksAsync(inputFilePath, tempDir);
            await MergeChunksAsync(chunkFiles, outputFilePath);
        }
        finally
        {
            Directory.Delete(tempDir, true);
        }
    }

    private async Task<List<string>> SplitAndSortChunksAsync(string inputFilePath, string tempDir)
    {
        var chunkFiles = new List<string>();
        var lines = new List<string>();

        using (var reader = new StreamReader(inputFilePath))
        {
            long currentSize = 0;
            var chunkIndex = 0;

            while (await reader.ReadLineAsync() is { } line)
            {
                lines.Add(line);
                currentSize += Encoding.UTF8.GetByteCount(line) + Environment.NewLine.Length;

                if (currentSize >= ChunkSize)
                {
                    await SortAndWriteChunkAsync(lines, tempDir, chunkIndex);
                    chunkFiles.Add(Path.Combine(tempDir, $"chunk_{chunkIndex}.txt"));
                    chunkIndex++;
                    lines.Clear();
                    currentSize = 0;
                }
            }
        }

        if (lines.Count > 0)
        {
            await SortAndWriteChunkAsync(lines, tempDir, chunkFiles.Count);
            chunkFiles.Add(Path.Combine(tempDir, $"chunk_{chunkFiles.Count}.txt"));
        }

        return chunkFiles;
    }

    private async Task SortAndWriteChunkAsync(List<string> lines, string tempDir, int chunkIndex)
    {
        sorter.Sort(lines);

        var chunkPath = Path.Combine(tempDir, $"chunk_{chunkIndex}.txt");
        await File.WriteAllLinesAsync(chunkPath, lines);
    }

    private async Task MergeChunksAsync(List<string> chunkFiles, string outputFilePath)
    {
        await using var outputWriter = new StreamWriter(outputFilePath);
        var readers = chunkFiles.Select(f => new StreamReader(f)).ToList();
        var heap = new SortedDictionary<string, Queue<StreamReader>>();

        foreach (var reader in readers)
        {
            var line = await reader.ReadLineAsync();
            if (line != null)
            {
                if (!heap.ContainsKey(line))
                    heap[line] = new Queue<StreamReader>();
                heap[line].Enqueue(reader);
            }
        }

        while (heap.Count > 0)
        {
            var minLine = heap.Keys.First();
            await outputWriter.WriteLineAsync(minLine);
            var reader = heap[minLine].Dequeue();

            if (heap[minLine].Count == 0)
                heap.Remove(minLine);

            var nextLine = await reader.ReadLineAsync();
            if (nextLine != null)
            {
                if (!heap.ContainsKey(nextLine))
                    heap[nextLine] = new Queue<StreamReader>();
                heap[nextLine].Enqueue(reader);
            }
            else
            {
                reader.Dispose();
            }
        }
    }
}