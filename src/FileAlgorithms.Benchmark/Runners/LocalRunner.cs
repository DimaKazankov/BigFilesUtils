using FileAlgorithms.Generator.Algorithms;
using FileAlgorithms.Sorter;
using FileAlgorithms.Sorter.Algorithms.Memory;

namespace FileAlgorithms.Benchmark.Runners;

public class LocalRunner
{
    public static async Task RunLocalOperations(string[] args)
    {
        var size = "1GB";
        var fileSizeInBytes = 1L * 1024 * 1024 * 1024; // Default 1 GB
        var runGenerators = true;
        var runSorters = true;

        for (var i = 0; i < args.Length; i++)
        {
            switch (args[i].ToLower())
            {
                case "--size":
                case "-s":
                    fileSizeInBytes = ConsoleWriter.Execute(args, i, DataConverter.ToFileSize);
                    break;
                case "--sort":
                    runGenerators = false;
                    runSorters = true;
                    break;
                case "--generator":
                    runGenerators = true;
                    runSorters = false;
                    break;
                case "--all":
                    runGenerators = true;
                    runSorters = true;
                    break;
                case "--help":
                case "-h":
                    ConsoleWriter.ShowUsage();
                    return;
            }
        }

        if (runGenerators)
        {
            await ConsoleWriter.WrapAlgorithmExecution(
                ["Original", "Buffered", "Parallel", "MemoryMapped"],
                fileSizeInBytes,
                async algorithm =>
                {
                    var sizeLabel = fileSizeInBytes.ToFileSizeLabel();
                    var fileName = $"{sizeLabel}_{algorithm}_file.txt";
                    await GenerateForAlgorithm(fileSizeInBytes, fileName, algorithm);
                });
        }

        if (runSorters)
        {
            var inputFileName = $"{Guid.NewGuid()}_Original_file.txt";
            await GenerateForAlgorithm(fileSizeInBytes, inputFileName, "Buffered");

            await ConsoleWriter.WrapAlgorithmExecution(
                ["ExternalMerge", "KWayMerge", "ParallelSorter", "MemoryMappedSorter"],
                fileSizeInBytes,
                async algorithm => await SortForAlgorithm(algorithm, inputFileName));
        }
    }

    private static async Task SortForAlgorithm(string algorithm, string inputFileName)
    {
        var fileSorter = FileSorterFactory.GetFileSorter(algorithm, new QuickSorter());
        var outputFileName = $"sorted_{inputFileName}";
        await fileSorter.SortFileAsync(inputFileName, outputFileName);
    }

    private static async Task GenerateForAlgorithm(long fileSizeInBytes, string fileName, string algorithm)
    {
        var fileGenerator = FileGeneratorFactory.GetFileGenerator(algorithm);
        await fileGenerator.GenerateFileAsync(fileName, fileSizeInBytes);
    }
}