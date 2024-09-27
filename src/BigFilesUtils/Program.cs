using System.Reflection;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using BigFilesUtils;

BenchmarkSwitcher.FromAssembly(Assembly.GetExecutingAssembly()).Run(args);

[InProcess]
[MemoryDiagnoser]
[MinColumn, MaxColumn, MeanColumn, Q1Column, Q3Column, MedianColumn, StdDevColumn]
[MarkdownExporterAttribute.GitHub]
[GcServer(true)]
[ShortRunJob]
public class FileGeneratorBenchmark
{
    private FileGenerator? _fileGenerator;
    
    [Params(1024, 1024 * 1024)]
    public int FileSizeInBytes { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        _fileGenerator = new FileGenerator();
    }

    [Benchmark]
    public void GenerateFile()
    {
        _fileGenerator!.GenerateFile($"{FileSizeInBytes}_bytes_file_generator_benchmark.txt", FileSizeInBytes);
    }
}
