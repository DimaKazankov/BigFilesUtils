using System.Text;

namespace BigFilesUtils;

public class FileGenerator
{
    private static readonly string[] SampleStrings =
    [
        "Apple", "Banana is yellow", "Cherry is the best", "Something something something"
    ];

    public void GenerateFile(string filePath, long fileSizeInBytes)
    {
        var random = new Random();
        using var writer = new StreamWriter(filePath, false, Encoding.UTF8, 65536);
        long currentSize = 0;
        while (currentSize < fileSizeInBytes)
        {
            var number = random.Next(1, 1000000);
            var str = SampleStrings[random.Next(SampleStrings.Length)];
            var line = $"{number}. {str}";

            writer.WriteLine(line);
            currentSize += Encoding.UTF8.GetByteCount(line + Environment.NewLine);
        }
    }
}
