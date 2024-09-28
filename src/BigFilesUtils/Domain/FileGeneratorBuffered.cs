using System.Text;

namespace BigFilesUtils.Domain;

public class FileGeneratorBuffered : IFileGenerator
{
    private static readonly string[] SampleStrings =
    [
        "Apple", "Banana is yellow", "Cherry is the best", "Something something something"
    ];

    public void GenerateFile(string filePath, long fileSizeInBytes)
    {
        var random = new Random();
        const int bufferSize = 8192; // 8 KB buffer
        var sb = new StringBuilder(bufferSize);
        using var writer = new StreamWriter(filePath, false, Encoding.UTF8, 65536);
        long currentSize = 0;

        while (currentSize < fileSizeInBytes)
        {
            var number = random.Next(1, 1000000);
            var str = SampleStrings[random.Next(SampleStrings.Length)];
            var line = $"{number}. {str}{Environment.NewLine}";

            sb.Append(line);
            currentSize += Encoding.UTF8.GetByteCount(line);

            if (sb.Length < bufferSize)
                continue;
            
            writer.Write(sb.ToString());
            sb.Clear();
        }

        // Write any remaining content
        if (sb.Length > 0)
        {
            writer.Write(sb.ToString());
        }
    }
}