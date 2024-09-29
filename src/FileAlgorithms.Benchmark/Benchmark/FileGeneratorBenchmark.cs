using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using FileAlgorithms.Generator;
using FileAlgorithms.Generator.Algorithms;

namespace FileAlgorithms.Benchmark.Benchmark;

[ShortRunJob(RuntimeMoniker.Net80)]
[Config(typeof(CustomConfig))]
public class FileGeneratorBenchmark
{
    private IFileGenerator? _fileGenerator;
    private string? _fileName;
    
    [ParamsSource(nameof(FileSizes))]
    public FileSize FileSizeInBytes { get; set; }

    [ParamsAllValues]
    public GeneratorType Generator { get; set; }

    public static IEnumerable<FileSize> FileSizes =>
    [
        new(100 * 1024 * 1024), // 100 MB
        new(1024 * 1024 * 1024), // 1 GB
    ];

    [GlobalSetup]
    public void Setup()
    {
        _fileName = Path.GetTempFileName();
        _fileGenerator = FileGeneratorFactory.GetFileGenerator(Generator);
    }

    [Benchmark]
    public async Task GenerateFile()
    {
        await _fileGenerator!.GenerateFileAsync(_fileName!, FileSizeInBytes.Bytes);
    }

    [GlobalCleanup]
    public void Cleanup()
    {
        File.Delete(_fileName!);
    }
}