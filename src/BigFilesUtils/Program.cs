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
public class FibonacciBenchmark
{
    private Fibonacci? _fibonacci;
    
    [Params(1, 2, 3, 5, 8, 13, 21, 34)]
    public int Count { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        _fibonacci = new Fibonacci();
    }

    [Benchmark]
    public void Fibonacci()
    {
        var list = _fibonacci!.GetFibonacci(Count).ToList();
    }
}
