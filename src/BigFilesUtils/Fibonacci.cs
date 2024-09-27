using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Exporters.Csv;

namespace BigFilesUtils;

[InProcess]
[MemoryDiagnoser]
[RankColumn, MinColumn, MaxColumn, Q1Column, Q3Column, AllStatisticsColumn]
[MarkdownExporterAttribute.GitHub]
[GcServer(true)]
public class Fibonacci
{
    public IEnumerable<int> GetFibonacci(int count)
    {
        var w = 1;
        var x = 1;

        yield return x;
        foreach (var _ in Enumerable.Range(1, count - 1))
        {
            var y = w + x;
            yield return y;
            w = x;
            x = y;
        }
    }
}