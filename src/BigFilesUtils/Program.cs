using BigFilesUtils.Runners;

namespace BigFilesUtils;

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