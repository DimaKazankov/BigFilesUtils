using System.Collections.Concurrent;
using System.Security.Cryptography;
using System.Text;

namespace FileAlgorithms.Generator.Algorithms;

public class FileGeneratorParallelByteChunks(string[] input) : IFileGenerator
{
    private const int ChunkSize = 10 * 1024 * 1024; // 10 MB chunks
    private const int MaxDegreeOfParallelism = 8;

    public async Task GenerateFileAsync(string filePath, long fileSizeInBytes)
    {
        var chunks = new BlockingCollection<byte[]>(boundedCapacity: MaxDegreeOfParallelism * 2);
        var remainingBytes = fileSizeInBytes;

        var producerTask = Task.Run(() =>
        {
            Parallel.For(0, (int)(fileSizeInBytes / ChunkSize) + 1,
                new ParallelOptions { MaxDegreeOfParallelism = MaxDegreeOfParallelism },
                () => new StringBuilder(),
                (_, _, sb) =>
                {
                    var chunkSize = (int)Math.Min(ChunkSize, Interlocked.Read(ref remainingBytes));
                    if (chunkSize <= 0) return sb;

                    var chunk = GenerateChunk(chunkSize);
                    chunks.Add(chunk);

                    Interlocked.Add(ref remainingBytes, -chunkSize);
                    return sb;
                }, _ => { });

            chunks.CompleteAdding();
        });

        await using var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 65536, useAsync: true);
        foreach (var chunk in chunks.GetConsumingEnumerable())
        {
            await fs.WriteAsync(chunk, 0, chunk.Length);
        }

        await producerTask;
    }

    private byte[] GenerateChunk(int chunkSize)
    {
        using var ms = new MemoryStream(chunkSize);
        using var sw = new StreamWriter(ms, Encoding.UTF8, 1024, leaveOpen: true);

        while (ms.Length < chunkSize)
        {
            var number = RandomNumberGenerator.GetInt32(1, 1000000);
            var index = RandomNumberGenerator.GetInt32(0, input.Length);
            var str = $"{number}. {input[index]}{Environment.NewLine}";
            sw.Write(str);
            sw.Flush();
        }

        sw.Flush();
        return ms.ToArray();
    }
}
