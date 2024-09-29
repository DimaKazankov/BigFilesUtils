using System.Text;

namespace BigFilesUtils.Domain.FileGenerator;

public class FileGenerator(string[] input) : IFileGenerator
{
    public async Task GenerateFileAsync(string filePath, long fileSizeInBytes)
    {
        var random = new Random();
        await using var writer = new StreamWriter(filePath, false, Encoding.UTF8, 65536);
        long currentSize = 0;
        while (currentSize < fileSizeInBytes)
        {
            var number = random.Next(1, 1000000);
            var str = input[random.Next(input.Length)];
            var line = $"{number}. {str}";

            await writer.WriteLineAsync(line);
            currentSize += Encoding.UTF8.GetByteCount(line + Environment.NewLine);
        }
    }
}