<!-- BENCHMARK RESULTS START -->

## Benchmark Results

*Last updated on Wed Oct  2 04:02:27 UTC 2024 UTC*

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
| **GenerateFile** | **ShortRun**          | **1.00 GB**         | **Original**     |  **8.6387 s** | **20.8571 s** | **1.1432 s** | **0.6601 s** |  **7.3315 s** |  **8.2322 s** |  **9.1330 s** |  **9.2923 s** |  **9.4517 s** | **0.1158** |    **4** |  **75000.0000** |           **-** |           **-** | **5992.19 MB** |
| GenerateFile | ShortRun-.NET 8.0 | 1.00 GB         | Original     |  8.1814 s | 19.5742 s | 1.0729 s | 0.6195 s |  7.2327 s |  7.5992 s |  7.9657 s |  8.6557 s |  9.3458 s | 0.1222 |    4 |  75000.0000 |           - |           - |  5992.1 MB |
| **GenerateFile** | **ShortRun**          | **1.00 GB**         | **Buffered**     |  **7.8457 s** | **17.5488 s** | **0.9619 s** | **0.5554 s** |  **6.7379 s** |  **7.5334 s** |  **8.3289 s** |  **8.3995 s** |  **8.4701 s** | **0.1275** |    **4** | **668000.0000** | **630000.0000** | **630000.0000** | **5127.18 MB** |
| GenerateFile | ShortRun-.NET 8.0 | 1.00 GB         | Buffered     |  7.8680 s | 18.3661 s | 1.0067 s | 0.5812 s |  6.7102 s |  7.5335 s |  8.3568 s |  8.4469 s |  8.5369 s | 0.1271 |    4 | 667000.0000 | 629000.0000 | 629000.0000 | 5127.17 MB |
| **GenerateFile** | **ShortRun**          | **1.00 GB**         | **Parallel**     |  **5.6943 s** |  **0.1231 s** | **0.0067 s** | **0.0039 s** |  **5.6865 s** |  **5.6920 s** |  **5.6975 s** |  **5.6981 s** |  **5.6988 s** | **0.1756** |    **3** |   **6000.0000** |   **6000.0000** |   **6000.0000** | **4100.05 MB** |
| GenerateFile | ShortRun-.NET 8.0 | 1.00 GB         | Parallel     |  5.9434 s |  4.7135 s | 0.2584 s | 0.1492 s |  5.7936 s |  5.7942 s |  5.7949 s |  6.0183 s |  6.2417 s | 0.1683 |    3 |   6000.0000 |   6000.0000 |   6000.0000 | 4100.03 MB |
| **GenerateFile** | **ShortRun**          | **1.00 GB**         | **MemoryMapped** |  **9.9824 s** |  **0.8129 s** | **0.0446 s** | **0.0257 s** |  **9.9490 s** |  **9.9571 s** |  **9.9652 s** |  **9.9991 s** | **10.0330 s** | **0.1002** |    **4** | **101000.0000** |           **-** |           **-** | **8115.29 MB** |
| GenerateFile | ShortRun-.NET 8.0 | 1.00 GB         | MemoryMapped | 10.0619 s |  0.5805 s | 0.0318 s | 0.0184 s | 10.0405 s | 10.0436 s | 10.0468 s | 10.0726 s | 10.0984 s | 0.0994 |    4 | 101000.0000 |           - |           - | 8115.31 MB |
| **GenerateFile** | **ShortRun**          | **100.00 MB**       | **Original**     |  **0.7656 s** |  **0.7753 s** | **0.0425 s** | **0.0245 s** |  **0.7220 s** |  **0.7449 s** |  **0.7677 s** |  **0.7873 s** |  **0.8069 s** | **1.3062** |    **2** |   **7000.0000** |           **-** |           **-** |  **585.45 MB** |
| GenerateFile | ShortRun-.NET 8.0 | 100.00 MB       | Original     |  0.8471 s |  0.1426 s | 0.0078 s | 0.0045 s |  0.8396 s |  0.8431 s |  0.8465 s |  0.8509 s |  0.8552 s | 1.1805 |    2 |   7000.0000 |           - |           - |  585.47 MB |
| **GenerateFile** | **ShortRun**          | **100.00 MB**       | **Buffered**     |  **0.7488 s** |  **0.4859 s** | **0.0266 s** | **0.0154 s** |  **0.7237 s** |  **0.7348 s** |  **0.7460 s** |  **0.7613 s** |  **0.7767 s** | **1.3355** |    **2** |  **63000.0000** |  **60000.0000** |  **60000.0000** |   **502.8 MB** |
| GenerateFile | ShortRun-.NET 8.0 | 100.00 MB       | Buffered     |  0.7045 s |  0.4453 s | 0.0244 s | 0.0141 s |  0.6769 s |  0.6952 s |  0.7135 s |  0.7183 s |  0.7232 s | 1.4194 |    2 |  63000.0000 |  60000.0000 |  60000.0000 |  502.75 MB |
| **GenerateFile** | **ShortRun**          | **100.00 MB**       | **Parallel**     |  **0.5513 s** |  **0.1256 s** | **0.0069 s** | **0.0040 s** |  **0.5443 s** |  **0.5479 s** |  **0.5516 s** |  **0.5548 s** |  **0.5581 s** | **1.8138** |    **1** |   **3000.0000** |   **3000.0000** |   **3000.0000** |  **440.73 MB** |
| GenerateFile | ShortRun-.NET 8.0 | 100.00 MB       | Parallel     |  0.5542 s |  0.1398 s | 0.0077 s | 0.0044 s |  0.5468 s |  0.5502 s |  0.5537 s |  0.5579 s |  0.5621 s | 1.8044 |    1 |   2000.0000 |   2000.0000 |   2000.0000 |  440.76 MB |
| **GenerateFile** | **ShortRun**          | **100.00 MB**       | **MemoryMapped** |  **0.8974 s** |  **0.1574 s** | **0.0086 s** | **0.0050 s** |  **0.8891 s** |  **0.8929 s** |  **0.8966 s** |  **0.9015 s** |  **0.9063 s** | **1.1144** |    **2** |   **9000.0000** |           **-** |           **-** |  **792.48 MB** |
| GenerateFile | ShortRun-.NET 8.0 | 100.00 MB       | MemoryMapped |  0.8993 s |  0.2143 s | 0.0117 s | 0.0068 s |  0.8877 s |  0.8933 s |  0.8989 s |  0.9050 s |  0.9112 s | 1.1120 |    2 |   9000.0000 |           - |           - |  792.52 MB |
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
| Method   | Job               | FileSizeInBytes | Sorter              | MemorySorter | Mean     | Error    | StdDev   | StdErr   | Min      | Q1       | Median   | Q3       | Max      | Op/s   | Rank | Gen0        | Gen1       | Gen2      | Allocated   |
|--------- |------------------ |---------------- |-------------------- |------------- |---------:|---------:|---------:|---------:|---------:|---------:|---------:|---------:|---------:|-------:|-----:|------------:|-----------:|----------:|------------:|
| **SortFile** | **ShortRun**          | **100.00 MB**       | **ExternalMerge**       | **Default**      | **19.141 s** | **4.3969 s** | **0.2410 s** | **0.1391 s** | **18.870 s** | **19.045 s** | **19.221 s** | **19.276 s** | **19.332 s** | **0.0522** |    **2** | **254000.0000** | **12000.0000** | **3000.0000** | **20170.16 MB** |
| SortFile | ShortRun-.NET 8.0 | 100.00 MB       | ExternalMerge       | Default      | 18.827 s | 0.3865 s | 0.0212 s | 0.0122 s | 18.810 s | 18.815 s | 18.821 s | 18.836 s | 18.851 s | 0.0531 |    2 | 255000.0000 | 12000.0000 | 3000.0000 |  20223.8 MB |
| **SortFile** | **ShortRun**          | **100.00 MB**       | **ExternalMerge**       | **Quick**        | **20.874 s** | **2.6134 s** | **0.1432 s** | **0.0827 s** | **20.766 s** | **20.793 s** | **20.819 s** | **20.928 s** | **21.037 s** | **0.0479** |    **2** | **282000.0000** | **12000.0000** | **3000.0000** | **22377.36 MB** |
| SortFile | ShortRun-.NET 8.0 | 100.00 MB       | ExternalMerge       | Quick        | 20.254 s | 1.3737 s | 0.0753 s | 0.0435 s | 20.177 s | 20.218 s | 20.260 s | 20.293 s | 20.327 s | 0.0494 |    2 | 277000.0000 | 12000.0000 | 3000.0000 | 22013.38 MB |
| **SortFile** | **ShortRun**          | **100.00 MB**       | **KWayMerge**           | **Default**      | **19.472 s** | **1.5626 s** | **0.0857 s** | **0.0495 s** | **19.374 s** | **19.442 s** | **19.511 s** | **19.521 s** | **19.531 s** | **0.0514** |    **2** | **258000.0000** | **12000.0000** | **3000.0000** | **20468.75 MB** |
| SortFile | ShortRun-.NET 8.0 | 100.00 MB       | KWayMerge           | Default      | 18.703 s | 2.9720 s | 0.1629 s | 0.0941 s | 18.517 s | 18.646 s | 18.776 s | 18.797 s | 18.817 s | 0.0535 |    2 | 253000.0000 | 12000.0000 | 3000.0000 |  20092.5 MB |
| **SortFile** | **ShortRun**          | **100.00 MB**       | **KWayMerge**           | **Quick**        | **20.540 s** | **0.5950 s** | **0.0326 s** | **0.0188 s** | **20.508 s** | **20.523 s** | **20.537 s** | **20.555 s** | **20.574 s** | **0.0487** |    **2** | **274000.0000** | **12000.0000** | **3000.0000** | **21765.14 MB** |
| SortFile | ShortRun-.NET 8.0 | 100.00 MB       | KWayMerge           | Quick        | 20.530 s | 0.6973 s | 0.0382 s | 0.0221 s | 20.489 s | 20.513 s | 20.537 s | 20.551 s | 20.564 s | 0.0487 |    2 | 280000.0000 | 12000.0000 | 3000.0000 | 22213.82 MB |
| **SortFile** | **ShortRun**          | **100.00 MB**       | **Parallel**            | **Default**      | **19.394 s** | **3.3397 s** | **0.1831 s** | **0.1057 s** | **19.211 s** | **19.303 s** | **19.394 s** | **19.486 s** | **19.577 s** | **0.0516** |    **2** | **259000.0000** | **12000.0000** | **3000.0000** | **20573.05 MB** |
| SortFile | ShortRun-.NET 8.0 | 100.00 MB       | Parallel            | Default      | 18.719 s | 1.7037 s | 0.0934 s | 0.0539 s | 18.658 s | 18.666 s | 18.673 s | 18.750 s | 18.827 s | 0.0534 |    2 | 253000.0000 | 12000.0000 | 3000.0000 | 20099.27 MB |
| **SortFile** | **ShortRun**          | **100.00 MB**       | **Parallel**            | **Quick**        | **20.669 s** | **1.7171 s** | **0.0941 s** | **0.0543 s** | **20.613 s** | **20.615 s** | **20.617 s** | **20.698 s** | **20.778 s** | **0.0484** |    **2** | **285000.0000** | **12000.0000** | **3000.0000** | **22699.31 MB** |
| SortFile | ShortRun-.NET 8.0 | 100.00 MB       | Parallel            | Quick        | 20.966 s | 1.9877 s | 0.1090 s | 0.0629 s | 20.843 s | 20.926 s | 21.008 s | 21.028 s | 21.048 s | 0.0477 |    2 | 285000.0000 | 12000.0000 | 3000.0000 | 22684.08 MB |
| **SortFile** | **ShortRun**          | **100.00 MB**       | **MemoryMapped**        | **Default**      | **17.878 s** | **1.0956 s** | **0.0601 s** | **0.0347 s** | **17.824 s** | **17.846 s** | **17.869 s** | **17.906 s** | **17.943 s** | **0.0559** |    **2** | **245000.0000** | **19000.0000** | **3000.0000** | **19468.37 MB** |
| SortFile | ShortRun-.NET 8.0 | 100.00 MB       | MemoryMapped        | Default      | 17.357 s | 1.8557 s | 0.1017 s | 0.0587 s | 17.282 s | 17.299 s | 17.316 s | 17.394 s | 17.473 s | 0.0576 |    2 | 242000.0000 | 19000.0000 | 3000.0000 | 19235.38 MB |
| **SortFile** | **ShortRun**          | **100.00 MB**       | **MemoryMapped**        | **Quick**        | **18.680 s** | **0.3895 s** | **0.0214 s** | **0.0123 s** | **18.656 s** | **18.671 s** | **18.687 s** | **18.692 s** | **18.697 s** | **0.0535** |    **2** | **259000.0000** | **19000.0000** | **3000.0000** | **20627.31 MB** |
| SortFile | ShortRun-.NET 8.0 | 100.00 MB       | MemoryMapped        | Quick        | 19.731 s | 2.1988 s | 0.1205 s | 0.0696 s | 19.631 s | 19.663 s | 19.695 s | 19.780 s | 19.865 s | 0.0507 |    2 | 264000.0000 | 18000.0000 | 2000.0000 | 21051.26 MB |
| **SortFile** | **ShortRun**          | **100.00 MB**       | **ChunkedMemoryMapped** | **Default**      |       **NA** |       **NA** |       **NA** |       **NA** |       **NA** |       **NA** |       **NA** |       **NA** |       **NA** |     **NA** |    **?** |          **NA** |         **NA** |        **NA** |          **NA** |
| SortFile | ShortRun-.NET 8.0 | 100.00 MB       | ChunkedMemoryMapped | Default      |       NA |       NA |       NA |       NA |       NA |       NA |       NA |       NA |       NA |     NA |    ? |          NA |         NA |        NA |          NA |
| **SortFile** | **ShortRun**          | **100.00 MB**       | **ChunkedMemoryMapped** | **Quick**        |       **NA** |       **NA** |       **NA** |       **NA** |       **NA** |       **NA** |       **NA** |       **NA** |       **NA** |     **NA** |    **?** |          **NA** |         **NA** |        **NA** |          **NA** |
| SortFile | ShortRun-.NET 8.0 | 100.00 MB       | ChunkedMemoryMapped | Quick        |       NA |       NA |       NA |       NA |       NA |       NA |       NA |       NA |       NA |     NA |    ? |          NA |         NA |        NA |          NA |
| **SortFile** | **ShortRun**          | **50.00 MB**        | **ExternalMerge**       | **Default**      |  **8.957 s** | **1.5580 s** | **0.0854 s** | **0.0493 s** |  **8.868 s** |  **8.916 s** |  **8.965 s** |  **9.001 s** |  **9.038 s** | **0.1116** |    **1** | **122000.0000** |  **7000.0000** | **2000.0000** |  **9658.03 MB** |
| SortFile | ShortRun-.NET 8.0 | 50.00 MB        | ExternalMerge       | Default      |  8.760 s | 0.7032 s | 0.0385 s | 0.0223 s |  8.737 s |  8.738 s |  8.738 s |  8.771 s |  8.804 s | 0.1142 |    1 | 122000.0000 |  7000.0000 | 2000.0000 |  9696.75 MB |
| **SortFile** | **ShortRun**          | **50.00 MB**        | **ExternalMerge**       | **Quick**        |  **9.322 s** | **1.7268 s** | **0.0947 s** | **0.0546 s** |  **9.262 s** |  **9.267 s** |  **9.272 s** |  **9.351 s** |  **9.431 s** | **0.1073** |    **1** | **132000.0000** |  **7000.0000** | **2000.0000** | **10476.98 MB** |
| SortFile | ShortRun-.NET 8.0 | 50.00 MB        | ExternalMerge       | Quick        |  9.530 s | 1.3938 s | 0.0764 s | 0.0441 s |  9.448 s |  9.496 s |  9.544 s |  9.571 s |  9.598 s | 0.1049 |    1 | 133000.0000 |  7000.0000 | 2000.0000 | 10518.21 MB |
| **SortFile** | **ShortRun**          | **50.00 MB**        | **KWayMerge**           | **Default**      |  **8.718 s** | **0.8460 s** | **0.0464 s** | **0.0268 s** |  **8.685 s** |  **8.692 s** |  **8.699 s** |  **8.735 s** |  **8.771 s** | **0.1147** |    **1** | **121000.0000** |  **7000.0000** | **2000.0000** |   **9613.5 MB** |
| SortFile | ShortRun-.NET 8.0 | 50.00 MB        | KWayMerge           | Default      |  8.690 s | 0.5151 s | 0.0282 s | 0.0163 s |  8.661 s |  8.676 s |  8.691 s |  8.704 s |  8.717 s | 0.1151 |    1 | 120000.0000 |  7000.0000 | 2000.0000 |  9558.79 MB |
| **SortFile** | **ShortRun**          | **50.00 MB**        | **KWayMerge**           | **Quick**        |  **9.462 s** | **0.1942 s** | **0.0106 s** | **0.0061 s** |  **9.453 s** |  **9.457 s** |  **9.460 s** |  **9.467 s** |  **9.474 s** | **0.1057** |    **1** | **132000.0000** |  **7000.0000** | **2000.0000** | **10495.75 MB** |
| SortFile | ShortRun-.NET 8.0 | 50.00 MB        | KWayMerge           | Quick        |  9.643 s | 0.4808 s | 0.0264 s | 0.0152 s |  9.616 s |  9.631 s |  9.645 s |  9.657 s |  9.669 s | 0.1037 |    1 | 135000.0000 |  7000.0000 | 2000.0000 | 10701.23 MB |
| **SortFile** | **ShortRun**          | **50.00 MB**        | **Parallel**            | **Default**      |  **8.888 s** | **1.4295 s** | **0.0784 s** | **0.0452 s** |  **8.800 s** |  **8.858 s** |  **8.917 s** |  **8.932 s** |  **8.948 s** | **0.1125** |    **1** | **121000.0000** |  **7000.0000** | **2000.0000** |   **9591.5 MB** |
| SortFile | ShortRun-.NET 8.0 | 50.00 MB        | Parallel            | Default      |  8.766 s | 1.2083 s | 0.0662 s | 0.0382 s |  8.694 s |  8.738 s |  8.781 s |  8.802 s |  8.824 s | 0.1141 |    1 | 123000.0000 |  7000.0000 | 2000.0000 |  9752.93 MB |
| **SortFile** | **ShortRun**          | **50.00 MB**        | **Parallel**            | **Quick**        |  **9.014 s** | **1.0059 s** | **0.0551 s** | **0.0318 s** |  **8.956 s** |  **8.988 s** |  **9.020 s** |  **9.043 s** |  **9.066 s** | **0.1109** |    **1** | **130000.0000** |  **7000.0000** | **2000.0000** | **10306.98 MB** |
| SortFile | ShortRun-.NET 8.0 | 50.00 MB        | Parallel            | Quick        |  9.418 s | 1.5211 s | 0.0834 s | 0.0481 s |  9.337 s |  9.376 s |  9.415 s |  9.459 s |  9.503 s | 0.1062 |    1 | 136000.0000 |  7000.0000 | 2000.0000 | 10840.99 MB |
| **SortFile** | **ShortRun**          | **50.00 MB**        | **MemoryMapped**        | **Default**      |  **8.004 s** | **0.7730 s** | **0.0424 s** | **0.0245 s** |  **7.978 s** |  **7.980 s** |  **7.981 s** |  **8.017 s** |  **8.053 s** | **0.1249** |    **1** | **116000.0000** | **11000.0000** | **3000.0000** |  **9135.81 MB** |
| SortFile | ShortRun-.NET 8.0 | 50.00 MB        | MemoryMapped        | Default      |  7.975 s | 1.3047 s | 0.0715 s | 0.0413 s |  7.894 s |  7.946 s |  7.998 s |  8.015 s |  8.031 s | 0.1254 |    1 | 116000.0000 | 12000.0000 | 4000.0000 |  9100.26 MB |
| **SortFile** | **ShortRun**          | **50.00 MB**        | **MemoryMapped**        | **Quick**        |  **8.903 s** | **2.5078 s** | **0.1375 s** | **0.0794 s** |  **8.773 s** |  **8.831 s** |  **8.890 s** |  **8.968 s** |  **9.047 s** | **0.1123** |    **1** | **127000.0000** | **12000.0000** | **4000.0000** |  **9927.79 MB** |
| SortFile | ShortRun-.NET 8.0 | 50.00 MB        | MemoryMapped        | Quick        |  8.914 s | 1.0713 s | 0.0587 s | 0.0339 s |  8.864 s |  8.882 s |  8.901 s |  8.940 s |  8.979 s | 0.1122 |    1 | 127000.0000 | 12000.0000 | 4000.0000 |   9984.2 MB |
| **SortFile** | **ShortRun**          | **50.00 MB**        | **ChunkedMemoryMapped** | **Default**      |       **NA** |       **NA** |       **NA** |       **NA** |       **NA** |       **NA** |       **NA** |       **NA** |       **NA** |     **NA** |    **?** |          **NA** |         **NA** |        **NA** |          **NA** |
| SortFile | ShortRun-.NET 8.0 | 50.00 MB        | ChunkedMemoryMapped | Default      |       NA |       NA |       NA |       NA |       NA |       NA |       NA |       NA |       NA |     NA |    ? |          NA |         NA |        NA |          NA |
| **SortFile** | **ShortRun**          | **50.00 MB**        | **ChunkedMemoryMapped** | **Quick**        |       **NA** |       **NA** |       **NA** |       **NA** |       **NA** |       **NA** |       **NA** |       **NA** |       **NA** |     **NA** |    **?** |          **NA** |         **NA** |        **NA** |          **NA** |
| SortFile | ShortRun-.NET 8.0 | 50.00 MB        | ChunkedMemoryMapped | Quick        |       NA |       NA |       NA |       NA |       NA |       NA |       NA |       NA |       NA |     NA |    ? |          NA |         NA |        NA |          NA |

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
