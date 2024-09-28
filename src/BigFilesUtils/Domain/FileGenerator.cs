using System.Text;

namespace BigFilesUtils.Domain;

public class FileGenerator : IFileGenerator
{
    private static readonly string[] SampleStrings =
    [
        "Apple", "Banana is yellow", "Cherry is the best", "Something something something"
    ];

    public async Task GenerateFileAsync(string filePath, long fileSizeInBytes)
    {
        var random = new Random();
        await using var writer = new StreamWriter(filePath, false, Encoding.UTF8, 65536);
        long currentSize = 0;
        while (currentSize < fileSizeInBytes)
        {
            var number = random.Next(1, 1000000);
            var str = SampleStrings[random.Next(SampleStrings.Length)];
            var line = $"{number}. {str}";

            await writer.WriteLineAsync(line);
            currentSize += Encoding.UTF8.GetByteCount(line + Environment.NewLine);
        }
    }
}