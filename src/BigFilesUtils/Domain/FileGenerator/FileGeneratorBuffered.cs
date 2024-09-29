using System.Text;

namespace BigFilesUtils.Domain.FileGenerator;

public class FileGeneratorBuffered(string[] input) : IFileGenerator
{
    public async Task GenerateFileAsync(string filePath, long fileSizeInBytes)
    {
        var random = new Random();
        var sb = new StringBuilder(65536); // Larger buffer size
        await using var writer = new StreamWriter(filePath, false, Encoding.UTF8, 65536);
        long currentSize = 0;

        while (currentSize < fileSizeInBytes)
        {
            var number = random.Next(1, 1000000);
            var str = input[random.Next(input.Length)];
            var line = $"{number}. {str}{Environment.NewLine}";

            sb.Append(line);
            currentSize += Encoding.UTF8.GetByteCount(line);

            if (sb.Length >= 65536)
            {
                await writer.WriteAsync(sb.ToString());
                sb.Clear();
            }
        }

        // Write any remaining content
        if (sb.Length > 0)
        {
            await writer.WriteAsync(sb.ToString());
        }
    }
}