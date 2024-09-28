```

BenchmarkDotNet v0.14.0, Ubuntu 22.04.5 LTS (Jammy Jellyfish)
AMD EPYC 7763, 1 CPU, 2 logical cores and 1 physical core
.NET SDK 8.0.402
  [Host]     : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  Job-EUUUYH : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Server=True  

```
| Method       | FileSizeInBytes | Generator    | FileSize | Mean       | Error     | StdDev    | StdErr   | Median     | Min        | Max        | Rank | Gen0       | Gen1      | Gen2      | Allocated  |
|------------- |---------------- |------------- |--------- |-----------:|----------:|----------:|---------:|-----------:|-----------:|-----------:|-----:|-----------:|----------:|----------:|-----------:|
| GenerateFile | 100.00 MB       | Parallel     | ?        |   526.0 ms |  11.54 ms |  34.04 ms |  3.40 ms |   517.1 ms |   471.9 ms |   613.2 ms |    1 |  1000.0000 | 1000.0000 | 1000.0000 |  364.02 MB |
| GenerateFile | 100.00 MB       | Buffered     | ?        |   652.3 ms |  13.00 ms |  29.62 ms |  3.76 ms |   648.0 ms |   581.1 ms |   725.7 ms |    2 |  1000.0000 |         - |         - |  500.37 MB |
| GenerateFile | 100.00 MB       | Original     | ?        |   705.2 ms |  13.96 ms |  38.23 ms |  4.10 ms |   704.9 ms |   582.9 ms |   769.1 ms |    3 |  1000.0000 |         - |         - |  585.05 MB |
| GenerateFile | 100.00 MB       | MemoryMapped | ?        |   886.7 ms |   5.34 ms |   4.17 ms |  1.20 ms |   885.3 ms |   883.2 ms |   896.5 ms |    4 |  1000.0000 |         - |         - |  507.41 MB |
| GenerateFile | 500.00 MB       | Parallel     | ?        | 4,129.1 ms |  87.87 ms | 250.71 ms | 25.86 ms | 4,179.0 ms | 3,384.0 ms | 4,684.0 ms |    5 |  7000.0000 | 6000.0000 | 3000.0000 | 1818.69 MB |
| GenerateFile | 500.00 MB       | Buffered     | ?        | 4,299.9 ms |  85.90 ms | 213.91 ms | 25.04 ms | 4,373.4 ms | 3,539.9 ms | 4,637.2 ms |    5 |  7000.0000 |         - |         - | 2500.15 MB |
| GenerateFile | 500.00 MB       | Original     | ?        | 4,653.3 ms | 119.79 ms | 349.43 ms | 35.30 ms | 4,753.1 ms | 3,498.0 ms | 5,031.7 ms |    6 |  9000.0000 |         - |         - | 2923.91 MB |
| GenerateFile | 500.00 MB       | MemoryMapped | ?        | 5,431.9 ms | 106.96 ms | 234.79 ms | 30.83 ms | 5,454.0 ms | 4,116.1 ms | 5,660.3 ms |    7 |  8000.0000 |         - |         - | 2537.43 MB |
| GenerateFile | 1.00 GB         | Parallel     | ?        | 7,057.6 ms | 140.52 ms | 311.39 ms | 40.54 ms | 7,123.3 ms | 6,111.3 ms | 7,593.2 ms |    8 | 10000.0000 | 9000.0000 | 1000.0000 | 3196.85 MB |
| GenerateFile | 1.00 GB         | Buffered     | ?        | 7,168.5 ms | 142.46 ms | 411.03 ms | 41.95 ms | 7,225.5 ms | 6,383.3 ms | 7,903.5 ms |    8 | 16000.0000 |         - |         - |  5120.1 MB |
| GenerateFile | 1.00 GB         | Original     | ?        | 7,685.1 ms | 153.40 ms | 440.15 ms | 45.16 ms | 7,730.1 ms | 6,637.5 ms | 8,656.9 ms |    9 | 19000.0000 |         - |         - | 5987.74 MB |
| GenerateFile | 1.00 GB         | MemoryMapped | ?        | 9,385.2 ms | 186.67 ms | 331.81 ms | 52.46 ms | 9,545.2 ms | 8,581.1 ms | 9,789.5 ms |   10 | 16000.0000 |         - |         - | 5196.53 MB |
