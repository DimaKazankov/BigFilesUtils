using BenchmarkDotNet.Attributes;
using BigFilesUtils.Domain.FileGenerator;

namespace BigFilesUtils.Benchmark;

[MemoryDiagnoser]
[Config(typeof(CustomConfig))]
public class FileGeneratorBenchmark
{
    [ParamsSource(nameof(FileSizes))] public FileSize FileSizeInBytes { get; set; }

    [ParamsAllValues] public GeneratorType Generator { get; set; }

    public static IEnumerable<FileSize> FileSizes =>
    [
        new(100 * 1024 * 1024), // 100 MB
        new(1024 * 1024 * 1024), // 1 GB
    ];

    [Benchmark]
    public async Task GenerateFile()
    {
        var fileName = Path.GetTempFileName();
        var fileGenerator =FileGeneratorFactory.GetFileGenerator(Generator);
        try
        {
            await fileGenerator.GenerateFileAsync(fileName, FileSizeInBytes.Bytes);
        }
        finally
        {
            File.Delete(fileName);
        }
    }
}