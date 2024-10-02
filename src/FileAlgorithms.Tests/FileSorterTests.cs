using System.Text;
using FileAlgorithms.Sorter;
using FileAlgorithms.Sorter.Algorithms.Memory;

namespace FileAlgorithms.Tests;

public class FileSorterTests : IDisposable
{
    private const string TestDir = "TestFiles";
    private const string InputFileName = "input.txt";
    private const string OutputFileName = "output.txt";

    private readonly string _inputPath;
    private readonly string _outputPath;

    public FileSorterTests()
    {
        if (Directory.Exists(TestDir))
            Directory.Delete(TestDir, true);
        Directory.CreateDirectory(TestDir);

        _inputPath = Path.Combine(TestDir, InputFileName);
        _outputPath = Path.Combine(TestDir, OutputFileName);
    }

    public void Dispose()
    {
        if (Directory.Exists(TestDir))
            Directory.Delete(TestDir, true);
    }

    [Theory]
    [InlineData(SorterMethod.ExternalMerge, typeof(QuickSorter))]
    [InlineData(SorterMethod.KWayMerge, typeof(QuickSorter))]
    [InlineData(SorterMethod.Parallel, typeof(QuickSorter))]
    [InlineData(SorterMethod.MemoryMapped, typeof(QuickSorter))]
    [InlineData(SorterMethod.ChunkedMemoryMapped, typeof(QuickSorter))]
    [InlineData(SorterMethod.ExternalMerge, typeof(DefaultSorter))]
    [InlineData(SorterMethod.KWayMerge, typeof(DefaultSorter))]
    [InlineData(SorterMethod.Parallel, typeof(DefaultSorter))]
    [InlineData(SorterMethod.MemoryMapped, typeof(DefaultSorter))]
    [InlineData(SorterMethod.ChunkedMemoryMapped, typeof(DefaultSorter))]
    public async Task SortFile_CorrectlySortsLines(SorterMethod sorterMethod, Type sorterType)
    {
        var inputLines = new[]
        {
            "415. Apple",
            "30432. Something something something",
            "1. Apple",
            "32. Cherry is the best",
            "2. Banana is yellow"
        };
        await File.WriteAllLinesAsync(_inputPath, inputLines);
        var sorter = FileSorterFactory.GetFileSorter(
            sorterMethod,
            (ISorter)Activator.CreateInstance(sorterType)!
        );

        await sorter.SortFileAsync(_inputPath, _outputPath);

        var sortedLines = await File.ReadAllLinesAsync(_outputPath);
        var expectedLines = new[]
        {
            "1. Apple",
            "415. Apple",
            "2. Banana is yellow",
            "32. Cherry is the best",
            "30432. Something something something"
        };

        Assert.Equal(expectedLines, sortedLines);
    }

    [Theory]
    [InlineData(SorterMethod.ExternalMerge, typeof(QuickSorter))]
    [InlineData(SorterMethod.KWayMerge, typeof(QuickSorter))]
    [InlineData(SorterMethod.Parallel, typeof(QuickSorter))]
    [InlineData(SorterMethod.MemoryMapped, typeof(QuickSorter))]
    [InlineData(SorterMethod.ExternalMerge, typeof(DefaultSorter))]
    [InlineData(SorterMethod.KWayMerge, typeof(DefaultSorter))]
    [InlineData(SorterMethod.Parallel, typeof(DefaultSorter))]
    [InlineData(SorterMethod.MemoryMapped, typeof(DefaultSorter))]
    public async Task SortFile_HandlesLargeFile(SorterMethod sorterMethod, Type sorterType)
    {
        var random = new Random(42);
        var sampleStrings = new[] { "Apple", "Banana", "Cherry", "Date", "Elderberry" };
        var lineCount = 1_000_000; // 1 million lines

        await using (var writer = new StreamWriter(_inputPath))
        {
            for (var i = 0; i < lineCount; i++)
            {
                var number = random.Next(1, 1_000_000);
                var str = sampleStrings[random.Next(sampleStrings.Length)];
                await writer.WriteLineAsync($"{number}. {str}");
            }
        }

        var sorter = FileSorterFactory.GetFileSorter(
            sorterMethod,
            (ISorter)Activator.CreateInstance(sorterType)!
        );

        await sorter.SortFileAsync(_inputPath, _outputPath);

        using (var reader = new StreamReader(_outputPath))
        {
            string? previousLine = null;
            var sortedLineCount = 0;

            while (await reader.ReadLineAsync() is { } currentLine)
            {
                sortedLineCount++;
                if (previousLine != null)
                {
                    var prevParts = previousLine.Split(". ", 2);
                    var currParts = currentLine.Split(". ", 2);

                    var comparison = string.Compare(prevParts[1], currParts[1], StringComparison.Ordinal);
                    if (comparison == 0)
                    {
                        Assert.True(int.Parse(prevParts[0]) <= int.Parse(currParts[0]),
                            $"Lines not correctly sorted: {previousLine} should come before {currentLine}");
                    }
                    else
                    {
                        Assert.True(comparison < 0,
                            $"Lines not correctly sorted: {previousLine} should come before {currentLine}");
                    }
                }

                previousLine = currentLine;
            }

            Assert.Equal(1_000_000, sortedLineCount);
        }
    }

    [Theory]
    [InlineData(SorterMethod.ExternalMerge, typeof(QuickSorter))]
    [InlineData(SorterMethod.KWayMerge, typeof(QuickSorter))]
    [InlineData(SorterMethod.Parallel, typeof(QuickSorter))]
    [InlineData(SorterMethod.MemoryMapped, typeof(QuickSorter))]
    [InlineData(SorterMethod.ChunkedMemoryMapped, typeof(QuickSorter))]
    [InlineData(SorterMethod.ExternalMerge, typeof(DefaultSorter))]
    [InlineData(SorterMethod.KWayMerge, typeof(DefaultSorter))]
    [InlineData(SorterMethod.Parallel, typeof(DefaultSorter))]
    [InlineData(SorterMethod.MemoryMapped, typeof(DefaultSorter))]
    [InlineData(SorterMethod.ChunkedMemoryMapped, typeof(DefaultSorter))]
    public async Task SortFile_IgnoresBOM(SorterMethod sorterMethod, Type sorterType)
    {
        // Arrange
        var inputLines = new[]
        {
            "415. Apple",
            "30432. Something something something",
            "1. Apple",
            "32. Cherry is the best",
            "2. Banana is yellow"
        };

        // Write lines with UTF8 encoding (includes BOM)
        await File.WriteAllLinesAsync(_inputPath, inputLines, new UTF8Encoding(encoderShouldEmitUTF8Identifier: true));

        var sorter = FileSorterFactory.GetFileSorter(
            sorterMethod,
            (ISorter)Activator.CreateInstance(sorterType)!
        );

        // Act
        await sorter.SortFileAsync(_inputPath, _outputPath);

        // Assert
        var sortedLines = await File.ReadAllLinesAsync(_outputPath);
        var expectedLines = new[]
        {
            "1. Apple",
            "415. Apple",
            "2. Banana is yellow",
            "32. Cherry is the best",
            "30432. Something something something"
        };

        Assert.Equal(expectedLines, sortedLines);
    }
}