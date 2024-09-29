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
    public void Setup()
    {
        _inputFileName = Path.GetTempFileName();
        _outputFileName = Path.GetTempFileName();
            
        // Generate a file to sort
        var fileGenerator = new FileGenerator();
        fileGenerator.GenerateFileAsync(_inputFileName, FileSizeInBytes.Bytes).Wait();
    }

    [Benchmark]
    public async Task SortFile()
    {
        IFileSorter fileSorter = Sorter switch
        {
            SorterType.ExternalMerge => new ExternalMergeSorter(),
            SorterType.KWayMerge => new KWayMergeSorter(),
            SorterType.Parallel => new ParallelExternalSorter(),
            SorterType.MemoryMapped => new MemoryMappedSorter(),
            _ => throw new ArgumentOutOfRangeException()
        };

        await fileSorter.SortFileAsync(_inputFileName!, _outputFileName!);
    }

    [GlobalCleanup]
    public void Cleanup()
    {
        File.Delete(_inputFileName!);
        File.Delete(_outputFileName!);
    }
}