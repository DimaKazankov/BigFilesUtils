namespace FileAlgorithms.Sorter;

public enum SorterMethod
{
    ExternalMerge,
    KWayMerge,
    Parallel,
    MemoryMapped,
    ChunkedMemoryMapped,
}