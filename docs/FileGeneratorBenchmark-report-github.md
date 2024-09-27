```

BenchmarkDotNet v0.14.0, Ubuntu 22.04.5 LTS (Jammy Jellyfish)
AMD EPYC 7763, 1 CPU, 2 logical cores and 1 physical core
.NET SDK 8.0.402
  [Host]   : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  ShortRun : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Server=True  

```
| Method       | Job       | Toolchain              | IterationCount | LaunchCount | WarmupCount | FileSizeInBytes | Mean       | Error       | StdDev    | Min        | Max        | Q1         | Q3         | Median     | Gen0    | Gen1    | Gen2    | Allocated  |
|------------- |---------- |----------------------- |--------------- |------------ |------------ |---------------- |-----------:|------------:|----------:|-----------:|-----------:|-----------:|-----------:|-----------:|--------:|--------:|--------:|-----------:|
| **GenerateFile** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **1024**            |   **300.0 μs** |     **5.64 μs** |  **10.73 μs** |   **282.6 μs** |   **322.7 μs** |   **292.6 μs** |   **307.0 μs** |   **297.2 μs** | **99.6094** | **99.6094** | **99.6094** |  **330.99 KB** |
| GenerateFile | ShortRun  | Default                | 3              | 1           | 3           | 1024            |   302.4 μs |   157.16 μs |   8.61 μs |   293.7 μs |   310.9 μs |   298.2 μs |   306.8 μs |   302.6 μs | 64.4531 | 64.4531 | 64.4531 |  331.19 KB |
| **GenerateFile** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **1048576**         | **7,854.4 μs** |   **154.18 μs** | **177.55 μs** | **7,634.3 μs** | **8,300.4 μs** | **7,714.4 μs** | **7,966.0 μs** | **7,813.7 μs** | **93.7500** | **93.7500** | **93.7500** | **6312.68 KB** |
| GenerateFile | ShortRun  | Default                | 3              | 1           | 3           | 1048576         | 7,964.1 μs | 4,870.71 μs | 266.98 μs | 7,748.7 μs | 8,262.8 μs | 7,814.8 μs | 8,071.8 μs | 7,880.8 μs | 78.1250 | 62.5000 | 62.5000 | 6312.86 KB |
