using System.Collections.Concurrent;
using System.Text;

namespace BigFilesUtils.Domain;

public class FileGeneratorParallel
{
    private static readonly string[] SampleStrings =
    [
        "Apple", "Banana is yellow", "Cherry is the best", "Something something something"
    ];

    public void GenerateFile(string filePath, long fileSizeInBytes)
    {
        var totalBytesGenerated = 0L;
        var queue = new ConcurrentQueue<string>();
        var tasks = new List<Task>();
        var cts = new CancellationTokenSource();

        // Producer tasks
        for (int i = 0; i < Environment.ProcessorCount; i++)
        {
            tasks.Add(Task.Run(() =>
            {
                var random = new Random();
                while (!cts.Token.IsCancellationRequested)
                {
                    var number = random.Next(1, 1000000);
                    var str = SampleStrings[random.Next(SampleStrings.Length)];
                    var line = $"{number}. {str}{Environment.NewLine}";

                    var byteCount = Encoding.UTF8.GetByteCount(line);
                    var newTotal = Interlocked.Add(ref totalBytesGenerated, byteCount);

                    if (newTotal > fileSizeInBytes)
                    {
                        cts.Cancel();
                        break;
                    }

                    queue.Enqueue(line);
                }
            }, cts.Token));
        }

        // Consumer task
        var consumerTask = Task.Run(() =>
        {
            using var writer = new StreamWriter(filePath, false, Encoding.UTF8, 65536);
            while (!cts.Token.IsCancellationRequested || !queue.IsEmpty)
            {
                if (queue.TryDequeue(out var line))
                {
                    writer.Write(line);
                }
            }
        }, cts.Token);

        tasks.Add(consumerTask);
        Task.WaitAll(tasks.ToArray());
    }
}