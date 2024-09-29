using BenchmarkDotNet.Configs;
using BigFilesUtils.Benchmark;

namespace BigFilesUtils.Runners;

public class BenchmarkRunner
{
    public static void RunBenchmarks(string[] args)
    {
        var config = DefaultConfig.Instance;
            
        if (args.Contains("--generator") || args.Contains("-g"))
        {
            BenchmarkDotNet.Running.BenchmarkRunner.Run<FileGeneratorBenchmark>(config);
        }
        else if (args.Contains("--sorter") || args.Contains("-sr"))
        {
            BenchmarkDotNet.Running.BenchmarkRunner.Run<FileSorterBenchmark>(config);
        }
        else
        {
            BenchmarkDotNet.Running.BenchmarkRunner.Run<FileGeneratorBenchmark>(config);
            BenchmarkDotNet.Running.BenchmarkRunner.Run<FileSorterBenchmark>(config);
        }
    }
}