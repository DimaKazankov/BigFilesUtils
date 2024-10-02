using System.IO.MemoryMappedFiles;
using System.Text;
using FileAlgorithms.Sorter.Algorithms.Memory;

namespace FileAlgorithms.Sorter.Algorithms.IO;

public class ChunkedMemoryMappedFileSorter(ISorter sorter) : IFileSorter
{
    private const int ChunkSize = 100 * 1024 * 1024; // 100 MB chunks
    private const int BufferSize = 4096; // 4 KB buffer for reading

    public async Task SortFileAsync(string inputFilePath, string outputFilePath)
    {
        var fileSize = new FileInfo(inputFilePath).Length;
        var chunkCount = (int)Math.Ceiling((double)fileSize / ChunkSize);

        var sortedChunks = new List<string>();

        for (var i = 0; i < chunkCount; i++)
        {
            var chunkStart = (long)i * ChunkSize;
            var chunkLength = Math.Min(ChunkSize, fileSize - chunkStart);

            using var mmf = MemoryMappedFile.CreateFromFile(inputFilePath, FileMode.Open, null, 0, MemoryMappedFileAccess.Read);
            using var accessor = mmf.CreateViewAccessor(chunkStart, chunkLength, MemoryMappedFileAccess.Read);

            var lines = ReadLines(accessor, chunkLength).ToList();
            sorter.Sort(lines);

            var tempFile = Path.GetTempFileName();
            await File.WriteAllLinesAsync(tempFile, lines);
            sortedChunks.Add(tempFile);
        }

        await MergeSortedChunksAsync(sortedChunks, outputFilePath);

        // Clean up temporary files
        foreach (var chunk in sortedChunks)
        {
            File.Delete(chunk);
        }
    }

    private IEnumerable<string> ReadLines(MemoryMappedViewAccessor accessor, long length)
    {
        var buffer = new byte[BufferSize];
        var stringBuilder = new StringBuilder();
        long position = 0;

        while (position < length)
        {
            var bytesRead = Math.Min((int)(length - position), buffer.Length);
            accessor.ReadArray(position, buffer, 0, bytesRead);

            for (var i = 0; i < bytesRead; i++)
            {
                if (buffer[i] == '\n')
                {
                    yield return stringBuilder.ToString();
                    stringBuilder.Clear();
                }
                else if (buffer[i] != '\r')
                {
                    stringBuilder.Append((char)buffer[i]);
                }
            }

            position += bytesRead;
        }

        if (stringBuilder.Length > 0)
        {
            yield return stringBuilder.ToString();
        }
    }

    private async Task MergeSortedChunksAsync(List<string> chunkFiles, string outputFilePath)
    {
        const int K = 8; // Number of chunks to merge at once

        while (chunkFiles.Count > 1)
        {
            var newChunks = new List<string>();

            for (var i = 0; i < chunkFiles.Count; i += K)
            {
                var chunksToMerge = chunkFiles.Skip(i).Take(K).ToList();
                var mergedChunk = await MergeKChunksAsync(chunksToMerge);
                newChunks.Add(mergedChunk);
            }

            foreach (var chunk in chunkFiles)
            {
                File.Delete(chunk);
            }

            chunkFiles = newChunks;
        }

        File.Move(chunkFiles[0], outputFilePath, true);
    }

    private async Task<string> MergeKChunksAsync(List<string> chunksToMerge)
    {
        var outputChunk = Path.GetTempFileName();
        await using var outputWriter = new StreamWriter(outputChunk);

        var readers = chunksToMerge.Select(f => new StreamReader(f)).ToList();
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

        foreach (var reader in readers)
        {
            reader.Dispose();
        }

        return outputChunk;
    }
}