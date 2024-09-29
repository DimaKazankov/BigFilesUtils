namespace BigFilesUtils.Benchmark;

public readonly struct FileSize(long bytes)
{
    public long Bytes { get; } = bytes;

    public override string ToString()
    {
        const double gb = 1024 * 1024 * 1024;
        const double mb = 1024 * 1024;
        const double kb = 1024;

        return Bytes >= gb ? $"{Bytes / gb:F2} GB" :
            Bytes >= mb ? $"{Bytes / mb:F2} MB" :
            Bytes >= kb ? $"{Bytes / kb:F2} KB" : $"{Bytes} B";
    }
}