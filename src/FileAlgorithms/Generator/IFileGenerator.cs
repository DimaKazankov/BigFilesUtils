namespace FileAlgorithms.Generator;

public interface IFileGenerator
{
    Task GenerateFileAsync(string filePath, long fileSizeInBytes);
}