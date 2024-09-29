using System.Reflection;
using BenchmarkDotNet.Running;
using FileAlgorithms.Benchmark.Benchmark;

namespace FileAlgorithms.Benchmark.Runners;

public class BenchmarkRunner
{
    public static void RunBenchmarks(string[] args)
    {
        if (args.Contains("--generator") || args.Contains("-g"))
        {
            //BenchmarkDotNet.Running.BenchmarkRunner.Run<FileGeneratorBenchmark>(config: new CustomConfig(), args);
        }
        else if (args.Contains("--sorter") || args.Contains("-sr"))
        {
            BenchmarkDotNet.Running.BenchmarkRunner.Run<FileSorterBenchmark>(config: new CustomConfig(), args);
        }
        else
        {
            BenchmarkSwitcher.FromAssembly(Assembly.GetExecutingAssembly()).Run(args);
        }
    }
}