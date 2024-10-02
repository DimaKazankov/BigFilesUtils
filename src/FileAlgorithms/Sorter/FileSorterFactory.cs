using FileAlgorithms.Sorter.Algorithms.IO;
using FileAlgorithms.Sorter.Algorithms.Memory;

namespace FileAlgorithms.Sorter;

public static class FileSorterFactory
{
    public static IFileSorter GetFileSorter(SorterMethod sorterMethod, ISorter sorter)
    {
        return sorterMethod switch
        {
            SorterMethod.ExternalMerge => new ExternalMergeFileSorter(sorter),
            SorterMethod.KWayMerge => new KWayMergeFileSorter(sorter),
            SorterMethod.Parallel => new ParallelExternalFileSorter(sorter),
            SorterMethod.MemoryMapped => new MemoryMappedFileSorter(sorter),
            SorterMethod.ChunkedMemoryMapped => new ChunkedMemoryMappedFileSorter(sorter),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public static IFileSorter GetFileSorter(string algorithm, ISorter sorter)
    {
        IFileSorter fileSorter = algorithm.ToLower() switch
        {
            "externalmerge" => new ExternalMergeFileSorter(sorter),
            "kwaymerge" => new KWayMergeFileSorter(sorter),
            "parallelsorter" => new ParallelExternalFileSorter(sorter),
            "memorymappedsorter" => new MemoryMappedFileSorter(sorter),
            "chunkedmemorymappedsorter" => new ChunkedMemoryMappedFileSorter(sorter),
            _ => throw new ArgumentOutOfRangeException()
        };
        return fileSorter;
    }
}