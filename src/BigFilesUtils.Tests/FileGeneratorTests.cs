using BigFilesUtils.Domain;
using FluentAssertions;

namespace BigFilesUtils.Tests;

public class FileGeneratorTests : IDisposable
{
    private readonly string _testFilePath = Path.Combine(Path.GetTempPath(), "testFile.txt");

    public FileGeneratorTests()
    {
        if (File.Exists(_testFilePath))
            File.Delete(_testFilePath);
    }

    [Fact]
    public void GenerateFile_ShouldCreateFileWithApproximateSize()
    {
        var fileGenerator = new FileGenerator();
        const long expectedSize = 1024; // 1 KB file

        fileGenerator.GenerateFile(_testFilePath, expectedSize);

        File.Exists(_testFilePath).Should().BeTrue();
        var fileInfo = new FileInfo(_testFilePath);
        fileInfo.Length.Should().BeGreaterOrEqualTo(expectedSize);
    }

    [Fact]
    public void GenerateFile_ShouldHaveCorrectLineFormat()
    {
        var fileGenerator = new FileGenerator();
        const long fileSize = 1024; // 1 KB file

        fileGenerator.GenerateFile(_testFilePath, fileSize);

        File.Exists(_testFilePath).Should().BeTrue();
        var lines = File.ReadAllLines(_testFilePath);
        foreach (var line in lines)
        {
            line.Should().MatchRegex(@"^\d+\. .+$");
        }
    }

    public void Dispose()
    {
        if (File.Exists(_testFilePath))
            File.Delete(_testFilePath);
    }
}