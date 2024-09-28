using System.Reflection;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Running;
using BigFilesUtils;
using Perfolizer.Horology;
using Perfolizer.Metrology;

BenchmarkSwitcher.FromAssembly(Assembly.GetExecutingAssembly()).Run(args);


public readonly struct FileSize(long bytes)
{
    public long Bytes { get; } = bytes;

    public override string ToString()
    {
        const double GB = 1024 * 1024 * 1024;
        const double MB = 1024 * 1024;
        const double KB = 1024;

        return Bytes >= GB ? $"{Bytes / GB:F2} GB" :
            Bytes >= MB ? $"{Bytes / MB:F2} MB" :
            Bytes >= KB ? $"{Bytes / KB:F2} KB" : $"{Bytes} B";
    }
}

public class CustomConfig : ManualConfig
{
    public CustomConfig()
    {
        // Set the time and size units
        SummaryStyle = BenchmarkDotNet.Reports.SummaryStyle.Default
            .WithTimeUnit(TimeUnit.Second)      // Use seconds for time measurements
            .WithSizeUnit(SizeUnit.GB)          // Use MB for size measurements
            .WithMaxParameterColumnWidth(50);   // Adjust column width if necessary
    }
}


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
        new(10 * 1024L * 1024L * 1024L),
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
