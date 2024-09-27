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
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **1**     |  **48.01 ns** |  **0.423 ns** | **0.375 ns** |  **47.50 ns** |  **48.56 ns** |  **47.74 ns** |  **48.37 ns** |  **47.94 ns** | **0.0015** |     **128 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 1     |  49.00 ns |  6.803 ns | 0.373 ns |  48.57 ns |  49.26 ns |  48.87 ns |  49.21 ns |  49.16 ns | 0.0004 |     128 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **2**     |  **79.68 ns** |  **0.430 ns** | **0.403 ns** |  **78.95 ns** |  **80.38 ns** |  **79.41 ns** |  **79.87 ns** |  **79.58 ns** | **0.0019** |     **168 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 2     |  68.32 ns | 12.137 ns | 0.665 ns |  67.76 ns |  69.05 ns |  67.96 ns |  68.60 ns |  68.16 ns | 0.0005 |     168 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **3**     |  **90.57 ns** |  **0.417 ns** | **0.390 ns** |  **89.85 ns** |  **91.28 ns** |  **90.30 ns** |  **90.76 ns** |  **90.52 ns** | **0.0019** |     **168 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 3     |  73.34 ns |  4.373 ns | 0.240 ns |  73.18 ns |  73.61 ns |  73.20 ns |  73.41 ns |  73.22 ns | 0.0005 |     168 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **5**     | **130.19 ns** |  **0.901 ns** | **0.842 ns** | **129.10 ns** | **131.88 ns** | **129.47 ns** | **130.81 ns** | **130.20 ns** | **0.0026** |     **224 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 5     | 105.04 ns |  3.354 ns | 0.184 ns | 104.87 ns | 105.23 ns | 104.94 ns | 105.13 ns | 105.02 ns | 0.0006 |     224 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **8**     | **161.15 ns** |  **2.107 ns** | **1.971 ns** | **158.06 ns** | **163.97 ns** | **159.27 ns** | **162.68 ns** | **161.86 ns** | **0.0026** |     **224 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 8     | 120.76 ns | 12.355 ns | 0.677 ns | 120.14 ns | 121.49 ns | 120.40 ns | 121.07 ns | 120.65 ns | 0.0005 |     224 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **13**    | **238.23 ns** |  **1.908 ns** | **1.785 ns** | **235.44 ns** | **240.72 ns** | **236.89 ns** | **239.56 ns** | **238.44 ns** | **0.0033** |     **312 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 13    | 166.42 ns | 14.208 ns | 0.779 ns | 165.77 ns | 167.29 ns | 165.99 ns | 166.75 ns | 166.21 ns | 0.0007 |     312 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **21**    | **351.28 ns** |  **2.280 ns** | **2.021 ns** | **348.01 ns** | **354.47 ns** | **349.81 ns** | **352.52 ns** | **351.44 ns** | **0.0052** |     **464 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 21    | 236.85 ns |  9.773 ns | 0.536 ns | 236.44 ns | 237.45 ns | 236.55 ns | 237.06 ns | 236.66 ns | 0.0010 |     464 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **34**    | **524.80 ns** |  **4.621 ns** | **4.097 ns** | **515.90 ns** | **531.78 ns** | **524.05 ns** | **527.43 ns** | **524.81 ns** | **0.0086** |     **744 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 34    | 349.58 ns | 36.571 ns | 2.005 ns | 347.89 ns | 351.79 ns | 348.47 ns | 350.42 ns | 349.04 ns | 0.0019 |     744 B |
