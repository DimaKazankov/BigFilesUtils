namespace FileAlgorithms.Sorter.Algorithms.IO;

public interface IFileSorter
{
    Task SortFileAsync(string inputFilePath, string outputFilePath);
}