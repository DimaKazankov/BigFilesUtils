namespace BigFilesUtils.Domain.FileGenerator;

public interface IFileGenerator
{
    Task GenerateFileAsync(string filePath, long fileSizeInBytes);
}