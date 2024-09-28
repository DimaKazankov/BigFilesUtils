using System.Text;

namespace BigFilesUtils.Domain;

public class FileGeneratorHybrid : IFileGenerator
{
    private static readonly string[] SampleStrings =
    [
        "Apple", "Banana is yellow", "Cherry is the best", "Something something something"
    ];

    public async Task GenerateFileAsync(string filePath, long fileSizeInBytes)
    {
        const int bufferSize = 65536;
        var totalBytesGenerated = 0L;

        await using var writer = new StreamWriter(filePath, false, Encoding.UTF8, bufferSize);

        while (totalBytesGenerated < fileSizeInBytes)
        {
            var tasks = new Task<byte[]>[Environment.ProcessorCount];

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

                    return Encoding.UTF8.GetBytes(sb.ToString());
                });
            }

            // Wait for all tasks to complete
            var results = await Task.WhenAll(tasks);

            // Write results asynchronously
            foreach (var data in results)
            {
                var byteCount = data.Length;

                if (totalBytesGenerated + byteCount > fileSizeInBytes)
                {
                    var remainingBytes = (int)(fileSizeInBytes - totalBytesGenerated);
                    if (remainingBytes > 0)
                    {
                        await writer.BaseStream.WriteAsync(data, 0, remainingBytes);
                        totalBytesGenerated += remainingBytes;
                    }
                    break; // Exit the foreach loop
                }

                await writer.BaseStream.WriteAsync(data, 0, byteCount);
                totalBytesGenerated += byteCount;
            }

            if (totalBytesGenerated >= fileSizeInBytes)
                break; 
        }
    }
}