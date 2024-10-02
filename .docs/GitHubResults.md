<!-- BENCHMARK RESULTS START -->

## Benchmark Results

*Last updated on Wed Oct  2 08:39:54 UTC 2024 UTC*

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
| Method       | Job               | FileSizeInBytes | Generator    | Mean      | Error     | StdDev   | StdErr   | Min       | Q1        | Median    | Q3        | Max       | Op/s   | Rank | Gen0        | Gen1        | Gen2        | Allocated  |
|------------- |------------------ |---------------- |------------- |----------:|----------:|---------:|---------:|----------:|----------:|----------:|----------:|----------:|-------:|-----:|------------:|------------:|------------:|-----------:|
| **GenerateFile** | **ShortRun**          | **1.00 GB**         | **Original**     |  **9.0994 s** | **15.8910 s** | **0.8710 s** | **0.5029 s** |  **8.0998 s** |  **8.8012 s** |  **9.5025 s** |  **9.5992 s** |  **9.6959 s** | **0.1099** |    **3** |  **75000.0000** |           **-** |           **-** | **5992.26 MB** |
| GenerateFile | ShortRun-.NET 8.0 | 1.00 GB         | Original     |  9.5883 s |  1.9880 s | 0.1090 s | 0.0629 s |  9.5208 s |  9.5254 s |  9.5301 s |  9.6220 s |  9.7140 s | 0.1043 |    3 |  75000.0000 |           - |           - | 5992.14 MB |
| **GenerateFile** | **ShortRun**          | **1.00 GB**         | **Buffered**     |  **7.4675 s** | **15.0837 s** | **0.8268 s** | **0.4773 s** |  **6.9541 s** |  **6.9907 s** |  **7.0272 s** |  **7.7243 s** |  **8.4213 s** | **0.1339** |    **3** | **667000.0000** | **629000.0000** | **629000.0000** | **5125.38 MB** |
| GenerateFile | ShortRun-.NET 8.0 | 1.00 GB         | Buffered     |  8.3638 s | 12.6114 s | 0.6913 s | 0.3991 s |  7.5739 s |  8.1169 s |  8.6599 s |  8.7588 s |  8.8578 s | 0.1196 |    3 | 666000.0000 | 628000.0000 | 628000.0000 | 5125.35 MB |
| **GenerateFile** | **ShortRun**          | **1.00 GB**         | **Parallel**     |  **5.7882 s** |  **0.0772 s** | **0.0042 s** | **0.0024 s** |  **5.7837 s** |  **5.7862 s** |  **5.7887 s** |  **5.7904 s** |  **5.7921 s** | **0.1728** |    **3** |   **5000.0000** |   **5000.0000** |   **5000.0000** | **4099.98 MB** |
| GenerateFile | ShortRun-.NET 8.0 | 1.00 GB         | Parallel     |  5.6246 s |  1.2533 s | 0.0687 s | 0.0397 s |  5.5507 s |  5.5936 s |  5.6365 s |  5.6615 s |  5.6865 s | 0.1778 |    3 |   4000.0000 |   4000.0000 |   4000.0000 |  4100.1 MB |
| **GenerateFile** | **ShortRun**          | **1.00 GB**         | **MemoryMapped** | **10.3612 s** |  **4.1030 s** | **0.2249 s** | **0.1298 s** | **10.1244 s** | **10.2559 s** | **10.3874 s** | **10.4797 s** | **10.5719 s** | **0.0965** |    **3** | **101000.0000** |           **-** |           **-** | **8115.45 MB** |
| GenerateFile | ShortRun-.NET 8.0 | 1.00 GB         | MemoryMapped |  9.6920 s |  8.5123 s | 0.4666 s | 0.2694 s |  9.2014 s |  9.4729 s |  9.7443 s |  9.9372 s | 10.1302 s | 0.1032 |    3 | 101000.0000 |           - |           - | 8115.64 MB |
| **GenerateFile** | **ShortRun**          | **100.00 MB**       | **Original**     |  **0.8788 s** |  **0.7689 s** | **0.0421 s** | **0.0243 s** |  **0.8329 s** |  **0.8603 s** |  **0.8877 s** |  **0.9018 s** |  **0.9158 s** | **1.1379** |    **2** |   **7000.0000** |           **-** |           **-** |  **585.46 MB** |
| GenerateFile | ShortRun-.NET 8.0 | 100.00 MB       | Original     |  0.8362 s |  0.4186 s | 0.0229 s | 0.0132 s |  0.8201 s |  0.8231 s |  0.8260 s |  0.8442 s |  0.8625 s | 1.1959 |    2 |   7000.0000 |           - |           - |  585.49 MB |
| **GenerateFile** | **ShortRun**          | **100.00 MB**       | **Buffered**     |  **0.7380 s** |  **0.4218 s** | **0.0231 s** | **0.0133 s** |  **0.7170 s** |  **0.7256 s** |  **0.7342 s** |  **0.7485 s** |  **0.7628 s** | **1.3550** |    **2** |  **63000.0000** |  **60000.0000** |  **60000.0000** |  **502.66 MB** |
| GenerateFile | ShortRun-.NET 8.0 | 100.00 MB       | Buffered     |  0.7531 s |  0.6639 s | 0.0364 s | 0.0210 s |  0.7296 s |  0.7321 s |  0.7346 s |  0.7648 s |  0.7950 s | 1.3279 |    2 |  63000.0000 |  60000.0000 |  60000.0000 |  502.68 MB |
| **GenerateFile** | **ShortRun**          | **100.00 MB**       | **Parallel**     |  **0.5476 s** |  **0.1885 s** | **0.0103 s** | **0.0060 s** |  **0.5388 s** |  **0.5419 s** |  **0.5451 s** |  **0.5520 s** |  **0.5590 s** | **1.8261** |    **1** |   **3000.0000** |   **3000.0000** |   **3000.0000** |  **440.73 MB** |
| GenerateFile | ShortRun-.NET 8.0 | 100.00 MB       | Parallel     |  0.5496 s |  0.0909 s | 0.0050 s | 0.0029 s |  0.5461 s |  0.5467 s |  0.5473 s |  0.5513 s |  0.5553 s | 1.8197 |    1 |   2000.0000 |   2000.0000 |   2000.0000 |  440.73 MB |
| **GenerateFile** | **ShortRun**          | **100.00 MB**       | **MemoryMapped** |  **0.8905 s** |  **0.0312 s** | **0.0017 s** | **0.0010 s** |  **0.8885 s** |  **0.8900 s** |  **0.8915 s** |  **0.8915 s** |  **0.8915 s** | **1.1230** |    **2** |   **9000.0000** |           **-** |           **-** |  **792.56 MB** |
| GenerateFile | ShortRun-.NET 8.0 | 100.00 MB       | MemoryMapped |  0.9130 s |  0.3517 s | 0.0193 s | 0.0111 s |  0.8946 s |  0.9030 s |  0.9114 s |  0.9223 s |  0.9331 s | 1.0952 |    2 |   9000.0000 |           - |           - |  792.52 MB |
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
| Method   | Job               | FileSizeInBytes | Sorter              | MemorySorter | Mean     | Error     | StdDev   | StdErr   | Min      | Q1       | Median   | Q3       | Max      | Op/s   | Rank | Gen0        | Gen1       | Gen2      | Allocated   |
|--------- |------------------ |---------------- |-------------------- |------------- |---------:|----------:|---------:|---------:|---------:|---------:|---------:|---------:|---------:|-------:|-----:|------------:|-----------:|----------:|------------:|
| **SortFile** | **ShortRun**          | **100.00 MB**       | **ExternalMerge**       | **Default**      | **19.988 s** |  **3.5213 s** | **0.1930 s** | **0.1114 s** | **19.773 s** | **19.908 s** | **20.043 s** | **20.095 s** | **20.147 s** | **0.0500** |    **2** | **253000.0000** | **12000.0000** | **3000.0000** | **20053.71 MB** |
| SortFile | ShortRun-.NET 8.0 | 100.00 MB       | ExternalMerge       | Default      | 19.218 s |  6.6926 s | 0.3668 s | 0.2118 s | 18.797 s | 19.091 s | 19.384 s | 19.428 s | 19.472 s | 0.0520 |    2 | 254000.0000 | 12000.0000 | 3000.0000 | 20157.33 MB |
| **SortFile** | **ShortRun**          | **100.00 MB**       | **ExternalMerge**       | **Quick**        | **19.733 s** | **13.8444 s** | **0.7589 s** | **0.4381 s** | **19.268 s** | **19.296 s** | **19.323 s** | **19.966 s** | **20.609 s** | **0.0507** |    **2** | **275000.0000** | **12000.0000** | **3000.0000** |  **21839.6 MB** |
| SortFile | ShortRun-.NET 8.0 | 100.00 MB       | ExternalMerge       | Quick        | 19.640 s |  4.8942 s | 0.2683 s | 0.1549 s | 19.332 s | 19.550 s | 19.768 s | 19.794 s | 19.820 s | 0.0509 |    2 | 276000.0000 | 12000.0000 | 3000.0000 |  21931.8 MB |
| **SortFile** | **ShortRun**          | **100.00 MB**       | **KWayMerge**           | **Default**      | **18.751 s** |  **4.4602 s** | **0.2445 s** | **0.1412 s** | **18.488 s** | **18.640 s** | **18.793 s** | **18.882 s** | **18.972 s** | **0.0533** |    **2** | **257000.0000** | **12000.0000** | **3000.0000** | **20383.08 MB** |
| SortFile | ShortRun-.NET 8.0 | 100.00 MB       | KWayMerge           | Default      | 18.598 s |  2.2630 s | 0.1240 s | 0.0716 s | 18.520 s | 18.526 s | 18.532 s | 18.636 s | 18.741 s | 0.0538 |    2 | 256000.0000 | 12000.0000 | 3000.0000 |  20301.1 MB |
| **SortFile** | **ShortRun**          | **100.00 MB**       | **KWayMerge**           | **Quick**        | **19.978 s** |  **8.5428 s** | **0.4683 s** | **0.2703 s** | **19.453 s** | **19.791 s** | **20.129 s** | **20.240 s** | **20.352 s** | **0.0501** |    **2** | **274000.0000** | **12000.0000** | **3000.0000** |  **21784.5 MB** |
| SortFile | ShortRun-.NET 8.0 | 100.00 MB       | KWayMerge           | Quick        | 20.972 s |  4.5886 s | 0.2515 s | 0.1452 s | 20.702 s | 20.858 s | 21.015 s | 21.107 s | 21.200 s | 0.0477 |    2 | 281000.0000 | 12000.0000 | 3000.0000 | 22274.46 MB |
| **SortFile** | **ShortRun**          | **100.00 MB**       | **Parallel**            | **Default**      | **17.748 s** |  **0.6766 s** | **0.0371 s** | **0.0214 s** | **17.706 s** | **17.735 s** | **17.763 s** | **17.770 s** | **17.776 s** | **0.0563** |    **2** | **251000.0000** | **12000.0000** | **3000.0000** | **19982.32 MB** |
| SortFile | ShortRun-.NET 8.0 | 100.00 MB       | Parallel            | Default      | 19.443 s | 12.0313 s | 0.6595 s | 0.3807 s | 18.726 s | 19.152 s | 19.577 s | 19.801 s | 20.024 s | 0.0514 |    2 | 256000.0000 | 12000.0000 | 3000.0000 | 20322.02 MB |
| **SortFile** | **ShortRun**          | **100.00 MB**       | **Parallel**            | **Quick**        | **19.818 s** |  **2.2873 s** | **0.1254 s** | **0.0724 s** | **19.724 s** | **19.747 s** | **19.770 s** | **19.865 s** | **19.960 s** | **0.0505** |    **2** | **278000.0000** | **12000.0000** | **3000.0000** | **22102.75 MB** |
| SortFile | ShortRun-.NET 8.0 | 100.00 MB       | Parallel            | Quick        | 19.890 s |  5.1835 s | 0.2841 s | 0.1640 s | 19.574 s | 19.774 s | 19.974 s | 20.048 s | 20.123 s | 0.0503 |    2 | 282000.0000 | 12000.0000 | 3000.0000 | 22425.79 MB |
| **SortFile** | **ShortRun**          | **100.00 MB**       | **MemoryMapped**        | **Default**      | **17.109 s** |  **2.8459 s** | **0.1560 s** | **0.0901 s** | **17.013 s** | **17.019 s** | **17.025 s** | **17.157 s** | **17.289 s** | **0.0584** |    **2** | **239000.0000** | **19000.0000** | **3000.0000** | **18968.31 MB** |
| SortFile | ShortRun-.NET 8.0 | 100.00 MB       | MemoryMapped        | Default      | 17.032 s |  4.5603 s | 0.2500 s | 0.1443 s | 16.824 s | 16.893 s | 16.962 s | 17.136 s | 17.309 s | 0.0587 |    2 | 243000.0000 | 21000.0000 | 5000.0000 | 19124.58 MB |
| **SortFile** | **ShortRun**          | **100.00 MB**       | **MemoryMapped**        | **Quick**        | **18.967 s** |  **2.8598 s** | **0.1568 s** | **0.0905 s** | **18.789 s** | **18.910 s** | **19.031 s** | **19.057 s** | **19.083 s** | **0.0527** |    **2** | **267000.0000** | **21000.0000** | **5000.0000** | **21066.12 MB** |
| SortFile | ShortRun-.NET 8.0 | 100.00 MB       | MemoryMapped        | Quick        | 19.033 s |  4.2692 s | 0.2340 s | 0.1351 s | 18.888 s | 18.899 s | 18.909 s | 19.106 s | 19.303 s | 0.0525 |    2 | 277000.0000 | 19000.0000 | 3000.0000 | 22037.74 MB |
| **SortFile** | **ShortRun**          | **100.00 MB**       | **ChunkedMemoryMapped** | **Default**      |       **NA** |        **NA** |       **NA** |       **NA** |       **NA** |       **NA** |       **NA** |       **NA** |       **NA** |     **NA** |    **?** |          **NA** |         **NA** |        **NA** |          **NA** |
| SortFile | ShortRun-.NET 8.0 | 100.00 MB       | ChunkedMemoryMapped | Default      |       NA |        NA |       NA |       NA |       NA |       NA |       NA |       NA |       NA |     NA |    ? |          NA |         NA |        NA |          NA |
| **SortFile** | **ShortRun**          | **100.00 MB**       | **ChunkedMemoryMapped** | **Quick**        |       **NA** |        **NA** |       **NA** |       **NA** |       **NA** |       **NA** |       **NA** |       **NA** |       **NA** |     **NA** |    **?** |          **NA** |         **NA** |        **NA** |          **NA** |
| SortFile | ShortRun-.NET 8.0 | 100.00 MB       | ChunkedMemoryMapped | Quick        |       NA |        NA |       NA |       NA |       NA |       NA |       NA |       NA |       NA |     NA |    ? |          NA |         NA |        NA |          NA |
| **SortFile** | **ShortRun**          | **50.00 MB**        | **ExternalMerge**       | **Default**      |  **8.998 s** |  **3.5105 s** | **0.1924 s** | **0.1111 s** |  **8.791 s** |  **8.910 s** |  **9.030 s** |  **9.101 s** |  **9.172 s** | **0.1111** |    **1** | **123000.0000** |  **7000.0000** | **2000.0000** |  **9794.97 MB** |
| SortFile | ShortRun-.NET 8.0 | 50.00 MB        | ExternalMerge       | Default      |  8.741 s |  0.7154 s | 0.0392 s | 0.0226 s |  8.701 s |  8.722 s |  8.744 s |  8.761 s |  8.779 s | 0.1144 |    1 | 123000.0000 |  7000.0000 | 2000.0000 |   9770.5 MB |
| **SortFile** | **ShortRun**          | **50.00 MB**        | **ExternalMerge**       | **Quick**        |  **9.195 s** |  **1.0417 s** | **0.0571 s** | **0.0330 s** |  **9.129 s** |  **9.176 s** |  **9.223 s** |  **9.228 s** |  **9.233 s** | **0.1088** |    **1** | **133000.0000** |  **7000.0000** | **2000.0000** |  **10527.4 MB** |
| SortFile | ShortRun-.NET 8.0 | 50.00 MB        | ExternalMerge       | Quick        |  9.339 s |  0.1210 s | 0.0066 s | 0.0038 s |  9.331 s |  9.336 s |  9.342 s |  9.343 s |  9.343 s | 0.1071 |    1 | 137000.0000 |  7000.0000 | 2000.0000 | 10910.23 MB |
| **SortFile** | **ShortRun**          | **50.00 MB**        | **KWayMerge**           | **Default**      |  **8.691 s** |  **3.1143 s** | **0.1707 s** | **0.0986 s** |  **8.519 s** |  **8.607 s** |  **8.695 s** |  **8.778 s** |  **8.860 s** | **0.1151** |    **1** | **122000.0000** |  **7000.0000** | **2000.0000** |  **9652.91 MB** |
| SortFile | ShortRun-.NET 8.0 | 50.00 MB        | KWayMerge           | Default      |  8.560 s |  0.0609 s | 0.0033 s | 0.0019 s |  8.556 s |  8.558 s |  8.560 s |  8.562 s |  8.563 s | 0.1168 |    1 | 123000.0000 |  7000.0000 | 2000.0000 |  9790.99 MB |
| **SortFile** | **ShortRun**          | **50.00 MB**        | **KWayMerge**           | **Quick**        |  **9.907 s** |  **0.9185 s** | **0.0503 s** | **0.0291 s** |  **9.873 s** |  **9.878 s** |  **9.882 s** |  **9.923 s** |  **9.964 s** | **0.1009** |    **1** | **137000.0000** |  **7000.0000** | **2000.0000** | **10858.44 MB** |
| SortFile | ShortRun-.NET 8.0 | 50.00 MB        | KWayMerge           | Quick        |  9.603 s |  2.2818 s | 0.1251 s | 0.0722 s |  9.486 s |  9.537 s |  9.588 s |  9.661 s |  9.735 s | 0.1041 |    1 | 130000.0000 |  7000.0000 | 2000.0000 | 10329.03 MB |
| **SortFile** | **ShortRun**          | **50.00 MB**        | **Parallel**            | **Default**      |  **9.284 s** |  **1.3502 s** | **0.0740 s** | **0.0427 s** |  **9.210 s** |  **9.246 s** |  **9.282 s** |  **9.320 s** |  **9.358 s** | **0.1077** |    **1** | **121000.0000** |  **7000.0000** | **2000.0000** |  **9636.03 MB** |
| SortFile | ShortRun-.NET 8.0 | 50.00 MB        | Parallel            | Default      |  9.450 s |  0.4932 s | 0.0270 s | 0.0156 s |  9.419 s |  9.441 s |  9.462 s |  9.466 s |  9.469 s | 0.1058 |    1 | 123000.0000 |  7000.0000 | 2000.0000 |  9796.36 MB |
| **SortFile** | **ShortRun**          | **50.00 MB**        | **Parallel**            | **Quick**        | **10.327 s** |  **2.2093 s** | **0.1211 s** | **0.0699 s** | **10.228 s** | **10.260 s** | **10.292 s** | **10.377 s** | **10.462 s** | **0.0968** |    **1** | **131000.0000** |  **7000.0000** | **2000.0000** | **10452.84 MB** |
| SortFile | ShortRun-.NET 8.0 | 50.00 MB        | Parallel            | Quick        |  9.701 s |  5.1691 s | 0.2833 s | 0.1636 s |  9.462 s |  9.544 s |  9.627 s |  9.820 s | 10.014 s | 0.1031 |    1 | 134000.0000 |  7000.0000 | 2000.0000 | 10685.56 MB |
| **SortFile** | **ShortRun**          | **50.00 MB**        | **MemoryMapped**        | **Default**      |  **8.262 s** |  **1.6592 s** | **0.0909 s** | **0.0525 s** |  **8.190 s** |  **8.211 s** |  **8.231 s** |  **8.298 s** |  **8.364 s** | **0.1210** |    **1** | **117000.0000** | **12000.0000** | **4000.0000** |  **9136.37 MB** |
| SortFile | ShortRun-.NET 8.0 | 50.00 MB        | MemoryMapped        | Default      |  8.099 s |  0.6414 s | 0.0352 s | 0.0203 s |  8.061 s |  8.083 s |  8.106 s |  8.118 s |  8.130 s | 0.1235 |    1 | 115000.0000 | 11000.0000 | 3000.0000 |  9098.11 MB |
| **SortFile** | **ShortRun**          | **50.00 MB**        | **MemoryMapped**        | **Quick**        |  **8.492 s** |  **2.3736 s** | **0.1301 s** | **0.0751 s** |  **8.385 s** |  **8.419 s** |  **8.454 s** |  **8.545 s** |  **8.637 s** | **0.1178** |    **1** | **124000.0000** | **11000.0000** | **3000.0000** |  **9783.08 MB** |
| SortFile | ShortRun-.NET 8.0 | 50.00 MB        | MemoryMapped        | Quick        |  8.888 s |  2.9713 s | 0.1629 s | 0.0940 s |  8.784 s |  8.794 s |  8.804 s |  8.940 s |  9.076 s | 0.1125 |    1 | 130000.0000 | 12000.0000 | 4000.0000 | 10167.56 MB |
| **SortFile** | **ShortRun**          | **50.00 MB**        | **ChunkedMemoryMapped** | **Default**      |       **NA** |        **NA** |       **NA** |       **NA** |       **NA** |       **NA** |       **NA** |       **NA** |       **NA** |     **NA** |    **?** |          **NA** |         **NA** |        **NA** |          **NA** |
| SortFile | ShortRun-.NET 8.0 | 50.00 MB        | ChunkedMemoryMapped | Default      |       NA |        NA |       NA |       NA |       NA |       NA |       NA |       NA |       NA |     NA |    ? |          NA |         NA |        NA |          NA |
| **SortFile** | **ShortRun**          | **50.00 MB**        | **ChunkedMemoryMapped** | **Quick**        |       **NA** |        **NA** |       **NA** |       **NA** |       **NA** |       **NA** |       **NA** |       **NA** |       **NA** |     **NA** |    **?** |          **NA** |         **NA** |        **NA** |          **NA** |
| SortFile | ShortRun-.NET 8.0 | 50.00 MB        | ChunkedMemoryMapped | Quick        |       NA |        NA |       NA |       NA |       NA |       NA |       NA |       NA |       NA |     NA |    ? |          NA |         NA |        NA |          NA |

Benchmarks with issues:
  FileSorterBenchmark.SortFile: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [FileSizeInBytes=100.00 MB, Sorter=ChunkedMemoryMapped, MemorySorter=Default]
  FileSorterBenchmark.SortFile: ShortRun-.NET 8.0(Runtime=.NET 8.0, IterationCount=3, LaunchCount=1, WarmupCount=3) [FileSizeInBytes=100.00 MB, Sorter=ChunkedMemoryMapped, MemorySorter=Default]
  FileSorterBenchmark.SortFile: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [FileSizeInBytes=100.00 MB, Sorter=ChunkedMemoryMapped, MemorySorter=Quick]
  FileSorterBenchmark.SortFile: ShortRun-.NET 8.0(Runtime=.NET 8.0, IterationCount=3, LaunchCount=1, WarmupCount=3) [FileSizeInBytes=100.00 MB, Sorter=ChunkedMemoryMapped, MemorySorter=Quick]
  FileSorterBenchmark.SortFile: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [FileSizeInBytes=50.00 MB, Sorter=ChunkedMemoryMapped, MemorySorter=Default]
  FileSorterBenchmark.SortFile: ShortRun-.NET 8.0(Runtime=.NET 8.0, IterationCount=3, LaunchCount=1, WarmupCount=3) [FileSizeInBytes=50.00 MB, Sorter=ChunkedMemoryMapped, MemorySorter=Default]
  FileSorterBenchmark.SortFile: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [FileSizeInBytes=50.00 MB, Sorter=ChunkedMemoryMapped, MemorySorter=Quick]
  FileSorterBenchmark.SortFile: ShortRun-.NET 8.0(Runtime=.NET 8.0, IterationCount=3, LaunchCount=1, WarmupCount=3) [FileSizeInBytes=50.00 MB, Sorter=ChunkedMemoryMapped, MemorySorter=Quick]
### Performance Barplot
![Benchmark Barplot](.docs/data/FileAlgorithms.Benchmark.Benchmark.FileGeneratorBenchmark-barplot.png)

### Performance Barplot
![Benchmark Barplot](.docs/data/FileAlgorithms.Benchmark.Benchmark.FileSorterBenchmark-barplot.png)

### Performance Boxplot
![Benchmark Boxplot](.docs/data/FileAlgorithms.Benchmark.Benchmark.FileGeneratorBenchmark-boxplot.png)

### Performance Boxplot
![Benchmark Boxplot](.docs/data/FileAlgorithms.Benchmark.Benchmark.FileSorterBenchmark-boxplot.png)

<!-- BENCHMARK RESULTS END -->
