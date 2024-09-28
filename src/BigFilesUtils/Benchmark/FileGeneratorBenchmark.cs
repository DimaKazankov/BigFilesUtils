using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using BigFilesUtils.Domain;

namespace BigFilesUtils.Benchmark;

[MemoryDiagnoser]
[MinColumn, MaxColumn, MeanColumn, Q1Column, Q3Column, MedianColumn, StdDevColumn]
[MarkdownExporterAttribute.GitHub]
[RPlotExporter]
[GcServer(true)]
[ShortRunJob]
[Config(typeof(CustomConfig))]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class FileGeneratorBenchmark
{
    private FileGenerator? _fileGenerator;
    private string? _fileName;
    
    public static IEnumerable<FileSize> FileSizes =>
    [
        new(1024 * 1024),
        new(100 * 1024L * 1024L),
        new(1024L * 1024L * 1024L),
        // new(10 * 1024L * 1024L * 1024L),
        // new(100 * 1024 * 1024L * 1024L)
    ];

    [ParamsSource(nameof(FileSizes))]
    public FileSize FileSizeInBytes { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        _fileGenerator = new FileGenerator();
        _fileName = $"{FileSizeInBytes}_file_generator_benchmark.txt";
    }

    [Benchmark]
    public void GenerateFile() => _fileGenerator!.GenerateFile(_fileName!, FileSizeInBytes.Bytes);

    [GlobalCleanup]
    public void Cleanup()
    {
        if (_fileName == null || !File.Exists(_fileName))
            return;
        try
        {
            File.Delete(_fileName);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting file {_fileName}: {ex.Message}");
        }
    }
}