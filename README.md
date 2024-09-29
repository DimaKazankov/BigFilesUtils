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
<!-- FILE_GENERATION_RESULTS_START -->
### File Generation Benchmarks

```

BenchmarkDotNet v0.14.0, Ubuntu 22.04.5 LTS (Jammy Jellyfish)
AMD EPYC 7763, 1 CPU, 2 logical cores and 1 physical core
.NET SDK 8.0.402
  [Host]     : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2


```
| Method       | FileSizeInBytes | Generator    | FileSize | Mean     | Error    | StdDev   | StdErr   | Median   | Min      | Q1       | Q3       | Max      | Op/s   | Rank | Gen0        | Gen1        | Gen2        | Allocated  |
|------------- |---------------- |------------- |--------- |---------:|---------:|---------:|---------:|---------:|---------:|---------:|---------:|---------:|-------:|-----:|------------:|------------:|------------:|-----------:|
| **GenerateFile** | **100.00 MB**       | **Original**     | **?**        | **0.8735 s** | **0.0171 s** | **0.0277 s** | **0.0047 s** | **0.8734 s** | **0.8426 s** | **0.8488 s** | **0.8948 s** | **0.9626 s** | **1.1449** |    **2** |   **7000.0000** |           **-** |           **-** |  **585.46 MB** |
| **GenerateFile** | **100.00 MB**       | **Buffered**     | **?**        | **0.7493 s** | **0.0114 s** | **0.0149 s** | **0.0030 s** | **0.7510 s** | **0.7021 s** | **0.7412 s** | **0.7560 s** | **0.7790 s** | **1.3346** |    **1** |  **66000.0000** |  **66000.0000** |  **66000.0000** |  **500.79 MB** |
| **GenerateFile** | **100.00 MB**       | **Parallel**     | **?**        | **0.8326 s** | **0.0299 s** | **0.0814 s** | **0.0088 s** | **0.7971 s** | **0.7289 s** | **0.7899 s** | **0.8486 s** | **1.0442 s** | **1.2011** |    **2** |   **4000.0000** |   **1000.0000** |   **1000.0000** |  **308.26 MB** |
| **GenerateFile** | **100.00 MB**       | **MemoryMapped** | **?**        | **0.8941 s** | **0.0023 s** | **0.0018 s** | **0.0005 s** | **0.8938 s** | **0.8916 s** | **0.8929 s** | **0.8949 s** | **0.8976 s** | **1.1184** |    **2** |   **9000.0000** |           **-** |           **-** |  **792.49 MB** |
| **GenerateFile** | **200.00 MB**       | **Original**     | **?**        | **1.9923 s** | **0.0147 s** | **0.0137 s** | **0.0036 s** | **1.9983 s** | **1.9520 s** | **1.9853 s** | **2.0008 s** | **2.0060 s** | **0.5019** |    **4** |  **14000.0000** |           **-** |           **-** | **1170.67 MB** |
| **GenerateFile** | **200.00 MB**       | **Buffered**     | **?**        | **1.7713 s** | **0.0328 s** | **0.0307 s** | **0.0079 s** | **1.7864 s** | **1.7129 s** | **1.7459 s** | **1.7954 s** | **1.8124 s** | **0.5646** |    **3** | **133000.0000** | **133000.0000** | **133000.0000** | **1000.94 MB** |
| **GenerateFile** | **200.00 MB**       | **Parallel**     | **?**        | **2.2076 s** | **0.0783 s** | **0.2307 s** | **0.0231 s** | **2.2558 s** | **1.8424 s** | **1.9877 s** | **2.4264 s** | **2.6036 s** | **0.4530** |    **4** |   **8000.0000** |   **7000.0000** |   **2000.0000** |  **680.49 MB** |
| **GenerateFile** | **200.00 MB**       | **MemoryMapped** | **?**        | **2.0402 s** | **0.0137 s** | **0.0122 s** | **0.0033 s** | **2.0433 s** | **2.0026 s** | **2.0421 s** | **2.0457 s** | **2.0512 s** | **0.4901** |    **4** |  **19000.0000** |           **-** |           **-** | **1585.15 MB** |

<!-- FILE_GENERATION_RESULTS_END -->
<!-- FILE_SORTING_RESULTS_START -->
### File Sorting Benchmarks

```

BenchmarkDotNet v0.14.0, Ubuntu 22.04.5 LTS (Jammy Jellyfish)
AMD EPYC 7763, 1 CPU, 2 logical cores and 1 physical core
.NET SDK 8.0.402
  [Host]     : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2


```
| Method   | FileSizeInBytes | Sorter        | Generator | FileSize | Mean    | Error   | StdDev  | StdErr  | Min     | Q1      | Median  | Q3      | Max     | Op/s   | Rank | Gen0        | Gen1       | Gen2      | Allocated   |
|--------- |---------------- |-------------- |---------- |--------- |--------:|--------:|--------:|--------:|--------:|--------:|--------:|--------:|--------:|-------:|-----:|------------:|-----------:|----------:|------------:|
| **SortFile** | **100.00 MB**       | **ExternalMerge** | **?**         | **?**        | **18.14 s** | **0.102 s** | **0.090 s** | **0.024 s** | **17.98 s** | **18.09 s** | **18.14 s** | **18.21 s** | **18.32 s** | **0.0551** |    **1** | **254000.0000** | **12000.0000** | **3000.0000** | **20143.67 MB** |
| **SortFile** | **100.00 MB**       | **KWayMerge**     | **?**         | **?**        | **17.78 s** | **0.115 s** | **0.108 s** | **0.028 s** | **17.64 s** | **17.69 s** | **17.76 s** | **17.85 s** | **18.04 s** | **0.0562** |    **1** | **251000.0000** | **11000.0000** | **2000.0000** | **19965.79 MB** |
| **SortFile** | **100.00 MB**       | **Parallel**      | **?**         | **?**        | **18.30 s** | **0.265 s** | **0.248 s** | **0.064 s** | **18.02 s** | **18.11 s** | **18.19 s** | **18.52 s** | **18.81 s** | **0.0546** |    **1** | **255000.0000** | **12000.0000** | **3000.0000** | **20285.98 MB** |
| **SortFile** | **100.00 MB**       | **MemoryMapped**  | **?**         | **?**        |      **NA** |      **NA** |      **NA** |      **NA** |      **NA** |      **NA** |      **NA** |      **NA** |      **NA** |     **NA** |    **?** |          **NA** |         **NA** |        **NA** |          **NA** |
| **SortFile** | **200.00 MB**       | **ExternalMerge** | **?**         | **?**        | **41.02 s** | **0.275 s** | **0.257 s** | **0.066 s** | **40.60 s** | **40.82 s** | **41.08 s** | **41.20 s** | **41.42 s** | **0.0244** |    **3** | **508000.0000** | **24000.0000** | **5000.0000** | **40228.68 MB** |
| **SortFile** | **200.00 MB**       | **KWayMerge**     | **?**         | **?**        | **41.50 s** | **0.316 s** | **0.280 s** | **0.075 s** | **40.92 s** | **41.52 s** | **41.61 s** | **41.65 s** | **41.80 s** | **0.0241** |    **3** | **505000.0000** | **22000.0000** | **3000.0000** | **40218.93 MB** |
| **SortFile** | **200.00 MB**       | **Parallel**      | **?**         | **?**        | **34.76 s** | **0.301 s** | **0.281 s** | **0.073 s** | **34.34 s** | **34.53 s** | **34.76 s** | **34.98 s** | **35.20 s** | **0.0288** |    **2** | **509000.0000** | **31000.0000** | **3000.0000** | **40502.52 MB** |
| **SortFile** | **200.00 MB**       | **MemoryMapped**  | **?**         | **?**        |      **NA** |      **NA** |      **NA** |      **NA** |      **NA** |      **NA** |      **NA** |      **NA** |      **NA** |     **NA** |    **?** |          **NA** |         **NA** |        **NA** |          **NA** |

Benchmarks with issues:
  FileSorterBenchmark.SortFile: DefaultJob [FileSizeInBytes=100.00 MB, Sorter=MemoryMapped]
  FileSorterBenchmark.SortFile: DefaultJob [FileSizeInBytes=200.00 MB, Sorter=MemoryMapped]

<!-- FILE_SORTING_RESULTS_END -->
![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=100.00 MB&Sorter=ExternalMerge-cummean.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=100.00 MB&Sorter=ExternalMerge-density.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=100.00 MB&Sorter=ExternalMerge-timeline.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=100.00 MB&Sorter=ExternalMerge-timelineSmooth.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=100.00 MB&Sorter=KWayMerge-cummean.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=100.00 MB&Sorter=KWayMerge-density.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=100.00 MB&Sorter=KWayMerge-timeline.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=100.00 MB&Sorter=KWayMerge-timelineSmooth.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=100.00 MB&Sorter=Parallel-cummean.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=100.00 MB&Sorter=Parallel-density.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=100.00 MB&Sorter=Parallel-timeline.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=100.00 MB&Sorter=Parallel-timelineSmooth.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=200.00 MB&Sorter=ExternalMerge-cummean.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=200.00 MB&Sorter=ExternalMerge-density.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=200.00 MB&Sorter=ExternalMerge-timeline.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=200.00 MB&Sorter=ExternalMerge-timelineSmooth.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=200.00 MB&Sorter=KWayMerge-cummean.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=200.00 MB&Sorter=KWayMerge-density.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=200.00 MB&Sorter=KWayMerge-timeline.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=200.00 MB&Sorter=KWayMerge-timelineSmooth.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=200.00 MB&Sorter=Parallel-cummean.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=200.00 MB&Sorter=Parallel-density.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=200.00 MB&Sorter=Parallel-timeline.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=200.00 MB&Sorter=Parallel-timelineSmooth.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-FileSizeInBytes=100.00 MB&Sorter=ExternalMerge-density.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-FileSizeInBytes=100.00 MB&Sorter=ExternalMerge-facetDensity.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-FileSizeInBytes=100.00 MB&Sorter=KWayMerge-density.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-FileSizeInBytes=100.00 MB&Sorter=KWayMerge-facetDensity.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-FileSizeInBytes=100.00 MB&Sorter=Parallel-density.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-FileSizeInBytes=100.00 MB&Sorter=Parallel-facetDensity.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-FileSizeInBytes=200.00 MB&Sorter=ExternalMerge-density.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-FileSizeInBytes=200.00 MB&Sorter=ExternalMerge-facetDensity.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-FileSizeInBytes=200.00 MB&Sorter=KWayMerge-density.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-FileSizeInBytes=200.00 MB&Sorter=KWayMerge-facetDensity.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-FileSizeInBytes=200.00 MB&Sorter=Parallel-density.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-FileSizeInBytes=200.00 MB&Sorter=Parallel-facetDensity.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-cummean.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-density.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-facetDensity.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-facetTimeline.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-facetTimelineSmooth.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-barplot.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-boxplot.png)

