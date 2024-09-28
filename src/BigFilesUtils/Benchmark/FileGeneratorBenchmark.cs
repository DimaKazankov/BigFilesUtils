using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using BigFilesUtils.Domain;

namespace BigFilesUtils.Benchmark;

[MemoryDiagnoser]
[MinColumn, MaxColumn, MeanColumn, MedianColumn, StdDevColumn, StdErrorColumn]
[MarkdownExporterAttribute.GitHub]
[RPlotExporter]
[HtmlExporter]
[CsvExporter]
[GcServer(true)]
[Config(typeof(CustomConfig))]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class FileGeneratorBenchmark
{
    private string? _fileName;
    private IFileGenerator? _fileGenerator;

    public static IEnumerable<FileSize> FileSizes =>
    [
        new(100 * 1024 * 1024), // 100 MB
        // new(500 * 1024 * 1024), // 500 MB
        //new(1024 * 1024 * 1024) // 1 GB
    ];

    [ParamsSource(nameof(FileSizes))]
    public FileSize FileSizeInBytes { get; set; }

    [ParamsAllValues]
    public GeneratorType Generator { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        _fileName = $"{FileSizeInBytes}_{Generator}_file.txt";

        _fileGenerator = Generator switch
        {
            GeneratorType.Original => new FileGenerator(),
            GeneratorType.Buffered => new FileGeneratorBuffered(),
            GeneratorType.Parallel => new FileGeneratorParallel(),
            GeneratorType.MemoryMapped => new FileGeneratorMemoryMapped(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    [Benchmark]
    public void GenerateFile()
    {
        _fileGenerator!.GenerateFileAsync(_fileName!, FileSizeInBytes.Bytes);
    }

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