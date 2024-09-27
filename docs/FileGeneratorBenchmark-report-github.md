```

BenchmarkDotNet v0.14.0, Ubuntu 22.04.5 LTS (Jammy Jellyfish)
AMD EPYC 7763, 1 CPU, 2 logical cores and 1 physical core
.NET SDK 8.0.402
  [Host]   : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  ShortRun : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Job=ShortRun  Server=True  IterationCount=3  
LaunchCount=1  WarmupCount=3  

```
| Method       | FileSizeInBytes | Mean      | Error     | StdDev   | Min       | Max       | Q1        | Q3        | Median    | Gen0        | Gen1    | Gen2    | Allocated |
|------------- |---------------- |----------:|----------:|---------:|----------:|----------:|----------:|----------:|----------:|------------:|--------:|--------:|----------:|
| GenerateFile | 1.00 MB         |  0.0074 s |  0.0016 s | 0.0001 s |  0.0073 s |  0.0075 s |  0.0073 s |  0.0074 s |  0.0074 s |     46.8750 | 46.8750 | 46.8750 |   0.01 GB |
| GenerateFile | 100.00 MB       |  0.7004 s |  0.1982 s | 0.0109 s |  0.6879 s |  0.7071 s |  0.6971 s |  0.7067 s |  0.7063 s |   1000.0000 |       - |       - |   0.57 GB |
| GenerateFile | 1.00 GB         |  7.5260 s |  9.8369 s | 0.5392 s |  7.1414 s |  8.1423 s |  7.2178 s |  7.7183 s |  7.2942 s |  18000.0000 |       - |       - |   5.85 GB |
| GenerateFile | 10.00 GB        | 61.8924 s | 61.2775 s | 3.3588 s | 58.0374 s | 64.1887 s | 60.7442 s | 63.8199 s | 63.4510 s | 190000.0000 |       - |       - |  58.47 GB |
