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
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **1**     |  **46.53 ns** |  **0.270 ns** | **0.239 ns** |  **46.02 ns** |  **46.97 ns** |  **46.40 ns** |  **46.70 ns** |  **46.55 ns** | **0.0015** |     **128 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 1     |  49.49 ns | 33.864 ns | 1.856 ns |  48.37 ns |  51.63 ns |  48.42 ns |  50.04 ns |  48.46 ns | 0.0004 |     128 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **2**     |  **77.76 ns** |  **1.173 ns** | **1.040 ns** |  **76.25 ns** |  **79.84 ns** |  **77.16 ns** |  **78.12 ns** |  **77.62 ns** | **0.0019** |     **168 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 2     |  68.30 ns |  7.974 ns | 0.437 ns |  67.87 ns |  68.75 ns |  68.08 ns |  68.52 ns |  68.29 ns | 0.0005 |     168 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **3**     |  **88.15 ns** |  **0.919 ns** | **0.859 ns** |  **86.87 ns** |  **89.87 ns** |  **87.58 ns** |  **88.83 ns** |  **87.89 ns** | **0.0019** |     **168 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 3     |  75.04 ns | 11.569 ns | 0.634 ns |  74.31 ns |  75.47 ns |  74.83 ns |  75.40 ns |  75.34 ns | 0.0005 |     168 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **5**     | **125.57 ns** |  **0.787 ns** | **0.697 ns** | **124.58 ns** | **126.58 ns** | **124.92 ns** | **126.21 ns** | **125.67 ns** | **0.0026** |     **224 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 5     | 101.54 ns |  8.499 ns | 0.466 ns | 101.11 ns | 102.03 ns | 101.29 ns | 101.75 ns | 101.46 ns | 0.0006 |     224 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **8**     | **154.48 ns** |  **1.005 ns** | **0.891 ns** | **153.11 ns** | **156.29 ns** | **153.75 ns** | **155.05 ns** | **154.44 ns** | **0.0026** |     **224 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 8     | 119.44 ns | 21.181 ns | 1.161 ns | 118.38 ns | 120.68 ns | 118.82 ns | 119.97 ns | 119.27 ns | 0.0005 |     224 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **13**    | **236.55 ns** |  **1.585 ns** | **1.483 ns** | **234.54 ns** | **239.22 ns** | **235.40 ns** | **237.75 ns** | **235.98 ns** | **0.0033** |     **312 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 13    | 164.20 ns | 36.558 ns | 2.004 ns | 161.99 ns | 165.90 ns | 163.36 ns | 165.31 ns | 164.72 ns | 0.0007 |     312 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **21**    | **346.81 ns** |  **1.985 ns** | **1.760 ns** | **343.96 ns** | **348.86 ns** | **345.48 ns** | **348.14 ns** | **347.25 ns** | **0.0052** |     **464 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 21    | 236.08 ns |  8.302 ns | 0.455 ns | 235.56 ns | 236.40 ns | 235.92 ns | 236.34 ns | 236.28 ns | 0.0012 |     464 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **34**    | **527.13 ns** |  **4.359 ns** | **3.864 ns** | **518.88 ns** | **534.09 ns** | **525.04 ns** | **528.77 ns** | **527.20 ns** | **0.0086** |     **744 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 34    | 350.58 ns | 99.116 ns | 5.433 ns | 346.42 ns | 356.73 ns | 347.51 ns | 352.66 ns | 348.59 ns | 0.0019 |     744 B |
