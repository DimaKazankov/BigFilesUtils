```

BenchmarkDotNet v0.14.0, Ubuntu 22.04.5 LTS (Jammy Jellyfish)
AMD EPYC 7763, 1 CPU, 2 logical cores and 1 physical core
.NET SDK 8.0.402
  [Host]     : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  Job-RLWWGD : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Server=True  InvocationCount=3  IterationCount=3  
LaunchCount=5  UnrollFactor=1  WarmupCount=2  

```
| Method       | FileSizeInBytes | Generator    | FileSize | Mean      | Error     | StdDev    | StdErr    | Median    | Min       | Max       | Rank | Allocated |
|------------- |---------------- |------------- |--------- |----------:|----------:|----------:|----------:|----------:|----------:|----------:|-----:|----------:|
| GenerateFile | 1.00 GB         | MemoryMapped | ?        | 0.0044 ms | 0.0043 ms | 0.0040 ms | 0.0010 ms | 0.0037 ms | 0.0019 ms | 0.0187 ms |    1 |   0.25 MB |
| GenerateFile | 500.00 MB       | Parallel     | ?        | 0.0192 ms | 0.0087 ms | 0.0081 ms | 0.0021 ms | 0.0164 ms | 0.0104 ms | 0.0379 ms |    2 |   0.08 MB |
| GenerateFile | 500.00 MB       | MemoryMapped | ?        | 0.0192 ms | 0.0365 ms | 0.0342 ms | 0.0088 ms | 0.0036 ms | 0.0019 ms | 0.0870 ms |    3 |   0.66 MB |
| GenerateFile | 100.00 MB       | MemoryMapped | ?        | 0.0364 ms | 0.0954 ms | 0.0892 ms | 0.0230 ms | 0.0036 ms | 0.0019 ms | 0.3423 ms |    3 |   0.22 MB |
| GenerateFile | 100.00 MB       | Parallel     | ?        | 0.0774 ms | 0.1878 ms | 0.1756 ms | 0.0453 ms | 0.0245 ms | 0.0149 ms | 0.6985 ms |    4 |   5.48 MB |
| GenerateFile | 1.00 GB         | Parallel     | ?        | 0.1865 ms | 0.6822 ms | 0.6381 ms | 0.1648 ms | 0.0199 ms | 0.0120 ms | 2.4929 ms |    4 |   0.06 MB |
| GenerateFile | 1.00 GB         | Original     | ?        | 1.5493 ms | 0.5820 ms | 0.5444 ms | 0.1406 ms | 1.1957 ms | 1.1058 ms | 2.5858 ms |    5 |   2.07 MB |
| GenerateFile | 1.00 GB         | Buffered     | ?        | 1.6289 ms | 0.6854 ms | 0.6411 ms | 0.1655 ms | 1.3856 ms | 0.9534 ms | 2.8015 ms |    5 |   2.34 MB |
| GenerateFile | 100.00 MB       | Buffered     | ?        | 1.6657 ms | 0.7995 ms | 0.7479 ms | 0.1931 ms | 1.6464 ms | 0.9577 ms | 3.4793 ms |    5 |   1.89 MB |
| GenerateFile | 500.00 MB       | Original     | ?        | 1.6774 ms | 0.5399 ms | 0.5050 ms | 0.1304 ms | 1.8489 ms | 1.0723 ms | 2.6582 ms |    5 |   1.18 MB |
| GenerateFile | 500.00 MB       | Buffered     | ?        | 1.6810 ms | 0.5598 ms | 0.5237 ms | 0.1352 ms | 1.7292 ms | 1.0285 ms | 2.9686 ms |    5 |   3.13 MB |
| GenerateFile | 100.00 MB       | Original     | ?        | 1.9934 ms | 0.7855 ms | 0.7348 ms | 0.1897 ms | 1.9193 ms | 1.0894 ms | 3.3547 ms |    5 |   1.23 MB |
