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
        IFileGenerator fileGenerator = Generator switch
        {
            GeneratorType.Original => new FileGenerator(),
            GeneratorType.Buffered => new FileGeneratorBuffered(),
            GeneratorType.Parallel => new FileGeneratorParallel(),
            GeneratorType.MemoryMapped => new FileGeneratorMemoryMapped(),
            _ => throw new ArgumentOutOfRangeException()
        };

        var fileName = Path.GetTempFileName();
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