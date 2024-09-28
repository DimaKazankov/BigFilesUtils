# Big files utils

## Benchmark Results


<!-- BENCHMARK RESULTS START -->

*Last updated on Sat Sep 28 09:05:25 UTC 2024 UTC*

```

BenchmarkDotNet v0.14.0, Ubuntu 22.04.5 LTS (Jammy Jellyfish)
AMD EPYC 7763, 1 CPU, 2 logical cores and 1 physical core
.NET SDK 8.0.402
  [Host]   : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  ShortRun : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Job=ShortRun  Server=True  IterationCount=3  
LaunchCount=1  WarmupCount=3  

```
| Method       | FileSizeInBytes | Mean     | Error    | StdDev   | Min      | Max      | Q1       | Q3       | Median   | Gen0       | Gen1    | Gen2    | Allocated  |
|------------- |---------------- |---------:|---------:|---------:|---------:|---------:|---------:|---------:|---------:|-----------:|--------:|--------:|-----------:|
| GenerateFile | 1.00 GB         | 8.0048 s | 9.3275 s | 0.5113 s | 7.4279 s | 8.4020 s | 7.8062 s | 8.2932 s | 8.1844 s | 19000.0000 |       - |       - | 5987.67 MB |
| GenerateFile | 100.00 KB       | 0.0012 s | 0.0017 s | 0.0001 s | 0.0011 s | 0.0013 s | 0.0011 s | 0.0012 s | 0.0012 s |    64.4531 | 64.4531 | 64.4531 |    0.89 MB |
| GenerateFile | 100.00 MB       | 0.7263 s | 0.1731 s | 0.0095 s | 0.7192 s | 0.7371 s | 0.7209 s | 0.7299 s | 0.7227 s |  1000.0000 |       - |       - |  585.03 MB |

![Benchmark Barplot](docs/FileGeneratorBenchmark-barplot.png)

<!-- BENCHMARK RESULTS END -->
