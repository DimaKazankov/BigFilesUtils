<!-- BENCHMARK RESULTS START -->

## Benchmark Results

*Last updated on Tue Oct  1 14:46:37 UTC 2024 UTC*

```

BenchmarkDotNet v0.14.0, Ubuntu 22.04.5 LTS (Jammy Jellyfish)
AMD EPYC 7763, 1 CPU, 2 logical cores and 1 physical core
.NET SDK 8.0.402
  [Host]            : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  ShortRun          : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  ShortRun-.NET 8.0 : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Runtime=.NET 8.0  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method       | Job               | FileSizeInBytes | Generator    | Mean     | Error     | StdDev   | StdErr   | Min      | Q1       | Median   | Q3       | Max       | Op/s   | Rank | Gen0        | Gen1        | Gen2        | Allocated  |
|------------- |------------------ |---------------- |------------- |---------:|----------:|---------:|---------:|---------:|---------:|---------:|---------:|----------:|-------:|-----:|------------:|------------:|------------:|-----------:|
| **GenerateFile** | **ShortRun**          | **1.00 GB**         | **Original**     | **9.2811 s** | **10.1292 s** | **0.5552 s** | **0.3206 s** | **8.6616 s** | **9.0548 s** | **9.4481 s** | **9.5909 s** |  **9.7337 s** | **0.1077** |    **4** |  **75000.0000** |           **-** |           **-** | **5992.19 MB** |
| GenerateFile | ShortRun-.NET 8.0 | 1.00 GB         | Original     | 9.0159 s | 12.0072 s | 0.6582 s | 0.3800 s | 8.2818 s | 8.7472 s | 9.2127 s | 9.3830 s |  9.5533 s | 0.1109 |    4 |  75000.0000 |           - |           - | 5992.19 MB |
| **GenerateFile** | **ShortRun**          | **1.00 GB**         | **Buffered**     | **8.4935 s** | **20.8740 s** | **1.1442 s** | **0.6606 s** | **7.1855 s** | **8.0861 s** | **8.9866 s** | **9.1476 s** |  **9.3085 s** | **0.1177** |    **4** | **673000.0000** | **635000.0000** | **635000.0000** | **5126.82 MB** |
| GenerateFile | ShortRun-.NET 8.0 | 1.00 GB         | Buffered     | 8.3600 s | 10.9465 s | 0.6000 s | 0.3464 s | 7.7216 s | 8.0839 s | 8.4463 s | 8.6793 s |  8.9123 s | 0.1196 |    4 | 668000.0000 | 630000.0000 | 630000.0000 | 5126.37 MB |
| **GenerateFile** | **ShortRun**          | **1.00 GB**         | **Parallel**     | **5.6910 s** |  **1.0150 s** | **0.0556 s** | **0.0321 s** | **5.6389 s** | **5.6617 s** | **5.6845 s** | **5.7170 s** |  **5.7496 s** | **0.1757** |    **3** |   **5000.0000** |   **5000.0000** |   **5000.0000** | **4100.07 MB** |
| GenerateFile | ShortRun-.NET 8.0 | 1.00 GB         | Parallel     | 5.7135 s |  0.4888 s | 0.0268 s | 0.0155 s | 5.6977 s | 5.6981 s | 5.6985 s | 5.7215 s |  5.7445 s | 0.1750 |    3 |   5000.0000 |   5000.0000 |   5000.0000 | 4100.05 MB |
| **GenerateFile** | **ShortRun**          | **1.00 GB**         | **MemoryMapped** | **9.7475 s** |  **7.4001 s** | **0.4056 s** | **0.2342 s** | **9.3348 s** | **9.5485 s** | **9.7622 s** | **9.9539 s** | **10.1456 s** | **0.1026** |    **4** | **101000.0000** |           **-** |           **-** | **8115.19 MB** |
| GenerateFile | ShortRun-.NET 8.0 | 1.00 GB         | MemoryMapped | 9.5807 s |  6.6579 s | 0.3649 s | 0.2107 s | 9.2987 s | 9.3746 s | 9.4504 s | 9.7217 s |  9.9929 s | 0.1044 |    4 | 101000.0000 |           - |           - | 8115.31 MB |
| **GenerateFile** | **ShortRun**          | **100.00 MB**       | **Original**     | **0.8398 s** |  **0.5106 s** | **0.0280 s** | **0.0162 s** | **0.8085 s** | **0.8286 s** | **0.8486 s** | **0.8555 s** |  **0.8624 s** | **1.1907** |    **2** |   **7000.0000** |           **-** |           **-** |  **585.49 MB** |
| GenerateFile | ShortRun-.NET 8.0 | 100.00 MB       | Original     | 0.8118 s |  0.5661 s | 0.0310 s | 0.0179 s | 0.7761 s | 0.8014 s | 0.8267 s | 0.8296 s |  0.8326 s | 1.2319 |    2 |   7000.0000 |           - |           - |  585.46 MB |
| **GenerateFile** | **ShortRun**          | **100.00 MB**       | **Buffered**     | **0.7559 s** |  **0.4896 s** | **0.0268 s** | **0.0155 s** | **0.7377 s** | **0.7405 s** | **0.7433 s** | **0.7650 s** |  **0.7867 s** | **1.3229** |    **2** |  **63000.0000** |  **60000.0000** |  **60000.0000** |  **502.64 MB** |
| GenerateFile | ShortRun-.NET 8.0 | 100.00 MB       | Buffered     | 0.7781 s |  0.3086 s | 0.0169 s | 0.0098 s | 0.7616 s | 0.7695 s | 0.7774 s | 0.7864 s |  0.7954 s | 1.2851 |    2 |  64000.0000 |  61000.0000 |  61000.0000 |  502.76 MB |
| **GenerateFile** | **ShortRun**          | **100.00 MB**       | **Parallel**     | **0.5361 s** |  **0.3481 s** | **0.0191 s** | **0.0110 s** | **0.5146 s** | **0.5287 s** | **0.5428 s** | **0.5469 s** |  **0.5510 s** | **1.8652** |    **1** |   **2500.0000** |   **2500.0000** |   **2500.0000** |  **440.73 MB** |
| GenerateFile | ShortRun-.NET 8.0 | 100.00 MB       | Parallel     | 0.5487 s |  0.0617 s | 0.0034 s | 0.0020 s | 0.5452 s | 0.5470 s | 0.5488 s | 0.5504 s |  0.5520 s | 1.8226 |    1 |   1500.0000 |   1500.0000 |   1500.0000 |  440.73 MB |
| **GenerateFile** | **ShortRun**          | **100.00 MB**       | **MemoryMapped** | **0.8972 s** |  **0.1552 s** | **0.0085 s** | **0.0049 s** | **0.8914 s** | **0.8923 s** | **0.8932 s** | **0.9000 s** |  **0.9069 s** | **1.1146** |    **2** |   **9000.0000** |           **-** |           **-** |  **792.54 MB** |
| GenerateFile | ShortRun-.NET 8.0 | 100.00 MB       | MemoryMapped | 0.8991 s |  0.1349 s | 0.0074 s | 0.0043 s | 0.8935 s | 0.8949 s | 0.8962 s | 0.9018 s |  0.9074 s | 1.1123 |    2 |   9000.0000 |           - |           - |  792.58 MB |
```

BenchmarkDotNet v0.14.0, Ubuntu 22.04.5 LTS (Jammy Jellyfish)
AMD EPYC 7763, 1 CPU, 2 logical cores and 1 physical core
.NET SDK 8.0.402
  [Host]            : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  ShortRun          : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  ShortRun-.NET 8.0 : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Runtime=.NET 8.0  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method   | Job               | FileSizeInBytes | Sorter        | MemorySorter | Mean     | Error    | StdDev   | StdErr   | Min      | Q1       | Median   | Q3       | Max      | Op/s   | Rank | Gen0        | Gen1       | Gen2      | Allocated   |
|--------- |------------------ |---------------- |-------------- |------------- |---------:|---------:|---------:|---------:|---------:|---------:|---------:|---------:|---------:|-------:|-----:|------------:|-----------:|----------:|------------:|
| **SortFile** | **ShortRun**          | **100.00 MB**       | **ExternalMerge** | **Default**      | **18.292 s** | **0.4933 s** | **0.0270 s** | **0.0156 s** | **18.275 s** | **18.276 s** | **18.277 s** | **18.300 s** | **18.323 s** | **0.0547** |    **2** | **253000.0000** | **12000.0000** | **3000.0000** | **20044.86 MB** |
| SortFile | ShortRun-.NET 8.0 | 100.00 MB       | ExternalMerge | Default      | 18.730 s | 2.5994 s | 0.1425 s | 0.0823 s | 18.590 s | 18.658 s | 18.725 s | 18.800 s | 18.875 s | 0.0534 |    2 | 259000.0000 | 12000.0000 | 3000.0000 |  20537.1 MB |
| **SortFile** | **ShortRun**          | **100.00 MB**       | **ExternalMerge** | **Quick**        | **20.535 s** | **3.0342 s** | **0.1663 s** | **0.0960 s** | **20.345 s** | **20.474 s** | **20.603 s** | **20.630 s** | **20.656 s** | **0.0487** |    **2** | **276000.0000** | **12000.0000** | **3000.0000** | **21894.89 MB** |
| SortFile | ShortRun-.NET 8.0 | 100.00 MB       | ExternalMerge | Quick        | 19.923 s | 1.5710 s | 0.0861 s | 0.0497 s | 19.837 s | 19.880 s | 19.924 s | 19.966 s | 20.009 s | 0.0502 |    2 | 280000.0000 | 12000.0000 | 3000.0000 | 22242.06 MB |
| **SortFile** | **ShortRun**          | **100.00 MB**       | **KWayMerge**     | **Default**      | **18.573 s** | **2.3642 s** | **0.1296 s** | **0.0748 s** | **18.488 s** | **18.499 s** | **18.509 s** | **18.616 s** | **18.722 s** | **0.0538** |    **2** | **254000.0000** | **12000.0000** | **3000.0000** | **20169.58 MB** |
| SortFile | ShortRun-.NET 8.0 | 100.00 MB       | KWayMerge     | Default      | 18.634 s | 0.9786 s | 0.0536 s | 0.0310 s | 18.573 s | 18.614 s | 18.655 s | 18.664 s | 18.674 s | 0.0537 |    2 | 254000.0000 | 12000.0000 | 3000.0000 | 20180.44 MB |
| **SortFile** | **ShortRun**          | **100.00 MB**       | **KWayMerge**     | **Quick**        | **20.048 s** | **1.8193 s** | **0.0997 s** | **0.0576 s** | **19.932 s** | **20.018 s** | **20.103 s** | **20.105 s** | **20.108 s** | **0.0499** |    **2** | **275000.0000** | **12000.0000** | **3000.0000** | **21874.58 MB** |
| SortFile | ShortRun-.NET 8.0 | 100.00 MB       | KWayMerge     | Quick        | 19.797 s | 0.6234 s | 0.0342 s | 0.0197 s | 19.769 s | 19.778 s | 19.786 s | 19.810 s | 19.835 s | 0.0505 |    2 | 273000.0000 | 12000.0000 | 3000.0000 | 21713.78 MB |
| **SortFile** | **ShortRun**          | **100.00 MB**       | **Parallel**      | **Default**      | **17.946 s** | **1.8565 s** | **0.1018 s** | **0.0588 s** | **17.885 s** | **17.887 s** | **17.888 s** | **17.976 s** | **18.063 s** | **0.0557** |    **2** | **251000.0000** | **12000.0000** | **3000.0000** | **19915.15 MB** |
| SortFile | ShortRun-.NET 8.0 | 100.00 MB       | Parallel      | Default      | 18.930 s | 2.1835 s | 0.1197 s | 0.0691 s | 18.818 s | 18.867 s | 18.916 s | 18.986 s | 19.057 s | 0.0528 |    2 | 254000.0000 | 12000.0000 | 3000.0000 | 20151.87 MB |
| **SortFile** | **ShortRun**          | **100.00 MB**       | **Parallel**      | **Quick**        | **20.559 s** | **1.6386 s** | **0.0898 s** | **0.0519 s** | **20.466 s** | **20.515 s** | **20.565 s** | **20.605 s** | **20.645 s** | **0.0486** |    **2** | **284000.0000** | **12000.0000** | **3000.0000** | **22602.58 MB** |
| SortFile | ShortRun-.NET 8.0 | 100.00 MB       | Parallel      | Quick        | 20.913 s | 0.3954 s | 0.0217 s | 0.0125 s | 20.894 s | 20.901 s | 20.908 s | 20.922 s | 20.936 s | 0.0478 |    2 | 298000.0000 | 12000.0000 | 3000.0000 |  23703.5 MB |
| **SortFile** | **ShortRun**          | **100.00 MB**       | **MemoryMapped**  | **Default**      | **16.879 s** | **2.8208 s** | **0.1546 s** | **0.0893 s** | **16.749 s** | **16.793 s** | **16.838 s** | **16.944 s** | **17.050 s** | **0.0592** |    **2** | **240000.0000** | **21000.0000** | **5000.0000** | **18933.79 MB** |
| SortFile | ShortRun-.NET 8.0 | 100.00 MB       | MemoryMapped  | Default      | 17.025 s | 3.6284 s | 0.1989 s | 0.1148 s | 16.801 s | 16.946 s | 17.090 s | 17.136 s | 17.182 s | 0.0587 |    2 | 240000.0000 | 19000.0000 | 3000.0000 | 19076.06 MB |
| **SortFile** | **ShortRun**          | **100.00 MB**       | **MemoryMapped**  | **Quick**        | **18.952 s** | **0.7939 s** | **0.0435 s** | **0.0251 s** | **18.916 s** | **18.928 s** | **18.939 s** | **18.970 s** | **19.000 s** | **0.0528** |    **2** | **263000.0000** | **19000.0000** | **3000.0000** | **20917.72 MB** |
| SortFile | ShortRun-.NET 8.0 | 100.00 MB       | MemoryMapped  | Quick        | 18.666 s | 1.8065 s | 0.0990 s | 0.0572 s | 18.595 s | 18.610 s | 18.625 s | 18.702 s | 18.779 s | 0.0536 |    2 | 267000.0000 | 21000.0000 | 5000.0000 | 21097.31 MB |
| **SortFile** | **ShortRun**          | **50.00 MB**        | **ExternalMerge** | **Default**      |  **8.600 s** | **0.8470 s** | **0.0464 s** | **0.0268 s** |  **8.551 s** |  **8.578 s** |  **8.605 s** |  **8.624 s** |  **8.643 s** | **0.1163** |    **1** | **123000.0000** |  **7000.0000** | **2000.0000** |  **9722.82 MB** |
| SortFile | ShortRun-.NET 8.0 | 50.00 MB        | ExternalMerge | Default      |  8.738 s | 2.1393 s | 0.1173 s | 0.0677 s |  8.651 s |  8.671 s |  8.691 s |  8.781 s |  8.871 s | 0.1144 |    1 | 121000.0000 |  7000.0000 | 2000.0000 |  9595.53 MB |
| **SortFile** | **ShortRun**          | **50.00 MB**        | **ExternalMerge** | **Quick**        |  **9.097 s** | **0.7619 s** | **0.0418 s** | **0.0241 s** |  **9.054 s** |  **9.077 s** |  **9.101 s** |  **9.119 s** |  **9.137 s** | **0.1099** |    **1** | **130000.0000** |  **7000.0000** | **2000.0000** | **10284.85 MB** |
| SortFile | ShortRun-.NET 8.0 | 50.00 MB        | ExternalMerge | Quick        |  9.337 s | 1.0590 s | 0.0580 s | 0.0335 s |  9.270 s |  9.320 s |  9.370 s |  9.370 s |  9.371 s | 0.1071 |    1 | 133000.0000 |  7000.0000 | 2000.0000 | 10553.22 MB |
| **SortFile** | **ShortRun**          | **50.00 MB**        | **KWayMerge**     | **Default**      |  **8.878 s** | **0.7549 s** | **0.0414 s** | **0.0239 s** |  **8.834 s** |  **8.858 s** |  **8.881 s** |  **8.899 s** |  **8.917 s** | **0.1126** |    **1** | **122000.0000** |  **7000.0000** | **2000.0000** |  **9691.75 MB** |
| SortFile | ShortRun-.NET 8.0 | 50.00 MB        | KWayMerge     | Default      |  8.659 s | 0.1172 s | 0.0064 s | 0.0037 s |  8.655 s |  8.656 s |  8.656 s |  8.661 s |  8.667 s | 0.1155 |    1 | 124000.0000 |  7000.0000 | 2000.0000 |  9836.17 MB |
| **SortFile** | **ShortRun**          | **50.00 MB**        | **KWayMerge**     | **Quick**        |  **9.933 s** | **0.6627 s** | **0.0363 s** | **0.0210 s** |  **9.891 s** |  **9.921 s** |  **9.951 s** |  **9.954 s** |  **9.956 s** | **0.1007** |    **1** | **135000.0000** |  **7000.0000** | **2000.0000** |  **10686.9 MB** |
| SortFile | ShortRun-.NET 8.0 | 50.00 MB        | KWayMerge     | Quick        | 10.251 s | 1.1978 s | 0.0657 s | 0.0379 s | 10.184 s | 10.218 s | 10.252 s | 10.284 s | 10.316 s | 0.0976 |    1 | 133000.0000 |  7000.0000 | 2000.0000 | 10586.64 MB |
| **SortFile** | **ShortRun**          | **50.00 MB**        | **Parallel**      | **Default**      |  **9.137 s** | **0.6169 s** | **0.0338 s** | **0.0195 s** |  **9.109 s** |  **9.118 s** |  **9.127 s** |  **9.151 s** |  **9.175 s** | **0.1094** |    **1** | **121000.0000** |  **7000.0000** | **2000.0000** |  **9651.05 MB** |
| SortFile | ShortRun-.NET 8.0 | 50.00 MB        | Parallel      | Default      |  9.182 s | 0.8077 s | 0.0443 s | 0.0256 s |  9.142 s |  9.159 s |  9.176 s |  9.203 s |  9.229 s | 0.1089 |    1 | 122000.0000 |  7000.0000 | 2000.0000 |  9729.47 MB |
| **SortFile** | **ShortRun**          | **50.00 MB**        | **Parallel**      | **Quick**        | **10.085 s** | **1.0670 s** | **0.0585 s** | **0.0338 s** | **10.021 s** | **10.060 s** | **10.100 s** | **10.117 s** | **10.135 s** | **0.0992** |    **1** | **134000.0000** |  **7000.0000** | **2000.0000** | **10672.73 MB** |
| SortFile | ShortRun-.NET 8.0 | 50.00 MB        | Parallel      | Quick        | 10.060 s | 0.2701 s | 0.0148 s | 0.0085 s | 10.047 s | 10.052 s | 10.058 s | 10.067 s | 10.076 s | 0.0994 |    1 | 135000.0000 |  7000.0000 | 2000.0000 | 10739.48 MB |
| **SortFile** | **ShortRun**          | **50.00 MB**        | **MemoryMapped**  | **Default**      |  **8.531 s** | **0.7978 s** | **0.0437 s** | **0.0252 s** |  **8.490 s** |  **8.508 s** |  **8.526 s** |  **8.552 s** |  **8.577 s** | **0.1172** |    **1** | **117000.0000** | **12000.0000** | **4000.0000** |  **9162.28 MB** |
| SortFile | ShortRun-.NET 8.0 | 50.00 MB        | MemoryMapped  | Default      |  8.452 s | 0.3874 s | 0.0212 s | 0.0123 s |  8.439 s |  8.440 s |  8.441 s |  8.459 s |  8.476 s | 0.1183 |    1 | 115000.0000 | 12000.0000 | 4000.0000 |   9021.4 MB |
| **SortFile** | **ShortRun**          | **50.00 MB**        | **MemoryMapped**  | **Quick**        |  **9.144 s** | **2.0949 s** | **0.1148 s** | **0.0663 s** |  **9.019 s** |  **9.093 s** |  **9.166 s** |  **9.206 s** |  **9.245 s** | **0.1094** |    **1** | **125000.0000** | **12000.0000** | **4000.0000** |  **9816.21 MB** |
| SortFile | ShortRun-.NET 8.0 | 50.00 MB        | MemoryMapped  | Quick        |  9.112 s | 0.1814 s | 0.0099 s | 0.0057 s |  9.105 s |  9.106 s |  9.106 s |  9.115 s |  9.123 s | 0.1098 |    1 | 126000.0000 | 12000.0000 | 4000.0000 |   9909.1 MB |
### Performance Barplot
![Benchmark Barplot](docs/FileAlgorithms.Benchmark.Benchmark.FileGeneratorBenchmark-barplot.png)

### Performance Barplot
![Benchmark Barplot](docs/FileAlgorithms.Benchmark.Benchmark.FileSorterBenchmark-barplot.png)

### Performance Boxplot
![Benchmark Boxplot](docs/FileAlgorithms.Benchmark.Benchmark.FileGeneratorBenchmark-boxplot.png)

### Performance Boxplot
![Benchmark Boxplot](docs/FileAlgorithms.Benchmark.Benchmark.FileSorterBenchmark-boxplot.png)

<!-- BENCHMARK RESULTS END -->
