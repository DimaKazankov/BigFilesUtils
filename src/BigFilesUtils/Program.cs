using System.Reflection;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;
using BigFilesUtils;

BenchmarkSwitcher.FromAssembly(Assembly.GetExecutingAssembly()).Run(args);
public struct FileSize
{
    public long Bytes { get; }

    public FileSize(long bytes)
    {
        Bytes = bytes;
    }

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

    [Params(
        100 * 1024,
        100 * 1024 * 1024,
        1024 * 1024L * 1024L,
        10 * 1024 * 1024L * 1024L,
        100 * 1024 * 1024L * 1024L)]
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
