# Big files utils

## Benchmark Results


<!-- BENCHMARK RESULTS START -->

*Last updated on Sat Sep 28 08:50:45 UTC 2024 UTC*

```

BenchmarkDotNet v0.14.0, Ubuntu 22.04.5 LTS (Jammy Jellyfish)
AMD EPYC 7763, 1 CPU, 2 logical cores and 1 physical core
.NET SDK 8.0.402
  [Host]   : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  ShortRun : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Job=ShortRun  Server=True  IterationCount=3  
LaunchCount=1  WarmupCount=3  

```
| Method       | FileSizeInBytes | Mean         | Error        | StdDev      | Min           | Max          | Q1            | Q3           | Median       | Gen0       | Gen1    | Gen2    | Allocated    |
|------------- |---------------- |-------------:|-------------:|------------:|--------------:|-------------:|--------------:|-------------:|-------------:|-----------:|--------:|--------:|-------------:|
| **GenerateFile** | **1.00 GB**         | **7,555.746 ms** | **7,277.375 ms** | **398.8975 ms** | **7,273.1457 ms** | **8,012.041 ms** | **7,327.5979 ms** | **7,697.046 ms** | **7,382.050 ms** | **19000.0000** |       **-** |       **-** |   **6131489 KB** |
| **GenerateFile** | **100.00 KB**       |     **1.029 ms** |     **1.480 ms** |   **0.0811 ms** |     **0.9591 ms** |     **1.118 ms** |     **0.9842 ms** |     **1.064 ms** |     **1.009 ms** |    **64.4531** | **64.4531** | **64.4531** |    **909.83 KB** |
| **GenerateFile** | **100.00 MB**       |   **711.084 ms** |   **217.278 ms** |  **11.9098 ms** |   **701.0336 ms** |   **724.239 ms** |   **704.5073 ms** |   **716.110 ms** |   **707.981 ms** |  **1000.0000** |       **-** |       **-** | **599064.73 KB** |

![Benchmark Barplot](docs/FileGeneratorBenchmark-barplot.png)

<!-- BENCHMARK RESULTS END -->
