using BenchmarkDotNet.Configs;
using Perfolizer.Horology;
using Perfolizer.Metrology;

namespace BigFilesUtils.Benchmark;

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