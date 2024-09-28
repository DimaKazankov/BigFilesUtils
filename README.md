# Big files utils

## Benchmark Results


<!-- BENCHMARK RESULTS START -->

*Last updated on Sat Sep 28 09:41:06 UTC 2024 UTC*

```

BenchmarkDotNet v0.14.0, Ubuntu 22.04.5 LTS (Jammy Jellyfish)
AMD EPYC 7763, 1 CPU, 2 logical cores and 1 physical core
.NET SDK 8.0.402
  [Host]   : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  ShortRun : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Job=ShortRun  Server=True  IterationCount=3  
LaunchCount=1  WarmupCount=3  

```
| Method       | FileSizeInBytes | Mean     | Error    | StdDev   | Min      | Max      | Q1       | Q3       | Median   | Gen0       | Gen1    | Gen2    | Allocated |
|------------- |---------------- |---------:|---------:|---------:|---------:|---------:|---------:|---------:|---------:|-----------:|--------:|--------:|----------:|
| GenerateFile | 1.00 MB         | 0.0074 s | 0.0035 s | 0.0002 s | 0.0072 s | 0.0076 s | 0.0073 s | 0.0075 s | 0.0074 s |    62.5000 | 62.5000 | 62.5000 |   0.01 GB |
| GenerateFile | 100.00 MB       | 0.7255 s | 0.2573 s | 0.0141 s | 0.7102 s | 0.7380 s | 0.7192 s | 0.7331 s | 0.7282 s |  1000.0000 |       - |       - |   0.57 GB |
| GenerateFile | 1.00 GB         | 7.4999 s | 8.1040 s | 0.4442 s | 7.1572 s | 8.0018 s | 7.2490 s | 7.6713 s | 7.3408 s | 19000.0000 |       - |       - |   5.85 GB |

![Benchmark Barplot](docs/BigFilesUtils.Benchmark.FileGeneratorBenchmark-barplot.png)

<!-- BENCHMARK RESULTS END -->
