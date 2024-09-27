# Big files utils

## Benchmark Results

You can view the latest benchmark results [here](docs/FileGeneratorBenchmark-report-github.md).

![Benchmark Plot](docs/FileGeneratorBenchmark-plot.png)

<!-- BENCHMARK RESULTS START -->

*Last updated on Fri Sep 27 20:51:23 UTC 2024 UTC*

```

BenchmarkDotNet v0.14.0, Ubuntu 22.04.5 LTS (Jammy Jellyfish)
AMD EPYC 7763, 1 CPU, 2 logical cores and 1 physical core
.NET SDK 8.0.402
  [Host]   : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  ShortRun : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Job=ShortRun  Server=True  IterationCount=3  
LaunchCount=1  WarmupCount=3  

```
| Method       | FileSizeInBytes | Mean         | Error          | StdDev        | Min          | Max          | Q1           | Q3           | Median       | Gen0       | Gen1    | Gen2    | Allocated     |
|------------- |---------------- |-------------:|---------------:|--------------:|-------------:|-------------:|-------------:|-------------:|-------------:|-----------:|--------:|--------:|--------------:|
| **GenerateFile** | **102400**          |     **1.195 ms** |      **0.1457 ms** |     **0.0080 ms** |     **1.186 ms** |     **1.201 ms** |     **1.191 ms** |     **1.199 ms** |     **1.197 ms** |    **62.5000** | **62.5000** | **62.5000** |     **909.96 KB** |
| **GenerateFile** | **104857600**       |   **745.624 ms** |    **172.2511 ms** |     **9.4417 ms** |   **735.207 ms** |   **753.617 ms** |   **741.627 ms** |   **750.833 ms** |   **748.048 ms** |  **1000.0000** |       **-** |       **-** |  **599132.52 KB** |
| **GenerateFile** | **1073741824**      | **7,581.971 ms** | **20,117.9549 ms** | **1,102.7330 ms** | **6,855.096 ms** | **8,850.814 ms** | **6,947.549 ms** | **7,945.408 ms** | **7,040.002 ms** | **19000.0000** |       **-** |       **-** | **6131416.92 KB** |

![](docs/FileGeneratorBenchmark-GenerateFile-FileSizeInBytes=102400-density.png)

![](docs/FileGeneratorBenchmark-GenerateFile-FileSizeInBytes=102400-facetDensity.png)

![](docs/FileGeneratorBenchmark-GenerateFile-FileSizeInBytes=104857600-density.png)

![](docs/FileGeneratorBenchmark-GenerateFile-FileSizeInBytes=104857600-facetDensity.png)

![](docs/FileGeneratorBenchmark-GenerateFile-FileSizeInBytes=1073741824-density.png)

![](docs/FileGeneratorBenchmark-GenerateFile-FileSizeInBytes=1073741824-facetDensity.png)

![](docs/FileGeneratorBenchmark-GenerateFile-ShortRun FileSizeInBytes=102400-cummean.png)

![](docs/FileGeneratorBenchmark-GenerateFile-ShortRun FileSizeInBytes=102400-density.png)

![](docs/FileGeneratorBenchmark-GenerateFile-ShortRun FileSizeInBytes=102400-timeline.png)

![](docs/FileGeneratorBenchmark-GenerateFile-ShortRun FileSizeInBytes=102400-timelineSmooth.png)

![](docs/FileGeneratorBenchmark-GenerateFile-ShortRun FileSizeInBytes=104857600-cummean.png)

![](docs/FileGeneratorBenchmark-GenerateFile-ShortRun FileSizeInBytes=104857600-density.png)

![](docs/FileGeneratorBenchmark-GenerateFile-ShortRun FileSizeInBytes=104857600-timeline.png)

![](docs/FileGeneratorBenchmark-GenerateFile-ShortRun FileSizeInBytes=104857600-timelineSmooth.png)

![](docs/FileGeneratorBenchmark-GenerateFile-ShortRun FileSizeInBytes=1073741824-cummean.png)

![](docs/FileGeneratorBenchmark-GenerateFile-ShortRun FileSizeInBytes=1073741824-density.png)

![](docs/FileGeneratorBenchmark-GenerateFile-ShortRun FileSizeInBytes=1073741824-timeline.png)

![](docs/FileGeneratorBenchmark-GenerateFile-ShortRun FileSizeInBytes=1073741824-timelineSmooth.png)

![](docs/FileGeneratorBenchmark-GenerateFile-cummean.png)

![](docs/FileGeneratorBenchmark-GenerateFile-density.png)

![](docs/FileGeneratorBenchmark-GenerateFile-facetDensity.png)

![](docs/FileGeneratorBenchmark-GenerateFile-facetTimeline.png)

![](docs/FileGeneratorBenchmark-GenerateFile-facetTimelineSmooth.png)

![](docs/FileGeneratorBenchmark-barplot.png)

![](docs/FileGeneratorBenchmark-boxplot.png)

![](docs/FileGeneratorBenchmark-plot.png)

<!-- BENCHMARK RESULTS END -->
