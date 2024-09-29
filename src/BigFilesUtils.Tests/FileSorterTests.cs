using BigFilesUtils.Domain.FileSorter;

namespace BigFilesUtils.Tests;

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
    [InlineData(typeof(ExternalMergeSorter))]
    [InlineData(typeof(KWayMergeSorter))]
    [InlineData(typeof(ParallelExternalSorter))]
    [InlineData(typeof(MemoryMappedSorter))]
    public async Task SortFile_CorrectlySortsLines(Type sorterType)
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
        var sorter = (IFileSorter)Activator.CreateInstance(sorterType)!;

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
    [InlineData(typeof(ExternalMergeSorter))]
    [InlineData(typeof(KWayMergeSorter))]
    [InlineData(typeof(ParallelExternalSorter))]
    [InlineData(typeof(MemoryMappedSorter))]
    public async Task SortFile_HandlesLargeFile(Type sorterType)
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
        var sorter = (IFileSorter)Activator.CreateInstance(sorterType)!;

        await sorter.SortFileAsync(_inputPath, _outputPath);

        using (var reader = new StreamReader(_outputPath))
        {
            string? previousLine = null;
            lineCount = 0;

            while (await reader.ReadLineAsync() is { } currentLine)
            {
                lineCount++;
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

            Assert.Equal(1_000_000, lineCount);
        }
    }
}