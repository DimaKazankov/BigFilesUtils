using System.IO.MemoryMappedFiles;
using System.Text;
using FileAlgorithms.Sorter.Algorithms.Memory;

namespace FileAlgorithms.Sorter.Algorithms.IO;

public class MemoryMappedFileSorter(ISorter sorter) : IFileSorter
{
    public async Task SortFileAsync(string inputFilePath, string outputFilePath)
    {
        using var mmf = MemoryMappedFile.CreateFromFile(inputFilePath, FileMode.Open);
        using var accessor = mmf.CreateViewAccessor();

        var fileSize = new FileInfo(inputFilePath).Length;

        var lines = new List<string>();
        long position = 0;

        // Automatically detect and skip BOM if present
        position = SkipBomIfPresent(accessor, fileSize);

        while (position < fileSize)
        {
            var line = ReadLine(accessor, ref position, fileSize);
            if (!string.IsNullOrWhiteSpace(line))
                lines.Add(line);
        }

        sorter.Sort(lines);
        await File.WriteAllLinesAsync(outputFilePath, lines);
    }

    private long SkipBomIfPresent(MemoryMappedViewAccessor accessor, long fileSize)
    {
        if (fileSize >= 3)
        {
            var b1 = accessor.ReadByte(0);
            var b2 = accessor.ReadByte(1);
            var b3 = accessor.ReadByte(2);
            if (b1 == 0xEF && b2 == 0xBB && b3 == 0xBF)
            {
                return 3;
            }
        }
        return 0;
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