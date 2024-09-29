namespace BigFilesUtils.Runners;

public class ConsoleWriter
{
    public static T? Execute<T>(string[] args, int i, Func<string, T> func)
    {
        if (i + 1 < args.Length)
            return func(args[++i]);

        Console.WriteLine($"Error: --{args[i]} requires a value.");
        ShowUsage();
        return default;
    }

    public static async Task WrapAlgorithmExecution(string[] algorithms, long fileSizeInBytes, Func<string, Task> func)
    {
        Console.WriteLine("==========                            ==========");
        foreach (var algorithm in algorithms)
        {
            Console.WriteLine($"[{algorithm}]");
            Console.WriteLine(
                $"Starting execute: Algorithm = {algorithm}, Size = {fileSizeInBytes.ToFileSizeLabel()}");
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            try
            {
                await func(algorithm);
                stopwatch.Stop();
                Console.WriteLine($"Successful");
                Console.WriteLine($"Completed in {stopwatch.Elapsed.ToElapsedTimeString()}.");
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                Console.WriteLine($"Error during execution: {ex.Message}");
                Console.WriteLine($"Execution failed after {stopwatch.Elapsed.ToElapsedTimeString()}.");
            }
            Console.WriteLine();
        }

        Console.WriteLine("==========                            ==========");
    }
    
    public static void ShowUsage()
    {
        Console.WriteLine("Usage:");
        Console.WriteLine("  To run benchmarks:");
        Console.WriteLine("    BigFilesUtils.exe");
        Console.WriteLine();
        Console.WriteLine("  To generate a file:");
        Console.WriteLine("    BigFilesUtils.exe generate --algorithm <AlgorithmName> --size <Size>");
        Console.WriteLine();
        Console.WriteLine("Options:");
        Console.WriteLine("  --algorithm, -a   Specifies the algorithm to use for file generation.");
        Console.WriteLine("  --size, -s        Specifies the size of the file (e.g., 1GB, 500MB, 100KB).");
        Console.WriteLine("  --help, -h        Displays this help message.");
    }
}