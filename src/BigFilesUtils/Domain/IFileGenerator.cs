namespace BigFilesUtils.Domain;

public interface IFileGenerator
{
    Task GenerateFileAsync(string filePath, long fileSizeInBytes);
}