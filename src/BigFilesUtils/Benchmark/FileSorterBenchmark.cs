using BenchmarkDotNet.Attributes;
using BigFilesUtils.Domain.FileGenerator;
using BigFilesUtils.Domain.FileSorter;

namespace BigFilesUtils.Benchmark;

[MemoryDiagnoser]
[Config(typeof(CustomConfig))]
public class FileSorterBenchmark
{
    private string? _inputFileName;
    private string? _outputFileName;

    [ParamsSource(nameof(FileSizes))]
    public FileSize FileSizeInBytes { get; set; }

    [ParamsAllValues]
    public SorterType Sorter { get; set; }

    public static IEnumerable<FileSize> FileSizes =>
    [
        new(50 * 1024 * 1024), // 100 MB
        new(100 * 1024 * 1024), // 200 MB
        //new(1024 * 1024 * 1024), // 1 GB
        //new(10L * 1024 * 1024 * 1024) // 10 GB
    ];

    [GlobalSetup]
    public async Task Setup()
    {
        _inputFileName = Path.GetTempFileName();
        _outputFileName = Path.GetTempFileName();
            
        string[] sampleStrings = ["Apple", "Banana is yellow", "Cherry is the best", "Something something something"];
        var fileGenerator = new FileGeneratorBuffered(sampleStrings);
        await fileGenerator.GenerateFileAsync(_inputFileName, FileSizeInBytes.Bytes);
    }

    [Benchmark]
    public async Task SortFile()
    {
        var fileSorter = FileSorterFactory.GetFileSorter(Sorter);
        await fileSorter.SortFileAsync(_inputFileName!, _outputFileName!);
    }

    [GlobalCleanup]
    public void Cleanup()
    {
        File.Delete(_inputFileName!);
        File.Delete(_outputFileName!);
    }
}