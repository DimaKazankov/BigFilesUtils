namespace BigFilesUtils.Domain.FileSorter;

public static class FileSorterFactory
{
    public static IFileSorter GetFileSorter(SorterType sorterType)
    {
        return sorterType switch
        {
            SorterType.ExternalMerge => new ExternalMergeSorter(),
            SorterType.KWayMerge => new KWayMergeSorter(),
            SorterType.Parallel => new ParallelExternalSorter(),
            SorterType.MemoryMapped => new MemoryMappedSorter(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public static IFileSorter GetFileSorter(string algorithm)
    {
        IFileSorter fileSorter = algorithm.ToLower() switch
        {
            "externalmerge" => new ExternalMergeSorter(),
            "kwaymerge" => new KWayMergeSorter(),
            "parallelsorter" => new ParallelExternalSorter(),
            "memorymappedsorter" => new MemoryMappedSorter(),
            _ => new ExternalMergeSorter()
        };
        return fileSorter;
    }
}