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

<!-- FILE_GENERATION_RESULTS_START -->
### File Generation Benchmarks

```

BenchmarkDotNet v0.14.0, Ubuntu 22.04.5 LTS (Jammy Jellyfish)
AMD EPYC 7763, 1 CPU, 2 logical cores and 1 physical core
.NET SDK 8.0.402
  [Host]     : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2


```
| Method       | FileSizeInBytes | Generator    | FileSize | Mean      | Error    | StdDev   | StdErr   | Median    | Min       | Q1        | Q3        | Max       | Op/s   | Rank | Gen0        | Gen1        | Gen2        | Allocated  |
|------------- |---------------- |------------- |--------- |----------:|---------:|---------:|---------:|----------:|----------:|----------:|----------:|----------:|-------:|-----:|------------:|------------:|------------:|-----------:|
| **GenerateFile** | **1.00 GB**         | **Original**     | **?**        |  **9.3875 s** | **0.0311 s** | **0.0291 s** | **0.0075 s** |  **9.3965 s** |  **9.3402 s** |  **9.3687 s** |  **9.4085 s** |  **9.4259 s** | **0.1065** |    **4** |  **75000.0000** |           **-** |           **-** | **5992.32 MB** |
| **GenerateFile** | **1.00 GB**         | **Buffered**     | **?**        |  **8.3006 s** | **0.0822 s** | **0.0769 s** | **0.0198 s** |  **8.3375 s** |  **8.1421 s** |  **8.2977 s** |  **8.3454 s** |  **8.4001 s** | **0.1205** |    **3** | **682000.0000** | **682000.0000** | **682000.0000** | **5122.43 MB** |
| **GenerateFile** | **1.00 GB**         | **Parallel**     | **?**        | **10.8152 s** | **0.2519 s** | **0.7429 s** | **0.0743 s** | **10.8984 s** |  **8.9928 s** | **10.4498 s** | **11.3700 s** | **12.1976 s** | **0.0925** |    **5** |  **43000.0000** |  **42000.0000** |   **5000.0000** | **3696.98 MB** |
| **GenerateFile** | **1.00 GB**         | **MemoryMapped** | **?**        | **10.3274 s** | **0.1002 s** | **0.0888 s** | **0.0237 s** | **10.3387 s** | **10.1462 s** | **10.2851 s** | **10.3574 s** | **10.4892 s** | **0.0968** |    **5** | **101000.0000** |           **-** |           **-** | **8115.48 MB** |
| **GenerateFile** | **100.00 MB**       | **Original**     | **?**        |  **0.8353 s** | **0.0161 s** | **0.0191 s** | **0.0042 s** |  **0.8447 s** |  **0.7993 s** |  **0.8416 s** |  **0.8462 s** |  **0.8520 s** | **1.1972** |    **2** |   **7000.0000** |           **-** |           **-** |   **585.5 MB** |
| **GenerateFile** | **100.00 MB**       | **Buffered**     | **?**        |  **0.7759 s** | **0.0153 s** | **0.0260 s** | **0.0043 s** |  **0.7823 s** |  **0.7363 s** |  **0.7522 s** |  **0.7984 s** |  **0.8426 s** | **1.2889** |    **1** |  **66000.0000** |  **66000.0000** |  **66000.0000** |  **500.77 MB** |
| **GenerateFile** | **100.00 MB**       | **Parallel**     | **?**        |  **0.8680 s** | **0.0430 s** | **0.1267 s** | **0.0127 s** |  **0.8096 s** |  **0.7297 s** |  **0.7838 s** |  **0.9641 s** |  **1.2263 s** | **1.1520** |    **2** |   **4000.0000** |   **3000.0000** |   **1000.0000** |  **316.26 MB** |
| **GenerateFile** | **100.00 MB**       | **MemoryMapped** | **?**        |  **0.8954 s** | **0.0072 s** | **0.0068 s** | **0.0018 s** |  **0.8946 s** |  **0.8842 s** |  **0.8906 s** |  **0.8989 s** |  **0.9061 s** | **1.1168** |    **2** |   **9000.0000** |           **-** |           **-** |  **792.53 MB** |

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
| Method   | FileSizeInBytes | Sorter        | Generator | FileSize | Mean     | Error    | StdDev   | StdErr   | Min      | Q1       | Median   | Q3       | Max      | Op/s   | Rank | Gen0        | Gen1       | Gen2      | Allocated   |
|--------- |---------------- |-------------- |---------- |--------- |---------:|---------:|---------:|---------:|---------:|---------:|---------:|---------:|---------:|-------:|-----:|------------:|-----------:|----------:|------------:|
| **SortFile** | **100.00 MB**       | **ExternalMerge** | **?**         | **?**        | **18.805 s** | **0.2398 s** | **0.2243 s** | **0.0579 s** | **18.426 s** | **18.691 s** | **18.854 s** | **18.952 s** | **19.165 s** | **0.0532** |    **3** | **255000.0000** | **11000.0000** | **2000.0000** | **20283.26 MB** |
| **SortFile** | **100.00 MB**       | **KWayMerge**     | **?**         | **?**        | **19.040 s** | **0.3576 s** | **0.3345 s** | **0.0864 s** | **18.461 s** | **18.829 s** | **19.070 s** | **19.216 s** | **19.583 s** | **0.0525** |    **3** | **255000.0000** | **12000.0000** | **3000.0000** | **20226.18 MB** |
| **SortFile** | **100.00 MB**       | **Parallel**      | **?**         | **?**        | **18.399 s** | **0.0964 s** | **0.0855 s** | **0.0228 s** | **18.204 s** | **18.362 s** | **18.391 s** | **18.458 s** | **18.532 s** | **0.0544** |    **3** | **252000.0000** | **11000.0000** | **2000.0000** | **20087.05 MB** |
| **SortFile** | **100.00 MB**       | **MemoryMapped**  | **?**         | **?**        | **25.638 s** | **0.1481 s** | **0.1236 s** | **0.0343 s** | **25.407 s** | **25.595 s** | **25.605 s** | **25.688 s** | **25.912 s** | **0.0390** |    **4** | **493000.0000** | **20000.0000** | **3000.0000** | **39292.06 MB** |
| **SortFile** | **50.00 MB**        | **ExternalMerge** | **?**         | **?**        |  **8.781 s** | **0.0865 s** | **0.0810 s** | **0.0209 s** |  **8.655 s** |  **8.720 s** |  **8.775 s** |  **8.836 s** |  **8.911 s** | **0.1139** |    **1** | **121000.0000** |  **7000.0000** | **2000.0000** |   **9599.3 MB** |
| **SortFile** | **50.00 MB**        | **KWayMerge**     | **?**         | **?**        |  **8.613 s** | **0.1511 s** | **0.1413 s** | **0.0365 s** |  **8.376 s** |  **8.529 s** |  **8.573 s** |  **8.728 s** |  **8.816 s** | **0.1161** |    **1** | **121000.0000** |  **7000.0000** | **2000.0000** |  **9587.83 MB** |
| **SortFile** | **50.00 MB**        | **Parallel**      | **?**         | **?**        |  **8.938 s** | **0.1062 s** | **0.0993 s** | **0.0256 s** |  **8.739 s** |  **8.877 s** |  **8.909 s** |  **9.038 s** |  **9.074 s** | **0.1119** |    **1** | **120000.0000** |  **7000.0000** | **2000.0000** |  **9562.14 MB** |
| **SortFile** | **50.00 MB**        | **MemoryMapped**  | **?**         | **?**        | **12.549 s** | **0.0659 s** | **0.0584 s** | **0.0156 s** | **12.423 s** | **12.513 s** | **12.563 s** | **12.572 s** | **12.663 s** | **0.0797** |    **2** | **234000.0000** | **12000.0000** | **3000.0000** | **18568.08 MB** |

<!-- FILE_SORTING_RESULTS_END -->
![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=100.00 MB&Sorter=ExternalMerge-cummean.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=100.00 MB&Sorter=ExternalMerge-density.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=100.00 MB&Sorter=ExternalMerge-timeline.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=100.00 MB&Sorter=ExternalMerge-timelineSmooth.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=100.00 MB&Sorter=KWayMerge-cummean.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=100.00 MB&Sorter=KWayMerge-density.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=100.00 MB&Sorter=KWayMerge-timeline.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=100.00 MB&Sorter=KWayMerge-timelineSmooth.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=100.00 MB&Sorter=MemoryMapped-cummean.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=100.00 MB&Sorter=MemoryMapped-density.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=100.00 MB&Sorter=MemoryMapped-timeline.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=100.00 MB&Sorter=MemoryMapped-timelineSmooth.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=100.00 MB&Sorter=Parallel-cummean.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=100.00 MB&Sorter=Parallel-density.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=100.00 MB&Sorter=Parallel-timeline.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=100.00 MB&Sorter=Parallel-timelineSmooth.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=50.00 MB&Sorter=ExternalMerge-cummean.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=50.00 MB&Sorter=ExternalMerge-density.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=50.00 MB&Sorter=ExternalMerge-timeline.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=50.00 MB&Sorter=ExternalMerge-timelineSmooth.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=50.00 MB&Sorter=KWayMerge-cummean.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=50.00 MB&Sorter=KWayMerge-density.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=50.00 MB&Sorter=KWayMerge-timeline.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=50.00 MB&Sorter=KWayMerge-timelineSmooth.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=50.00 MB&Sorter=MemoryMapped-cummean.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=50.00 MB&Sorter=MemoryMapped-density.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=50.00 MB&Sorter=MemoryMapped-timeline.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=50.00 MB&Sorter=MemoryMapped-timelineSmooth.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=50.00 MB&Sorter=Parallel-cummean.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=50.00 MB&Sorter=Parallel-density.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=50.00 MB&Sorter=Parallel-timeline.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-DefaultJob FileSizeInBytes=50.00 MB&Sorter=Parallel-timelineSmooth.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-FileSizeInBytes=100.00 MB&Sorter=ExternalMerge-density.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-FileSizeInBytes=100.00 MB&Sorter=ExternalMerge-facetDensity.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-FileSizeInBytes=100.00 MB&Sorter=KWayMerge-density.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-FileSizeInBytes=100.00 MB&Sorter=KWayMerge-facetDensity.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-FileSizeInBytes=100.00 MB&Sorter=MemoryMapped-density.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-FileSizeInBytes=100.00 MB&Sorter=MemoryMapped-facetDensity.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-FileSizeInBytes=100.00 MB&Sorter=Parallel-density.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-FileSizeInBytes=100.00 MB&Sorter=Parallel-facetDensity.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-FileSizeInBytes=50.00 MB&Sorter=ExternalMerge-density.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-FileSizeInBytes=50.00 MB&Sorter=ExternalMerge-facetDensity.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-FileSizeInBytes=50.00 MB&Sorter=KWayMerge-density.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-FileSizeInBytes=50.00 MB&Sorter=KWayMerge-facetDensity.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-FileSizeInBytes=50.00 MB&Sorter=MemoryMapped-density.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-FileSizeInBytes=50.00 MB&Sorter=MemoryMapped-facetDensity.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-FileSizeInBytes=50.00 MB&Sorter=Parallel-density.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-FileSizeInBytes=50.00 MB&Sorter=Parallel-facetDensity.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-cummean.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-density.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-facetDensity.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-facetTimeline.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-SortFile-facetTimelineSmooth.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-barplot.png)

![Benchmark Chart](docs/BigFilesUtils.Benchmark.FileSorterBenchmark-boxplot.png)

