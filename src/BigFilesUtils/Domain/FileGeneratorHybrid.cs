using System.Text;

namespace BigFilesUtils.Domain;

public class FileGeneratorHybrid : IFileGenerator
{
    private static readonly string[] SampleStrings =
    {
        "Apple", "Banana is yellow", "Cherry is the best", "Something something something"
    };

    public async Task GenerateFileAsync(string filePath, long fileSizeInBytes)
    {
        var bufferSize = 65536;
        var totalBytesGenerated = 0L;

        await using var writer = new StreamWriter(filePath, false, Encoding.UTF8, bufferSize);

        while (totalBytesGenerated < fileSizeInBytes)
        {
            var tasks = new Task<string>[Environment.ProcessorCount];

            // Generate data in parallel
            for (var i = 0; i < tasks.Length; i++)
            {
                tasks[i] = Task.Run(() =>
                {
                    var rand = new Random(Guid.NewGuid().GetHashCode());
                    var sb = new StringBuilder(bufferSize / tasks.Length);

                    while (sb.Length < bufferSize / tasks.Length)
                    {
                        var number = rand.Next(1, 1000000);
                        var str = SampleStrings[rand.Next(SampleStrings.Length)];
                        var line = $"{number}. {str}{Environment.NewLine}";
                        sb.Append(line);
                    }

                    return sb.ToString();
                });
            }

            // Wait for all tasks to complete
            var results = await Task.WhenAll(tasks);

            // Write results asynchronously
            foreach (var data in results)
            {
                var byteCount = Encoding.UTF8.GetByteCount(data);
                if (totalBytesGenerated + byteCount > fileSizeInBytes)
                {
                    var remainingBytes = fileSizeInBytes - totalBytesGenerated;
                    var truncatedData = data.Substring(0, (int)remainingBytes);
                    await writer.WriteAsync(truncatedData);
                    totalBytesGenerated += remainingBytes;
                    break;
                }

                await writer.WriteAsync(data);
                totalBytesGenerated += byteCount;
            }
        }
    }
}