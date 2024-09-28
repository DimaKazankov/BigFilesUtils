# Big files utils

## Benchmark Results


<!-- BENCHMARK RESULTS START -->

*Last updated on Sat Sep 28 10:07:03 UTC 2024 UTC*

```

BenchmarkDotNet v0.14.0, Ubuntu 22.04.5 LTS (Jammy Jellyfish)
AMD EPYC 7763, 1 CPU, 2 logical cores and 1 physical core
.NET SDK 8.0.402
  [Host]   : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  ShortRun : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Job=ShortRun  Server=True  IterationCount=3  
LaunchCount=1  WarmupCount=3  

```
| Method       | FileSizeInBytes | Mean     | Error     | StdDev   | Min      | Max      | Q1       | Q3       | Median   | Gen0       | Gen1    | Gen2    | Allocated |
|------------- |---------------- |---------:|----------:|---------:|---------:|---------:|---------:|---------:|---------:|-----------:|--------:|--------:|----------:|
| GenerateFile | 1.00 MB         | 0.0075 s |  0.0048 s | 0.0003 s | 0.0073 s | 0.0078 s | 0.0074 s | 0.0077 s | 0.0075 s |    46.8750 | 46.8750 | 46.8750 |   0.01 GB |
| GenerateFile | 100.00 MB       | 0.7294 s |  0.1260 s | 0.0069 s | 0.7215 s | 0.7335 s | 0.7274 s | 0.7334 s | 0.7333 s |  1000.0000 |       - |       - |   0.57 GB |
| GenerateFile | 1.00 GB         | 7.5758 s | 10.9707 s | 0.6013 s | 7.1490 s | 8.2635 s | 7.2319 s | 7.7892 s | 7.3148 s | 19000.0000 |       - |       - |   5.85 GB |

![Benchmark Barplot](docs/BigFilesUtils.Benchmark.FileGeneratorBenchmark-barplot.png)

<!-- BENCHMARK RESULTS END -->
