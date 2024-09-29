namespace BigFilesUtils.Domain.FileGenerator;

public static class FileGeneratorFactory
{
    private static readonly string[] SampleStrings = ["Apple", "Banana is yellow", "Cherry is the best", "Something something something"];
    
    public static IFileGenerator GetFileGenerator(GeneratorType generator)
    {
        return generator switch
        {
            GeneratorType.Original => new FileGenerator(SampleStrings),
            GeneratorType.Buffered => new FileGeneratorBuffered(SampleStrings),
            GeneratorType.Parallel => new FileGeneratorParallel(SampleStrings),
            GeneratorType.MemoryMapped => new FileGeneratorMemoryMapped(SampleStrings),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public static IFileGenerator GetFileGenerator(string algorithm)
    {
        return algorithm.ToLower() switch
        {
            "original" => new FileGenerator(SampleStrings),
            "buffered" => new FileGeneratorBuffered(SampleStrings),
            "parallel" => new FileGeneratorParallel(SampleStrings),
            "memorymapped" => new FileGeneratorMemoryMapped(SampleStrings),
            _ => new FileGenerator(SampleStrings)
        };
    }
}