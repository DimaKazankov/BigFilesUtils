namespace BigFilesUtils.Benchmark;

public readonly struct FileSize(long bytes)
{
    public long Bytes { get; } = bytes;

    public override string ToString()
    {
        const double GB = 1024 * 1024 * 1024;
        const double MB = 1024 * 1024;
        const double KB = 1024;

        return Bytes >= GB ? $"{Bytes / GB:F2} GB" :
            Bytes >= MB ? $"{Bytes / MB:F2} MB" :
            Bytes >= KB ? $"{Bytes / KB:F2} KB" : $"{Bytes} B";
    }
}