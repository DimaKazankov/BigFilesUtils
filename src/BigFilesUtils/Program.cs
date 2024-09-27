using BigFilesUtils;

if (args.Length != 2)
{
    Console.WriteLine("Usage: FileGenerator <file_path> <file_size_in_bytes>");
    return;
}

var filePath = args[0];
if (!long.TryParse(args[1], out var fileSizeInBytes))
{
    Console.WriteLine("Invalid file size.");
    return;
}

new FileGenerator().GenerateFile(filePath, fileSizeInBytes);
Console.WriteLine("File generated successfully.");