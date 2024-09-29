using System.IO.MemoryMappedFiles;
using System.Text;

namespace BigFilesUtils.Domain.FileSorter;

public class MemoryMappedSorter : IFileSorter
{
    public async Task SortFileAsync(string inputFilePath, string outputFilePath)
    {
        using var mmf = MemoryMappedFile.CreateFromFile(inputFilePath, FileMode.Open);
        using var accessor = mmf.CreateViewAccessor();

        var fileSize = new FileInfo(inputFilePath).Length;
        var lines = new List<string>();

        for (long position = 0; position < fileSize;)
        {
            var line = ReadLine(accessor, ref position, fileSize);
            if (line != null)
                lines.Add(line);
        }

        lines.Sort((a, b) =>
        {
            var compResult = string.Compare(a.Substring(a.IndexOf('.') + 2), b.Substring(b.IndexOf('.') + 2), StringComparison.Ordinal);
            if (compResult != 0) return compResult;
            return int.Parse(a.Substring(0, a.IndexOf('.'))).CompareTo(int.Parse(b.Substring(0, b.IndexOf('.'))));
        });

        await File.WriteAllLinesAsync(outputFilePath, lines);
    }

    private string? ReadLine(MemoryMappedViewAccessor accessor, ref long position, long fileSize)
    {
        var builder = new StringBuilder();
        while (position < fileSize)
        {
            var b = accessor.ReadByte(position++);
            if (b == '\n')
                break;
            if (b != '\r')
                builder.Append((char)b);
        }
        return builder.Length > 0 ? builder.ToString() : null;
    }
}