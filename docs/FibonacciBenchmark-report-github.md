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
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **1**     |  **47.83 ns** |  **0.306 ns** | **0.271 ns** |  **47.47 ns** |  **48.34 ns** |  **47.64 ns** |  **48.08 ns** |  **47.71 ns** | **0.0015** |     **128 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 1     |  48.55 ns |  7.797 ns | 0.427 ns |  48.16 ns |  49.01 ns |  48.33 ns |  48.75 ns |  48.50 ns | 0.0004 |     128 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **2**     |  **80.39 ns** |  **0.490 ns** | **0.458 ns** |  **79.72 ns** |  **81.27 ns** |  **80.11 ns** |  **80.60 ns** |  **80.34 ns** | **0.0019** |     **168 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 2     |  70.48 ns | 25.375 ns | 1.391 ns |  69.38 ns |  72.04 ns |  69.70 ns |  71.03 ns |  70.02 ns | 0.0005 |     168 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **3**     |  **93.82 ns** |  **0.821 ns** | **0.685 ns** |  **93.20 ns** |  **95.46 ns** |  **93.30 ns** |  **93.86 ns** |  **93.59 ns** | **0.0019** |     **168 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 3     |  73.94 ns |  2.762 ns | 0.151 ns |  73.78 ns |  74.08 ns |  73.87 ns |  74.02 ns |  73.96 ns | 0.0005 |     168 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **5**     | **130.01 ns** |  **0.838 ns** | **0.743 ns** | **128.87 ns** | **131.22 ns** | **129.35 ns** | **130.66 ns** | **130.05 ns** | **0.0026** |     **224 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 5     | 101.17 ns | 14.577 ns | 0.799 ns | 100.28 ns | 101.83 ns | 100.84 ns | 101.61 ns | 101.40 ns | 0.0006 |     224 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **8**     | **160.35 ns** |  **1.209 ns** | **1.010 ns** | **159.13 ns** | **162.74 ns** | **159.58 ns** | **161.04 ns** | **160.07 ns** | **0.0026** |     **224 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 8     | 121.12 ns | 28.197 ns | 1.546 ns | 119.97 ns | 122.88 ns | 120.24 ns | 121.70 ns | 120.51 ns | 0.0005 |     224 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **13**    | **238.41 ns** |  **2.189 ns** | **1.940 ns** | **235.24 ns** | **241.44 ns** | **237.11 ns** | **240.21 ns** | **237.98 ns** | **0.0033** |     **312 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 13    | 165.11 ns | 22.053 ns | 1.209 ns | 164.36 ns | 166.51 ns | 164.41 ns | 165.49 ns | 164.46 ns | 0.0007 |     312 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **21**    | **344.64 ns** |  **2.316 ns** | **2.053 ns** | **341.89 ns** | **348.24 ns** | **343.02 ns** | **346.21 ns** | **344.46 ns** | **0.0052** |     **464 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 21    | 237.49 ns | 53.050 ns | 2.908 ns | 235.38 ns | 240.80 ns | 235.83 ns | 238.54 ns | 236.27 ns | 0.0010 |     464 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **34**    | **524.82 ns** |  **5.746 ns** | **5.375 ns** | **516.03 ns** | **530.94 ns** | **520.30 ns** | **530.22 ns** | **524.07 ns** | **0.0086** |     **744 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 34    | 346.87 ns | 54.532 ns | 2.989 ns | 345.04 ns | 350.32 ns | 345.14 ns | 347.78 ns | 345.24 ns | 0.0019 |     744 B |
