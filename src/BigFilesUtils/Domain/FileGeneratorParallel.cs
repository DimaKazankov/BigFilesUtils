using System.Collections.Concurrent;
using System.Text;

namespace BigFilesUtils.Domain;

public class FileGeneratorParallel : IFileGenerator
{
    private static readonly string[] SampleStrings =
    {
        "Apple", "Banana is yellow", "Cherry is the best", "Something something something"
    };

    public async Task GenerateFileAsync(string filePath, long fileSizeInBytes)
    {
        var totalBytesGenerated = 0L;
        var queue = new BlockingCollection<string>(boundedCapacity: 1000);
        var cts = new CancellationTokenSource();

        // Producer tasks
        var producerTasks = new List<Task>();
        for (var i = 0; i < Environment.ProcessorCount; i++)
        {
            producerTasks.Add(Task.Run(() =>
            {
                var random = new Random(Guid.NewGuid().GetHashCode());
                var sb = new StringBuilder();
                while (!cts.Token.IsCancellationRequested)
                {
                    var number = random.Next(1, 1000000);
                    var str = SampleStrings[random.Next(SampleStrings.Length)];
                    var line = $"{number}. {str}{Environment.NewLine}";

                    var byteCount = Encoding.UTF8.GetByteCount(line);
                    var newTotal = Interlocked.Add(ref totalBytesGenerated, byteCount);

                    if (newTotal >= fileSizeInBytes)
                    {
                        cts.Cancel();
                        break;
                    }

                    sb.Append(line);

                    // Batch size of approximately 8 KB
                    if (sb.Length >= 8192)
                    {
                        queue.Add(sb.ToString());
                        sb.Clear();
                    }
                }

                // Add remaining lines
                if (sb.Length > 0)
                {
                    queue.Add(sb.ToString());
                }
            }, cts.Token));
        }

        // Consumer task
        var consumerTask = Task.Run(async () =>
        {
            using var writer = new StreamWriter(filePath, false, Encoding.UTF8, 65536);

            foreach (var data in queue.GetConsumingEnumerable(cts.Token))
            {
                await writer.WriteAsync(data);
            }
        }, cts.Token);

        // Wait for producers to complete
        await Task.WhenAll(producerTasks);

        // Signal completion and wait for consumer
        queue.CompleteAdding();
        await consumerTask;
    }
}