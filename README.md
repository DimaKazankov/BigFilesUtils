# Big files utils

## Benchmark Results


<!-- BENCHMARK RESULTS START -->

## Benchmark Results

*Last updated on Sun Sep 29 05:34:30 UTC 2024 UTC*

```

BenchmarkDotNet v0.14.0, Ubuntu 22.04.5 LTS (Jammy Jellyfish)
AMD EPYC 7763, 1 CPU, 2 logical cores and 1 physical core
.NET SDK 8.0.402
  [Host]     : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  Job-VJMSUO : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Server=True  InvocationCount=3  IterationCount=3  
LaunchCount=5  UnrollFactor=1  WarmupCount=2  

```
| Method       | FileSizeInBytes | Generator    | FileSize | Mean      | Error     | StdDev    | StdErr    | Median    | Min       | Max       | Rank | Allocated |
|------------- |---------------- |------------- |--------- |----------:|----------:|----------:|----------:|----------:|----------:|----------:|-----:|----------:|
| GenerateFile | 100.00 MB       | Parallel     | ?        | 0.0188 ms | 0.0065 ms | 0.0061 ms | 0.0016 ms | 0.0176 ms | 0.0095 ms | 0.0294 ms |    1 |   0.49 MB |
| GenerateFile | 100.00 MB       | MemoryMapped | ?        | 0.0299 ms | 0.0876 ms | 0.0820 ms | 0.0212 ms | 0.0046 ms | 0.0022 ms | 0.3182 ms |    2 |   0.24 MB |
| GenerateFile | 100.00 MB       | Original     | ?        | 1.7044 ms | 0.6072 ms | 0.5680 ms | 0.1467 ms | 1.7890 ms | 1.0986 ms | 2.5924 ms |    3 |   1.32 MB |
| GenerateFile | 100.00 MB       | Buffered     | ?        | 1.7663 ms | 0.6426 ms | 0.6010 ms | 0.1552 ms | 1.7535 ms | 0.9025 ms | 3.0175 ms |    3 |   1.69 MB |

### Performance Barplot
![Benchmark Barplot](docs/BigFilesUtils.Benchmark.FileGeneratorBenchmark-barplot.png)

### Measurement Overhead Plot
![Measurement Overhead Plot](docs/*-measurement.png)

### Distribution Plot
![Distribution Plot](docs/*-distribution.png)

<!-- BENCHMARK RESULTS END -->
