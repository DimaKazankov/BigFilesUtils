```

BenchmarkDotNet v0.14.0, Ubuntu 22.04.5 LTS (Jammy Jellyfish)
AMD EPYC 7763, 1 CPU, 2 logical cores and 1 physical core
.NET SDK 8.0.402
  [Host]   : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  ShortRun : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Server=True  

```
| Method    | Job       | Toolchain              | IterationCount | LaunchCount | WarmupCount | Count | Mean      | Error     | StdDev   | Min       | Max       | Q1        | Q3        | Median    | Gen0   | Allocated |
|---------- |---------- |----------------------- |--------------- |------------ |------------ |------ |----------:|----------:|---------:|----------:|----------:|----------:|----------:|----------:|-------:|----------:|
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **1**     |  **46.83 ns** |  **0.117 ns** | **0.098 ns** |  **46.63 ns** |  **47.01 ns** |  **46.76 ns** |  **46.87 ns** |  **46.84 ns** | **0.0015** |     **128 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 1     |  48.73 ns |  3.240 ns | 0.178 ns |  48.59 ns |  48.93 ns |  48.63 ns |  48.80 ns |  48.68 ns | 0.0004 |     128 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **2**     |  **76.32 ns** |  **0.362 ns** | **0.302 ns** |  **75.65 ns** |  **76.74 ns** |  **76.23 ns** |  **76.45 ns** |  **76.40 ns** | **0.0019** |     **168 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 2     |  69.11 ns |  8.601 ns | 0.471 ns |  68.59 ns |  69.52 ns |  68.90 ns |  69.36 ns |  69.21 ns | 0.0005 |     168 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **3**     |  **87.02 ns** |  **0.388 ns** | **0.324 ns** |  **86.39 ns** |  **87.54 ns** |  **86.86 ns** |  **87.15 ns** |  **87.11 ns** | **0.0019** |     **168 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 3     |  72.68 ns |  4.310 ns | 0.236 ns |  72.50 ns |  72.95 ns |  72.54 ns |  72.77 ns |  72.59 ns | 0.0005 |     168 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **5**     | **123.80 ns** |  **1.251 ns** | **1.044 ns** | **121.46 ns** | **125.20 ns** | **123.26 ns** | **124.58 ns** | **123.69 ns** | **0.0026** |     **224 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 5     | 102.99 ns |  5.401 ns | 0.296 ns | 102.77 ns | 103.33 ns | 102.83 ns | 103.11 ns | 102.88 ns | 0.0006 |     224 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **8**     | **152.25 ns** |  **1.603 ns** | **1.499 ns** | **148.25 ns** | **153.53 ns** | **152.06 ns** | **153.18 ns** | **152.70 ns** | **0.0026** |     **224 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 8     | 121.04 ns | 18.248 ns | 1.000 ns | 120.31 ns | 122.18 ns | 120.47 ns | 121.41 ns | 120.64 ns | 0.0005 |     224 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **13**    | **223.61 ns** |  **0.603 ns** | **0.535 ns** | **222.66 ns** | **224.65 ns** | **223.34 ns** | **223.94 ns** | **223.53 ns** | **0.0036** |     **312 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 13    | 168.78 ns | 32.414 ns | 1.777 ns | 167.63 ns | 170.83 ns | 167.76 ns | 169.36 ns | 167.89 ns | 0.0007 |     312 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **21**    | **335.55 ns** |  **1.752 ns** | **1.463 ns** | **332.67 ns** | **337.45 ns** | **334.93 ns** | **336.54 ns** | **336.05 ns** | **0.0052** |     **464 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 21    | 234.12 ns | 30.278 ns | 1.660 ns | 232.88 ns | 236.01 ns | 233.18 ns | 234.74 ns | 233.47 ns | 0.0010 |     464 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **34**    | **493.09 ns** |  **2.594 ns** | **2.166 ns** | **487.50 ns** | **495.79 ns** | **492.94 ns** | **494.63 ns** | **493.44 ns** | **0.0086** |     **744 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 34    | 364.08 ns | 17.808 ns | 0.976 ns | 362.95 ns | 364.74 ns | 363.75 ns | 364.64 ns | 364.54 ns | 0.0019 |     744 B |
