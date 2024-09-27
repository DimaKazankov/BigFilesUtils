using System.Reflection;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;
using BigFilesUtils;

BenchmarkSwitcher.FromAssembly(Assembly.GetExecutingAssembly()).Run(args);
// public class CustomConfig : ManualConfig
// {
//     public CustomConfig()
//     {
//         AddExporter(RPlotExporter.Default);
//         AddColumnProvider(DefaultColumnProviders.Instance);
//         AddLogger(ConsoleLogger.Default);
//         // Add any additional customizations here
//     }
// }

[MemoryDiagnoser]
[MinColumn, MaxColumn, MeanColumn, Q1Column, Q3Column, MedianColumn, StdDevColumn]
[MarkdownExporterAttribute.GitHub]
[RPlotExporter]
[GcServer(true)]
[ShortRunJob]
public class FileGeneratorBenchmark
{
    private FileGenerator? _fileGenerator;
    private string? _fileName;

    [Params(100 * 1024, 100 * 1024 * 1024, 1024L * 1024L * 1024L)]
    public long FileSizeInBytes { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        _fileGenerator = new FileGenerator();
        var sizeLabel = GetSizeLabel(FileSizeInBytes);
        _fileName = $"{sizeLabel}_file_generator_benchmark.txt";
    }

    [Benchmark]
    public void GenerateFile() => _fileGenerator!.GenerateFile(_fileName!, FileSizeInBytes);

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

    private static string GetSizeLabel(long bytes)
    {
        const long gb = 1024L * 1024L * 1024L;
        const long mb = 1024L * 1024L;
        const long kb = 1024L;

        switch (bytes)
        {
            case >= gb:
            {
                var sizeInGb = (double)bytes / gb;
                return $"{sizeInGb:F2}GB";
            }
            case >= mb:
            {
                var sizeInMb = (double)bytes / mb;
                return $"{sizeInMb:F2}MB";
            }
            case >= kb:
            {
                var sizeInKb = (double)bytes / kb;
                return $"{sizeInKb:F2}KB";
            }
            default:
                return $"{bytes}B";
        }
    }
}
