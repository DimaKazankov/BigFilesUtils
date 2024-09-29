# Big files utils

## Benchmark Results


<!-- BENCHMARK RESULTS START -->

## Benchmark Results

*Last updated on Sun Sep 29 12:05:56 UTC 2024 UTC*

```

BenchmarkDotNet v0.14.0, Ubuntu 22.04.5 LTS (Jammy Jellyfish)
AMD EPYC 7763, 1 CPU, 2 logical cores and 1 physical core
.NET SDK 8.0.402
  [Host]     : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  Job-NKBLOI : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Server=True  InvocationCount=3  IterationCount=3  
LaunchCount=5  UnrollFactor=1  WarmupCount=2  

```
| Method       | FileSizeInBytes | Generator    | FileSize | Mean      | Error    | StdDev   | StdErr   | Min      | Max       | Median    | Q1       | Q3        | Op/s   | Rank | Gen0        | Gen1        | Gen2        | Allocated  |
|------------- |---------------- |------------- |--------- |----------:|---------:|---------:|---------:|---------:|----------:|----------:|---------:|----------:|-------:|-----:|------------:|------------:|------------:|-----------:|
| GenerateFile | 1.00 GB         | Original     | ?        |  8.6460 s | 0.3693 s | 0.3454 s | 0.0892 s | 8.0517 s |  9.1652 s |  8.5570 s | 8.4111 s |  8.9216 s | 0.1157 |    5 |  19000.0000 |           - |           - | 5992.19 MB |
| GenerateFile | 1.00 GB         | Buffered     | ?        |  9.0958 s | 0.3536 s | 0.3308 s | 0.0854 s | 8.5630 s |  9.6118 s |  9.1639 s | 8.8221 s |  9.3574 s | 0.1099 |    5 | 417333.3333 | 417333.3333 | 417333.3333 | 5122.35 MB |
| GenerateFile | 1.00 GB         | Parallel     | ?        |  9.5307 s | 0.6131 s | 0.5735 s | 0.1481 s | 8.6362 s | 10.8499 s |  9.5743 s | 9.1070 s |  9.8392 s | 0.1049 |    5 |  11666.6667 |   3333.3333 |   2000.0000 | 3712.81 MB |
| GenerateFile | 1.00 GB         | MemoryMapped | ?        | 10.1257 s | 0.1566 s | 0.1465 s | 0.0378 s | 9.9288 s | 10.3881 s | 10.0987 s | 9.9817 s | 10.2265 s | 0.0988 |    5 |  25666.6667 |           - |           - | 8115.34 MB |
| GenerateFile | 100.00 MB       | Original     | ?        |  0.8331 s | 0.0260 s | 0.0244 s | 0.0063 s | 0.7812 s |  0.8718 s |  0.8365 s | 0.8173 s |  0.8479 s | 1.2004 |    2 |   1666.6667 |           - |           - |  585.46 MB |
| GenerateFile | 100.00 MB       | Buffered     | ?        |  0.8500 s | 0.0159 s | 0.0149 s | 0.0038 s | 0.8283 s |  0.8785 s |  0.8468 s | 0.8389 s |  0.8613 s | 1.1764 |    2 |  40666.6667 |  40666.6667 |  40666.6667 |  500.78 MB |
| GenerateFile | 100.00 MB       | Parallel     | ?        |  0.6970 s | 0.0375 s | 0.0351 s | 0.0091 s | 0.6232 s |  0.7475 s |  0.7025 s | 0.6769 s |  0.7212 s | 1.4347 |    1 |   1333.3333 |   1000.0000 |    666.6667 |   364.4 MB |
| GenerateFile | 100.00 MB       | MemoryMapped | ?        |  0.9063 s | 0.0273 s | 0.0255 s | 0.0066 s | 0.8775 s |  0.9817 s |  0.8950 s | 0.8941 s |  0.9108 s | 1.1034 |    3 |   2333.3333 |           - |           - |  792.53 MB |
| GenerateFile | 500.00 MB       | Original     | ?        |  5.4140 s | 0.1120 s | 0.1048 s | 0.0271 s | 5.1821 s |  5.5781 s |  5.3952 s | 5.3574 s |  5.4707 s | 0.1847 |    4 |   9000.0000 |           - |           - | 2926.04 MB |
| GenerateFile | 500.00 MB       | Buffered     | ?        |  5.4383 s | 0.1299 s | 0.1215 s | 0.0314 s | 5.1958 s |  5.6025 s |  5.4470 s | 5.3900 s |  5.5414 s | 0.1839 |    4 | 204666.6667 | 204666.6667 | 204666.6667 | 2501.46 MB |
| GenerateFile | 500.00 MB       | Parallel     | ?        |  5.3126 s | 0.1565 s | 0.1464 s | 0.0378 s | 5.1372 s |  5.6537 s |  5.2432 s | 5.2252 s |  5.3883 s | 0.1882 |    4 |   7333.3333 |   4666.6667 |   2666.6667 | 1820.56 MB |
| GenerateFile | 500.00 MB       | MemoryMapped | ?        |  5.6208 s | 0.1724 s | 0.1612 s | 0.0416 s | 5.1841 s |  5.8446 s |  5.5972 s | 5.5581 s |  5.7009 s | 0.1779 |    4 |  12333.3333 |           - |           - | 3962.74 MB |

### Performance Barplot
![Benchmark Barplot](docs/BigFilesUtils.Benchmark.FileGeneratorBenchmark-barplot.png)

### Measurement Overhead Plot
![Measurement Overhead Plot](docs/*-measurement.png)

### Distribution Plot
![Distribution Plot](docs/*-distribution.png)

<!-- BENCHMARK RESULTS END -->
