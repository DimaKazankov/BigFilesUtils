using System.Collections.Concurrent;
using System.Text;

namespace BigFilesUtils.Domain;

public class FileGeneratorParallel : IFileGenerator
{
    private static readonly string[] SampleStrings =
    [
        "Apple", "Banana is yellow", "Cherry is the best", "Something something something"
    ];

    public async Task GenerateFileAsync(string filePath, long fileSizeInBytes)
    {
        var totalBytesGenerated = 0L;
        var queue = new ConcurrentQueue<string>();
        var cts = new CancellationTokenSource();
        var producerTasks = new List<Task>();

        // Producer tasks
        for (int i = 0; i < Environment.ProcessorCount; i++)
        {
            var producerTask = Task.Run(() =>
            {
                var random = new Random();
                while (true)
                {
                    if (cts.IsCancellationRequested)
                        break;

                    var number = random.Next(1, 1000000);
                    var str = SampleStrings[random.Next(SampleStrings.Length)];
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
                // Write all lines currently in the queue
                while (queue.TryDequeue(out var line))
                {
                    await writer.WriteAsync(line);
                }

                // Check if producers have completed and queue is empty
                if (cts.IsCancellationRequested && queue.IsEmpty)
                {
                    // Wait for all producers to finish
                    await Task.WhenAll(producerTasks.ToArray());
                    // After all producers are done, write any remaining lines
                    while (queue.TryDequeue(out var line))
                    {
                        await writer.WriteAsync(line);
                    }

                    break;
                }

                // Optional: Prevent tight loop
                // Thread.Sleep(1);
            }
        });

        // Wait for both producers and consumer to complete
        await Task.WhenAll(producerTasks.ToArray());
        await consumerTask;
    }
}