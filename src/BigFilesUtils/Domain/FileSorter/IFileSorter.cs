namespace BigFilesUtils.Domain.FileSorter;

public interface IFileSorter
{
    Task SortFileAsync(string inputFilePath, string outputFilePath);
}