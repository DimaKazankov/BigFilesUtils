using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using FileAlgorithms.Generator.Algorithms;
using FileAlgorithms.Sorter;
using FileAlgorithms.Sorter.Algorithms.Memory;

namespace FileAlgorithms.Benchmark.Benchmark;

[ShortRunJob(RuntimeMoniker.Net80)]
[Config(typeof(CustomConfig))]
public class FileSorterBenchmark
{
    private string? _inputFileName;
    private string? _outputFileName;

    [ParamsSource(nameof(FileSizes))]
    public FileSize FileSizeInBytes { get; set; }

    [ParamsAllValues]
    public SorterMethod Sorter { get; set; }

    [ParamsAllValues]
    public MemorySorterType MemorySorter { get; set; }

    public static IEnumerable<FileSize> FileSizes =>
    [
        new(50 * 1024 * 1024), // 50 MB
        new(100 * 1024 * 1024), // 100 MB
    ];

    public enum MemorySorterType
    {
        Default,
        Quick
    }

    [GlobalSetup]
    public async Task Setup()
    {
        _inputFileName = Path.GetTempFileName();
        _outputFileName = Path.GetTempFileName();
            
        string[] sampleStrings = ["Apple", "Banana is yellow", "Cherry is the best", "Something something something"];
        var fileGenerator = new FileGeneratorBuffered(sampleStrings, 1048576);
        await fileGenerator.GenerateFileAsync(_inputFileName, FileSizeInBytes.Bytes);
    }

    [Benchmark]
    public async Task SortFile()
    {
        ISorter memorySorter = MemorySorter switch
        {
            MemorySorterType.Default => new DefaultSorter(),
            MemorySorterType.Quick => new QuickSorter(),
            _ => throw new ArgumentOutOfRangeException()
        };

        var fileSorter = FileSorterFactory.GetFileSorter(Sorter, memorySorter);
        await fileSorter.SortFileAsync(_inputFileName!, _outputFileName!);
    }

    [GlobalCleanup]
    public void Cleanup()
    {
        File.Delete(_inputFileName!);
        File.Delete(_outputFileName!);
    }
}