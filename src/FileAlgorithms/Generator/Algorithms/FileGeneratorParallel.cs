using System.Collections.Concurrent;
using System.Text;

namespace FileAlgorithms.Generator.Algorithms;

public class FileGeneratorParallel(string[] input) : IFileGenerator
{
    private const int ChunkSize = 10 * 1024 * 1024; // 10 MB chunks
    private const int MaxDegreeOfParallelism = 8;

    public async Task GenerateFileAsync(string filePath, long fileSizeInBytes)
    {
        var chunks = new BlockingCollection<string>();
        var remainingBytes = fileSizeInBytes;

        // Producer task
        var producerTask = Task.Run(() =>
        {
            Parallel.For(0, (int)(fileSizeInBytes / ChunkSize) + 1, new ParallelOptions { MaxDegreeOfParallelism = MaxDegreeOfParallelism }, _ =>
            {
                var chunkSize = (int)Math.Min(ChunkSize, Interlocked.Read(ref remainingBytes));
                if (chunkSize <= 0) return;

                var chunk = GenerateChunk(chunkSize);
                chunks.Add(chunk);

                Interlocked.Add(ref remainingBytes, -chunkSize);
            });

            chunks.CompleteAdding();
        });

        // Consumer task
        await using var writer = new StreamWriter(filePath, false, Encoding.UTF8, 65536);
        foreach (var chunk in chunks.GetConsumingEnumerable())
        {
            await writer.WriteAsync(chunk);
        }

        await producerTask;
    }

    private string GenerateChunk(int chunkSize)
    {
        var random = new Random();
        var sb = new StringBuilder(chunkSize);

        while (sb.Length < chunkSize)
        {
            var number = random.Next(1, 1000000);
            var str = input[random.Next(input.Length)];
            sb.Append($"{number}. {str}{Environment.NewLine}");
        }

        return sb.ToString();
    }
}