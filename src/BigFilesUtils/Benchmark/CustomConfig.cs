using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Order;
using Perfolizer.Horology;
using Perfolizer.Metrology;

namespace BigFilesUtils.Benchmark;

public class CustomConfig : ManualConfig
{
    public CustomConfig()
    {
        AddColumn(TargetMethodColumn.Method, new ParamColumn("Generator"), new ParamColumn("FileSize"));

        SummaryStyle = BenchmarkDotNet.Reports.SummaryStyle.Default
            .WithTimeUnit(TimeUnit.Second)
            .WithSizeUnit(SizeUnit.MB)
            .WithMaxParameterColumnWidth(50);

        // Customize columns
        AddColumn(RankColumn.Arabic);
        AddColumn(BaselineRatioColumn.RatioMean);

        // Order benchmarks
        WithOrderer(new DefaultOrderer());

        // Keep existing exporters
        AddExporter(MarkdownExporter.GitHub);
        AddExporter(HtmlExporter.Default);
        AddExporter(CsvExporter.Default);
        AddExporter(RPlotExporter.Default);
    }
}