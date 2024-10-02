using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Reports;
using Perfolizer.Horology;
using Perfolizer.Metrology;

namespace FileAlgorithms.Benchmark.Benchmark;

public class CustomConfig : ManualConfig
{
    public CustomConfig()
    {
        AddExporter(RPlotExporter.Default);
        AddExporter(MarkdownExporter.GitHub);
        AddDiagnoser(MemoryDiagnoser.Default);
        
        AddColumn(TargetMethodColumn.Method);
        AddColumn(StatisticColumn.AllStatistics);
        AddColumn(RankColumn.Arabic);

        WithSummaryStyle(
            SummaryStyle.Default
                .WithTimeUnit(TimeUnit.Second)
                .WithSizeUnit(SizeUnit.MB)
                .WithMaxParameterColumnWidth(50)
            );
        
    }
}