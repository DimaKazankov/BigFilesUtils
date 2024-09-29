using System.Diagnostics;
using System.Reflection;
using BenchmarkDotNet.Running;
using BigFilesUtils.Domain.FileGenerator;

namespace BigFilesUtils;

public class Program
{
    static async Task  Main(string[] args)
    {
        if (args.Contains("--algorithm") || args.Contains("-a") ||
            args.Contains("--size") || args.Contains("-s") ||
            args.Contains("--help") || args.Contains("-h"))
        {
            await RunFileGeneration(args);
        }
        else
        {
            RunBenchmarks();
        }
    }

    static void RunBenchmarks()
    {
        BenchmarkRunner.Run(Assembly.GetExecutingAssembly());
    }

    static async Task RunFileGeneration(string[] args)
    {
        var algorithm = "Default";
        var sizeInput = "1GB"; // Default size
        var fileSizeInBytes = 1L * 1024 * 1024 * 1024; // 1 GB

        // Parse arguments
        for (var i = 0; i < args.Length; i++)
        {
            switch (args[i].ToLower())
            {
                case "--algorithm":
                case "-a":
                    if (i + 1 < args.Length)
                        algorithm = args[++i];
                    else
                    {
                        Console.WriteLine("Error: --algorithm requires a value.");
                        ShowUsage();
                        return;
                    }
                    break;

                case "--size":
                case "-s":
                    if (i + 1 < args.Length)
                    {
                        sizeInput = args[++i];
                        try
                        {
                            fileSizeInBytes = ParseFileSize(sizeInput);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                            ShowUsage();
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: --size requires a value.");
                        ShowUsage();
                        return;
                    }
                    break;

                case "--help":
                case "-h":
                    ShowUsage();
                    return;

                default:
                    Console.WriteLine($"Unknown argument: {args[i]}");
                    ShowUsage();
                    return;
            }
        }

        // Instantiate and run file generation
        IFileGenerator fileGenerator = new FileGenerator();
        var sizeLabel = GetSizeLabel(fileSizeInBytes);
        var fileName = $"{sizeLabel}_{algorithm}_file_generator_benchmark.txt";
        
        
        Console.WriteLine($"Starting file generation: Algorithm = {algorithm}, Size = {sizeLabel}");

        // Initialize Stopwatch to measure duration
        var stopwatch = Stopwatch.StartNew();

        try
        {
            switch (algorithm)
            {
                case "Original":
                    fileGenerator = new FileGenerator();
                    break;
                case "Buffered":
                    fileGenerator = new FileGeneratorBuffered();
                    break;
                case "Parallel":
                    fileGenerator = new FileGeneratorParallel();
                    break;
                case "MemoryMapped":
                    fileGenerator = new FileGeneratorMemoryMapped();
                    break;
            }
            await fileGenerator.GenerateFileAsync(fileName, fileSizeInBytes);
            stopwatch.Stop();
            Console.WriteLine($"File generated successfully: {fileName}");
            Console.WriteLine($"File generation completed in {FormatElapsedTime(stopwatch.Elapsed)}.");
        }
        catch (Exception ex)
        {
            stopwatch.Stop();
            Console.WriteLine($"Error during file generation: {ex.Message}");
            Console.WriteLine($"File generation failed after {FormatElapsedTime(stopwatch.Elapsed)}.");
        }
    }
    
    static string FormatElapsedTime(TimeSpan elapsed)
    {
        return elapsed.TotalMinutes >= 1 ? $"{elapsed.TotalMinutes:F2} minutes" :
            elapsed.TotalSeconds >= 1 ? $"{elapsed.TotalSeconds:F2} seconds" :
            $"{elapsed.TotalMilliseconds:F2} milliseconds";
    }

    static long ParseFileSize(string sizeStr)
    {
        sizeStr = sizeStr.Trim().ToUpper();
        if (sizeStr.EndsWith("GB"))
        {
            if (double.TryParse(sizeStr.Replace("GB", ""), out var gb))
                return (long)(gb * 1024 * 1024 * 1024);
        }
        else if (sizeStr.EndsWith("MB"))
        {
            if (double.TryParse(sizeStr.Replace("MB", ""), out var mb))
                return (long)(mb * 1024 * 1024);
        }
        else if (sizeStr.EndsWith("KB"))
        {
            if (double.TryParse(sizeStr.Replace("KB", ""), out var kb))
                return (long)(kb * 1024);
        }
        else if (sizeStr.EndsWith("B"))
        {
            if (double.TryParse(sizeStr.Replace("B", ""), out var b))
                return (long)b;
        }

        throw new ArgumentException("Invalid file size format. Use B, KB, MB, or GB (e.g., 1GB, 500MB).");
    }

    static string GetSizeLabel(long bytes)
    {
        const double GB = 1024 * 1024 * 1024;
        const double MB = 1024 * 1024;
        const double KB = 1024;

        return bytes >= GB ? $"{bytes / GB:F2}GB" :
            bytes >= MB ? $"{bytes / MB:F2}MB" :
            bytes >= KB ? $"{bytes / KB:F2}KB" : $"{bytes}B";
    }

    static void ShowUsage()
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