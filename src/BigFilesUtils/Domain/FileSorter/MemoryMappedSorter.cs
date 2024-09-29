using System.IO.MemoryMappedFiles;
using System.Text;

namespace BigFilesUtils.Domain.FileSorter;

public class MemoryMappedSorter : IFileSorter
{
    public async Task SortFileAsync(string inputFilePath, string outputFilePath)
    {
        Console.WriteLine($"Starting MemoryMappedSorter on file: {inputFilePath}");
        
        using var mmf = MemoryMappedFile.CreateFromFile(inputFilePath, FileMode.Open);
        using var accessor = mmf.CreateViewAccessor();

        var fileSize = new FileInfo(inputFilePath).Length;
        Console.WriteLine($"File size: {fileSize} bytes");

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

        Console.WriteLine($"Read {lines.Count} non-empty lines from file");

        try
        {
            lines.Sort((a, b) => CompareSortedLines(a, b));
            Console.WriteLine("Sorting completed successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during sorting: {ex.Message}");
            throw;
        }

        await File.WriteAllLinesAsync(outputFilePath, lines);
        Console.WriteLine($"Sorted lines written to: {outputFilePath}");
    }

    private long SkipBomIfPresent(MemoryMappedViewAccessor accessor, long fileSize)
    {
        if (fileSize >= 3)
        {
            byte b1 = accessor.ReadByte(0);
            byte b2 = accessor.ReadByte(1);
            byte b3 = accessor.ReadByte(2);
            if (b1 == 0xEF && b2 == 0xBB && b3 == 0xBF)
            {
                Console.WriteLine("UTF-8 BOM detected and skipped.");
                return 3;
            }
        }
        return 0;
    }

    private int CompareSortedLines(string a, string b)
    {
        var partsA = a.Split('.', 2);
        var partsB = b.Split('.', 2);

        if (partsA.Length != 2 || partsB.Length != 2)
        {
            throw new FormatException($"Invalid line format. Line A: '{a}', Line B: '{b}'");
        }

        var compResult = string.Compare(partsA[1].Trim(), partsB[1].Trim(), StringComparison.Ordinal);
        if (compResult != 0) return compResult;

        if (!int.TryParse(partsA[0], out var numA) || !int.TryParse(partsB[0], out var numB))
        {
            throw new FormatException($"Failed to parse numbers. Line A: '{a}', Line B: '{b}'");
        }

        return numA.CompareTo(numB);
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