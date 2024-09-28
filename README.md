# Big files utils

## Benchmark Results


<!-- BENCHMARK RESULTS START -->

*Last updated on Sat Sep 28 09:16:40 UTC 2024 UTC*

```

BenchmarkDotNet v0.14.0, Ubuntu 22.04.5 LTS (Jammy Jellyfish)
AMD EPYC 7763, 1 CPU, 2 logical cores and 1 physical core
.NET SDK 8.0.402
  [Host]   : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  ShortRun : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Job=ShortRun  Server=True  IterationCount=3  
LaunchCount=1  WarmupCount=3  

```
| Method       | FileSizeInBytes | Mean         | Error        | StdDev      | Min          | Max          | Q1           | Q3           | Median       | Gen0       | Gen1    | Gen2    | Allocated  |
|------------- |---------------- |-------------:|-------------:|------------:|-------------:|-------------:|-------------:|-------------:|-------------:|-----------:|--------:|--------:|-----------:|
| GenerateFile | 1.00 MB         |     7.433 ms |     2.781 ms |   0.1525 ms |     7.305 ms |     7.601 ms |     7.348 ms |     7.496 ms |     7.391 ms |    78.1250 | 62.5000 | 62.5000 |    6.16 MB |
| GenerateFile | 100.00 MB       |   731.479 ms |   199.810 ms |  10.9523 ms |   720.564 ms |   742.468 ms |   725.984 ms |   736.936 ms |   731.404 ms |  1000.0000 |       - |       - |  585.04 MB |
| GenerateFile | 1.00 GB         | 7,877.197 ms | 1,924.084 ms | 105.4656 ms | 7,786.038 ms | 7,992.709 ms | 7,819.441 ms | 7,922.777 ms | 7,852.845 ms | 19000.0000 |       - |       - | 5987.73 MB |

![Benchmark Barplot](docs/FileGeneratorBenchmark-barplot.png)

<!-- BENCHMARK RESULTS END -->
