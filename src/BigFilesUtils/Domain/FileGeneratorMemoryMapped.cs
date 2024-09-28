using System.IO.MemoryMappedFiles;
using System.Text;

namespace BigFilesUtils.Domain;

public class FileGeneratorMemoryMapped : IFileGenerator
{
    private static readonly string[] SampleStrings =
    [
        "Apple", "Banana is yellow", "Cherry is the best", "Something something something"
    ];

    public async Task GenerateFileAsync(string filePath, long fileSizeInBytes) => await Task.Run(() => GenerateFileInternal(filePath, fileSizeInBytes));

    private void GenerateFileInternal(string filePath, long fileSizeInBytes)
    {
        var random = new Random();
        using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite, FileShare.None))
            fs.SetLength(fileSizeInBytes);

        using var mmf = MemoryMappedFile.CreateFromFile(filePath, FileMode.Open, null, fileSizeInBytes, MemoryMappedFileAccess.ReadWrite);
        using var accessor = mmf.CreateViewAccessor(0, fileSizeInBytes, MemoryMappedFileAccess.Write);

        long position = 0;

        while (position < fileSizeInBytes)
        {
            var number = random.Next(1, 1000000);
            var str = SampleStrings[random.Next(SampleStrings.Length)];
            var line = $"{number}. {str}{Environment.NewLine}";
            var bytes = Encoding.UTF8.GetBytes(line);

            if (position + bytes.Length > fileSizeInBytes)
            {
                var remainingSpace = fileSizeInBytes - position;
                if (remainingSpace > 0)
                {
                    var truncatedLine = Encoding.UTF8.GetString(bytes, 0, (int)remainingSpace);
                    bytes = Encoding.UTF8.GetBytes(truncatedLine);
                    accessor.WriteArray(position, bytes, 0, bytes.Length);
                }

                break;
            }

            accessor.WriteArray(position, bytes, 0, bytes.Length);
            position += bytes.Length;
        }

        accessor.Flush();
    }
}