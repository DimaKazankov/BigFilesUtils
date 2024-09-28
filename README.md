# Big files utils

## Benchmark Results


<!-- BENCHMARK RESULTS START -->

*Last updated on Sat Sep 28 05:45:50 UTC 2024 UTC*

```

BenchmarkDotNet v0.14.0, Ubuntu 22.04.5 LTS (Jammy Jellyfish)
AMD EPYC 7763, 1 CPU, 2 logical cores and 1 physical core
.NET SDK 8.0.402
  [Host] : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Job=ShortRun  Server=True  IterationCount=3  
LaunchCount=1  WarmupCount=3  

```
| Method       | FileSizeInBytes | Mean | Error | StdDev | Min | Max | Q1 | Q3 | Median |
|------------- |---------------- |-----:|------:|-------:|----:|----:|---:|---:|-------:|
| GenerateFile | 102400          |   NA |    NA |     NA |  NA |  NA | NA | NA |     NA |

Benchmarks with issues:
  FileGeneratorBenchmark.GenerateFile: ShortRun(Server=True, IterationCount=3, LaunchCount=1, WarmupCount=3) [FileSizeInBytes=102400]

![Benchmark Barplot](docs/FileGeneratorBenchmark-barplot.png)

<!-- BENCHMARK RESULTS END -->
