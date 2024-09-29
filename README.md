# Big files utils

## Benchmark Results


<!-- BENCHMARK RESULTS START -->

## Benchmark Results

*Last updated on Sun Sep 29 09:15:44 UTC 2024 UTC*

```

BenchmarkDotNet v0.14.0, Ubuntu 22.04.5 LTS (Jammy Jellyfish)
AMD EPYC 7763, 1 CPU, 2 logical cores and 1 physical core
.NET SDK 8.0.402
  [Host]     : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  Job-BZTBEP : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Server=True  InvocationCount=3  IterationCount=3  
LaunchCount=5  UnrollFactor=1  WarmupCount=2  

```
| Method       | FileSizeInBytes | Generator    | FileSize | Mean     | Error    | StdDev   | StdErr   | Median   | Min      | Max      | Q1       | Q3       | Op/s      | Rank | Allocated |
|------------- |---------------- |------------- |--------- |---------:|---------:|---------:|---------:|---------:|---------:|---------:|---------:|---------:|----------:|-----:|----------:|
| GenerateFile | 1.00 GB         | Original     | ?        | 0.0020 s | 0.0010 s | 0.0009 s | 0.0002 s | 0.0019 s | 0.0011 s | 0.0036 s | 0.0012 s | 0.0027 s |     488.3 |    5 |   1.59 MB |
| GenerateFile | 1.00 GB         | Buffered     | ?        | 0.0020 s | 0.0007 s | 0.0007 s | 0.0002 s | 0.0018 s | 0.0010 s | 0.0036 s | 0.0015 s | 0.0024 s |     508.3 |    5 |   2.41 MB |
| GenerateFile | 1.00 GB         | Parallel     | ?        | 0.0000 s | 0.0000 s | 0.0000 s | 0.0000 s | 0.0000 s | 0.0000 s | 0.0001 s | 0.0000 s | 0.0000 s |  36,554.7 |    2 |   0.34 MB |
| GenerateFile | 1.00 GB         | MemoryMapped | ?        | 0.0000 s | 0.0000 s | 0.0000 s | 0.0000 s | 0.0000 s | 0.0000 s | 0.0001 s | 0.0000 s | 0.0000 s | 104,350.6 |    1 |   0.93 MB |
| GenerateFile | 100.00 MB       | Original     | ?        | 0.0021 s | 0.0007 s | 0.0006 s | 0.0002 s | 0.0019 s | 0.0012 s | 0.0033 s | 0.0015 s | 0.0026 s |     484.0 |    5 |   1.58 MB |
| GenerateFile | 100.00 MB       | Buffered     | ?        | 0.0021 s | 0.0019 s | 0.0018 s | 0.0005 s | 0.0017 s | 0.0009 s | 0.0081 s | 0.0010 s | 0.0021 s |     483.9 |    5 |   2.84 MB |
| GenerateFile | 100.00 MB       | Parallel     | ?        | 0.0000 s | 0.0000 s | 0.0000 s | 0.0000 s | 0.0000 s | 0.0000 s | 0.0001 s | 0.0000 s | 0.0000 s |  41,002.0 |    2 |   0.38 MB |
| GenerateFile | 100.00 MB       | MemoryMapped | ?        | 0.0000 s | 0.0000 s | 0.0000 s | 0.0000 s | 0.0000 s | 0.0000 s | 0.0001 s | 0.0000 s | 0.0000 s |  70,899.7 |    1 |   0.02 MB |
| GenerateFile | 500.00 MB       | Original     | ?        | 0.0024 s | 0.0011 s | 0.0010 s | 0.0003 s | 0.0019 s | 0.0011 s | 0.0043 s | 0.0018 s | 0.0027 s |     423.4 |    6 |   2.23 MB |
| GenerateFile | 500.00 MB       | Buffered     | ?        | 0.0016 s | 0.0005 s | 0.0005 s | 0.0001 s | 0.0016 s | 0.0010 s | 0.0027 s | 0.0012 s | 0.0020 s |     615.0 |    5 |    1.3 MB |
| GenerateFile | 500.00 MB       | Parallel     | ?        | 0.0000 s | 0.0001 s | 0.0001 s | 0.0000 s | 0.0000 s | 0.0000 s | 0.0002 s | 0.0000 s | 0.0000 s |  28,521.6 |    4 |   0.75 MB |
| GenerateFile | 500.00 MB       | MemoryMapped | ?        | 0.0000 s | 0.0001 s | 0.0001 s | 0.0000 s | 0.0000 s | 0.0000 s | 0.0003 s | 0.0000 s | 0.0000 s |  32,553.9 |    3 |   0.84 MB |

### Performance Barplot
![Benchmark Barplot](docs/BigFilesUtils.Benchmark.FileGeneratorBenchmark-barplot.png)

### Measurement Overhead Plot
![Measurement Overhead Plot](docs/*-measurement.png)

### Distribution Plot
![Distribution Plot](docs/*-distribution.png)

<!-- BENCHMARK RESULTS END -->
