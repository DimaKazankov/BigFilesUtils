using System.Text;

namespace BigFilesUtils.Domain.FileSorter;

public class KWayMergeSorter : IFileSorter
{
    private const int ChunkSize = 100 * 1024 * 1024; // 100 MB chunks
    private const int K = 8; // Number of ways for K-way merge

    public async Task SortFileAsync(string inputFilePath, string outputFilePath)
    {
        var tempDir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        Directory.CreateDirectory(tempDir);

        try
        {
            var chunkFiles = await SplitAndSortChunksAsync(inputFilePath, tempDir);
            await KWayMergeAsync(chunkFiles, outputFilePath, K);
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
        lines.Sort((a, b) =>
        {
            var compResult = string.Compare(a.Substring(a.IndexOf('.') + 2), b.Substring(b.IndexOf('.') + 2), StringComparison.Ordinal);
            if (compResult != 0) return compResult;
            return int.Parse(a.Substring(0, a.IndexOf('.'))).CompareTo(int.Parse(b.Substring(0, b.IndexOf('.'))));
        });

        var chunkPath = Path.Combine(tempDir, $"chunk_{chunkIndex}.txt");
        await File.WriteAllLinesAsync(chunkPath, lines);
    }

    private async Task KWayMergeAsync(List<string> chunkFiles, string outputFilePath, int k)
    {
        using var outputWriter = new StreamWriter(outputFilePath);
        var readers = chunkFiles.Select(f => new StreamReader(f)).ToList();
        var heap = new SortedDictionary<string, Queue<StreamReader>>();

        foreach (var reader in readers.Take(k))
        {
            var line = await reader.ReadLineAsync();
            if (line != null)
            {
                if (!heap.ContainsKey(line))
                    heap[line] = new Queue<StreamReader>();
                heap[line].Enqueue(reader);
            }
        }

        var remainingReaders = new Queue<StreamReader>(readers.Skip(k));

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
                if (remainingReaders.Count > 0)
                {
                    var newReader = remainingReaders.Dequeue();
                    var newLine = await newReader.ReadLineAsync();
                    if (newLine != null)
                    {
                        if (!heap.ContainsKey(newLine))
                            heap[newLine] = new Queue<StreamReader>();
                        heap[newLine].Enqueue(newReader);
                    }
                }
            }
        }
    }
}