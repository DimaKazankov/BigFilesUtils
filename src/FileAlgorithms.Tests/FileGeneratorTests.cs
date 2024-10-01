using System.Text.RegularExpressions;
using FileAlgorithms.Generator;
using FileAlgorithms.Generator.Algorithms;

namespace FileAlgorithms.Tests;

public class FileGeneratorTests : IDisposable
{
    private readonly string _tempFileName = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".txt");

    [Theory]
    [InlineData(GeneratorType.Original)]
    [InlineData(GeneratorType.Buffered)]
    [InlineData(GeneratorType.Parallel)]
    [InlineData(GeneratorType.ByteChunksParallel)]
    [InlineData(GeneratorType.MemoryMapped)]
    public async Task GenerateFileAsync_CreatesFileOfExpectedSize(GeneratorType generatorType)
    {
        const long expectedSizeInBytes = 10 * 1024; // 10 KB
        var fileGenerator = FileGeneratorFactory.GetFileGenerator(generatorType);

        await fileGenerator.GenerateFileAsync(_tempFileName, expectedSizeInBytes);

        var fileInfo = new FileInfo(_tempFileName);
        Assert.True(fileInfo.Exists, "Generated file does not exist.");
        Assert.True(fileInfo.Length >= expectedSizeInBytes, $"Generated file size is less than expected. Expected at least {expectedSizeInBytes} bytes, but was {fileInfo.Length} bytes.");
    }

    [Theory]
    [InlineData(GeneratorType.Original)]
    [InlineData(GeneratorType.Buffered)]
    [InlineData(GeneratorType.Parallel)]
    [InlineData(GeneratorType.ByteChunksParallel)]
    [InlineData(GeneratorType.MemoryMapped)]
    public async Task GenerateFileAsync_CreatesFileWithExpectedContentFormat(GeneratorType generatorType)
    {
        const long sizeInBytes = 5 * 1024; // 5 KB
        var fileGenerator = FileGeneratorFactory.GetFileGenerator(generatorType);

        await fileGenerator.GenerateFileAsync(_tempFileName, sizeInBytes);
        Assert.True(File.Exists(_tempFileName), "Generated file does not exist.");

        var lines = await File.ReadAllLinesAsync(_tempFileName);

        Assert.NotEmpty(lines);

        var regex = new Regex(@"^\d+\. .+$");

        foreach (var line in lines)
        {
            var trimmedLine = line.TrimEnd('\r', '\n');
            Assert.Matches(regex, trimmedLine);
        }
    }

    public void Dispose()
    {
        if (!File.Exists(_tempFileName))
            return;
        try
        {
            File.Delete(_tempFileName);
        }
        catch
        {
            // Ignore exceptions during cleanup
        }
    }
}