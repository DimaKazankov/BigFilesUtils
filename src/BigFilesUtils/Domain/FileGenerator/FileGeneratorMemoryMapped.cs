using System.IO.MemoryMappedFiles;
using System.Text;

namespace BigFilesUtils.Domain.FileGenerator;

public class FileGeneratorMemoryMapped(string[] input) : IFileGenerator
{
    public async Task GenerateFileAsync(string filePath, long fileSizeInBytes) => await Task.Run(() => GenerateFile(filePath, fileSizeInBytes));

    public void GenerateFile(string filePath, long fileSizeInBytes)
    {
        var random = new Random();

        using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite, FileShare.None))
            fs.SetLength(fileSizeInBytes);

        using var mmf = MemoryMappedFile.CreateFromFile(
            filePath,
            FileMode.Open,
            null,
            fileSizeInBytes,
            MemoryMappedFileAccess.ReadWrite);

        long position = 0;

        using var accessor = mmf.CreateViewStream();
        var isFirstLine = true;

        while (true)
        {
            var number = random.Next(1, 1000000);
            var str = input[random.Next(input.Length)];
            var line = $"{number}. {str}";

            if (!isFirstLine)
            {
                line = Environment.NewLine + line;
            }

            var bytes = Encoding.UTF8.GetBytes(line);

            if (position + bytes.Length > fileSizeInBytes)
                break;

            accessor.Write(bytes, 0, bytes.Length);
            position += bytes.Length;
            isFirstLine = false;
        }

        accessor.Flush();
    }
}
