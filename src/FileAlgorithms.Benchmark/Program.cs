using FileAlgorithms.Benchmark.Runners;

namespace FileAlgorithms.Benchmark;

public class Program
{
    static async Task Main(string[] args)
    {
        if (args.Contains("--local") || args.Contains("-l"))
        {
            await LocalRunner.RunLocalOperations(args);
            return;
        }
        
        BenchmarkRunner.RunBenchmarks(args);
    }
}