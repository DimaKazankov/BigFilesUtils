using BigFilesUtils.Benchmark;

namespace BigFilesUtils.Runners;

public static class DataConverter
{
    public static long ToFileSize(this string sizeStr)
    {
        sizeStr = sizeStr.Trim().ToUpper();
        if (sizeStr.EndsWith("GB"))
        {
            if (double.TryParse(sizeStr.Replace("GB", ""), out var gb))
                return (long)(gb * 1024 * 1024 * 1024);
        }
        else if (sizeStr.EndsWith("MB"))
        {
            if (double.TryParse(sizeStr.Replace("MB", ""), out var mb))
                return (long)(mb * 1024 * 1024);
        }
        else if (sizeStr.EndsWith("KB"))
        {
            if (double.TryParse(sizeStr.Replace("KB", ""), out var kb))
                return (long)(kb * 1024);
        }
        else if (sizeStr.EndsWith("B"))
        {
            if (double.TryParse(sizeStr.Replace("B", ""), out var b))
                return (long)b;
        }

        throw new ArgumentException("Invalid file size format. Use B, KB, MB, or GB (e.g., 1GB, 500MB).");
    }
    
    public static string ToElapsedTimeString(this TimeSpan elapsed)
    {
        return elapsed.TotalMinutes >= 1 ? $"{elapsed.TotalMinutes:F2} minutes" :
            elapsed.TotalSeconds >= 1 ? $"{elapsed.TotalSeconds:F2} seconds" :
            $"{elapsed.TotalMilliseconds:F2} milliseconds";
    }

    

    public static string ToFileSizeLabel(this long bytes) => new FileSize(bytes).ToString();
}