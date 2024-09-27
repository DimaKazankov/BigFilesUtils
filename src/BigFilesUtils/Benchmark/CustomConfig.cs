using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Csv;
using Perfolizer.Horology;
using Perfolizer.Metrology;
using BenchmarkDotNet.Reports;

namespace BigFilesUtils.Benchmark;

public class CustomConfig : ManualConfig
{
    public CustomConfig()
    {
        AddColumn(TargetMethodColumn.Method, new ParamColumn("Generator"), new ParamColumn("FileSize"));
        AddColumn(StatisticColumn.AllStatistics);
        AddColumn(RankColumn.Arabic);
        AddColumn(BaselineRatioColumn.RatioMean);

        WithSummaryStyle(
            SummaryStyle.Default
                .WithTimeUnit(TimeUnit.Second)
                .WithSizeUnit(SizeUnit.MB)
                .WithMaxParameterColumnWidth(50)
            );

        // Optionally, display the total time
        WithOption(ConfigOptions.DisableOptimizationsValidator, true);
        WithOption(ConfigOptions.JoinSummary, true);

        // Keep existing exporters
        AddExporter(MarkdownExporter.GitHub);
        AddExporter(HtmlExporter.Default);
        AddExporter(CsvExporter.Default);
        AddExporter(RPlotExporter.Default);
    }
}