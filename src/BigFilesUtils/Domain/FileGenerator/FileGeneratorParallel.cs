using System.Collections.Concurrent;
using System.Text;

namespace BigFilesUtils.Domain.FileGenerator;

public class FileGeneratorParallel(string[] input) : IFileGenerator
{
    public async Task GenerateFileAsync(string filePath, long fileSizeInBytes)
    {
        var totalBytesGenerated = 0L;
        var queue = new ConcurrentQueue<string>();
        var cts = new CancellationTokenSource();
        var producerTasks = new List<Task>();

        // Producer tasks
        for (var i = 0; i < Environment.ProcessorCount; i++)
        {
            var producerTask = Task.Run(() =>
            {
                var random = new Random();
                while (true)
                {
                    if (cts.IsCancellationRequested)
                        break;

                    var number = random.Next(1, 1000000);
                    var str = input[random.Next(input.Length)];
                    var line = $"{number}. {str}{Environment.NewLine}";

                    var byteCount = Encoding.UTF8.GetByteCount(line);
                    var newTotal = Interlocked.Add(ref totalBytesGenerated, byteCount);

                    if (newTotal >= fileSizeInBytes)
                    {
                        // Enqueue the last line if it doesn't exceed the size
                        if (newTotal - fileSizeInBytes <= byteCount)
                            queue.Enqueue(line);

                        cts.Cancel(); // Signal cancellation
                        break;
                    }

                    queue.Enqueue(line);
                }
            });

            producerTasks.Add(producerTask);
        }

        // Consumer task
        var consumerTask = Task.Run(async () =>
        {
            await using var writer = new StreamWriter(filePath, false, Encoding.UTF8, 65536);
            while (true)
            {
                while (queue.TryDequeue(out var line)) await writer.WriteAsync(line);

                if (cts.IsCancellationRequested && queue.IsEmpty)
                {
                    await Task.WhenAll(producerTasks.ToArray());
                    while (queue.TryDequeue(out var line))
                        await writer.WriteAsync(line);

                    break;
                }
            }
        });

        await Task.WhenAll(producerTasks.ToArray());
        await consumerTask;
    }
}