using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using BigFilesUtils.Benchmark;
using BigFilesUtils.Domain.FileGenerator;
using BigFilesUtils.Domain.FileSorter;

namespace BigFilesUtils;

public class Program
{
    static async Task Main(string[] args)
    {
        if (args.Contains("--benchmark") || args.Contains("-b"))
        {
            RunBenchmarks(args);
        }
        else if (args.Contains("--algorithm") || args.Contains("-a") ||
                 args.Contains("--size") || args.Contains("-s") ||
                 args.Contains("--help") || args.Contains("-h"))
        {
            await RunLocalOperations(args);
        }
        else
        {
            Console.WriteLine("Invalid arguments. Use --help or -h for usage information.");
        }
    }

    static void RunBenchmarks(string[] args)
    {
        var config = DefaultConfig.Instance;
            
        if (args.Contains("--generator") || args.Contains("-g"))
        {
            BenchmarkRunner.Run<FileGeneratorBenchmark>(config);
        }
        else if (args.Contains("--sorter") || args.Contains("-sr"))
        {
            BenchmarkRunner.Run<FileSorterBenchmark>(config);
        }
        else
        {
            BenchmarkRunner.Run<FileGeneratorBenchmark>(config);
            BenchmarkRunner.Run<FileSorterBenchmark>(config);
        }
    }

    static async Task RunLocalOperations(string[] args)
    {
        var size = "1GB";
        var fileSizeInBytes = 1L * 1024 * 1024 * 1024; // Default 1 GB
        var runGenerators = true;
        var runSorters = true;
        string? specificAlgorithm = null;

        for (int i = 0; i < args.Length; i++)
        {
            switch (args[i].ToLower())
            {
                case "--size":
                case "-s":
                    if (i + 1 < args.Length)
                    {
                        size = args[++i];
                        fileSizeInBytes = ParseFileSize(size);
                    }
                    else
                    {
                        Console.WriteLine("Error: --size requires a value.");
                        ShowUsage();
                        return;
                    }

                    break;
                case "--sort":
                    runGenerators = false;
                    runSorters = true;
                    break;
                case "--generator":
                    runGenerators = true;
                    runSorters = false;
                    break;
                case "--algorithm":
                case "-a":
                    if (i + 1 < args.Length)
                    {
                        specificAlgorithm = args[++i];
                    }
                    else
                    {
                        Console.WriteLine("Error: --algorithm requires a value.");
                        ShowUsage();
                        return;
                    }

                    break;
                case "--help":
                case "-h":
                    ShowUsage();
                    return;
            }
        }

        if (specificAlgorithm != null)
        {
            await RunFileGenerationAlgorithm(specificAlgorithm, fileSizeInBytes);
        }
        else
        {
            if (runGenerators)
            {
                await RunAllGenerators(fileSizeInBytes);
            }

            if (runSorters)
            {
                await RunAllSorters(fileSizeInBytes);
            }
        }
    }

    static async Task RunAllGenerators(long fileSizeInBytes)
    {
        Console.WriteLine("========== File Generation Algorithms ==========");
        var algorithms = new[] { "Original", "Buffered", "Parallel", "MemoryMapped" };
        foreach (var algorithm in algorithms)
        {
            await RunFileGenerationAlgorithm(algorithm, fileSizeInBytes);
        }

        Console.WriteLine("================================================");
    }

    private static async Task RunFileGenerationAlgorithm(string algorithm, long fileSizeInBytes)
    {
        Console.WriteLine($"[{algorithm}]");
        var sizeLabel = GetSizeLabel(fileSizeInBytes);
        var fileName = $"{sizeLabel}_{algorithm}_file.txt";
        await RunFileGeneration(algorithm, fileName, fileSizeInBytes);
        Console.WriteLine();
    }

    static async Task RunAllSorters(long fileSizeInBytes)
    {
        Console.WriteLine("========== File Sorting Algorithms ==========");
        var algorithms = new[] { "ExternalMerge", "KWayMerge", "ParallelSorter", "MemoryMappedSorter" };
        var sizeLabel = GetSizeLabel(fileSizeInBytes);
        var inputFileName = $"{sizeLabel}_Original_file.txt";

        // Generate a file to sort if it doesn't exist
        if (!File.Exists(inputFileName))
        {
            Console.WriteLine("Generating file for sorting...");
            await RunFileGeneration("Original", inputFileName, fileSizeInBytes);
            Console.WriteLine();
        }

        foreach (var algorithm in algorithms)
        {
            Console.WriteLine($"[{algorithm}]");
            await RunSorting(algorithm, inputFileName, fileSizeInBytes);
            Console.WriteLine();
        }

        Console.WriteLine("=============================================");
    }

    static async Task RunFileGeneration(string algorithm, string fileName, long fileSizeInBytes)
    {
        IFileGenerator fileGenerator = algorithm.ToLower() switch
        {
            "original" => new FileGenerator(),
            "buffered" => new FileGeneratorBuffered(),
            "parallel" => new FileGeneratorParallel(),
            "memorymapped" => new FileGeneratorMemoryMapped(),
            _ => new FileGenerator()
        };

        Console.WriteLine(
            $"Starting file generation: Algorithm = {algorithm}, Size = {GetSizeLabel(fileSizeInBytes)}");
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();

        try
        {
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

    static async Task RunSorting(string algorithm, string fileName, long fileSizeInBytes)
    {
        IFileSorter fileSorter = algorithm.ToLower() switch
        {
            "externalmerge" => new ExternalMergeSorter(),
            "kwaymerge" => new KWayMergeSorter(),
            "parallelsorter" => new ParallelExternalSorter(),
            "memorymappedsorter" => new MemoryMappedSorter(),
            _ => new ExternalMergeSorter()
        };

        var outputFileName = $"sorted_{fileName}";
        Console.WriteLine($"Starting file sorting: Algorithm = {algorithm}, File = {fileName}");
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();

        try
        {
            await fileSorter.SortFileAsync(fileName, outputFileName);
            stopwatch.Stop();
            Console.WriteLine($"File sorted successfully: {outputFileName}");
            Console.WriteLine($"File sorting completed in {FormatElapsedTime(stopwatch.Elapsed)}.");
        }
        catch (Exception ex)
        {
            stopwatch.Stop();
            Console.WriteLine($"Error during file sorting: {ex.Message}");
            Console.WriteLine($"File sorting failed after {FormatElapsedTime(stopwatch.Elapsed)}.");
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