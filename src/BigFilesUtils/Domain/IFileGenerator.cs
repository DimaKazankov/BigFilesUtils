namespace BigFilesUtils.Domain;

public interface IFileGenerator
{
    void GenerateFile(string filePath, long fileSizeInBytes);
}