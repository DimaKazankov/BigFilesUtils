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
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **1**     |  **51.33 ns** |  **0.399 ns** | **0.354 ns** |  **50.92 ns** |  **52.08 ns** |  **51.03 ns** |  **51.56 ns** |  **51.29 ns** | **0.0015** |     **128 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 1     |  48.63 ns |  5.146 ns | 0.282 ns |  48.34 ns |  48.90 ns |  48.49 ns |  48.77 ns |  48.65 ns | 0.0004 |     128 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **2**     |  **86.01 ns** |  **0.551 ns** | **0.516 ns** |  **85.36 ns** |  **86.82 ns** |  **85.65 ns** |  **86.37 ns** |  **85.93 ns** | **0.0019** |     **168 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 2     |  67.95 ns |  5.258 ns | 0.288 ns |  67.72 ns |  68.27 ns |  67.79 ns |  68.07 ns |  67.87 ns | 0.0005 |     168 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **3**     |  **97.61 ns** |  **0.600 ns** | **0.532 ns** |  **96.60 ns** |  **98.47 ns** |  **97.27 ns** |  **97.89 ns** |  **97.55 ns** | **0.0019** |     **168 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 3     |  72.69 ns |  6.480 ns | 0.355 ns |  72.36 ns |  73.07 ns |  72.50 ns |  72.86 ns |  72.65 ns | 0.0005 |     168 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **5**     | **140.32 ns** |  **0.807 ns** | **0.755 ns** | **138.42 ns** | **141.55 ns** | **139.97 ns** | **140.65 ns** | **140.31 ns** | **0.0026** |     **224 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 5     | 103.44 ns |  5.672 ns | 0.311 ns | 103.13 ns | 103.75 ns | 103.28 ns | 103.59 ns | 103.43 ns | 0.0006 |     224 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **8**     | **171.02 ns** |  **1.026 ns** | **0.909 ns** | **168.92 ns** | **172.04 ns** | **170.90 ns** | **171.60 ns** | **171.16 ns** | **0.0026** |     **224 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 8     | 120.93 ns | 28.713 ns | 1.574 ns | 119.70 ns | 122.70 ns | 120.04 ns | 121.54 ns | 120.38 ns | 0.0005 |     224 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **13**    | **250.27 ns** |  **1.181 ns** | **1.105 ns** | **248.11 ns** | **251.98 ns** | **249.44 ns** | **250.93 ns** | **250.63 ns** | **0.0033** |     **312 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 13    | 165.13 ns | 17.284 ns | 0.947 ns | 164.05 ns | 165.84 ns | 164.77 ns | 165.66 ns | 165.48 ns | 0.0007 |     312 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **21**    | **364.11 ns** |  **7.047 ns** | **6.247 ns** | **351.55 ns** | **369.84 ns** | **360.04 ns** | **368.14 ns** | **367.27 ns** | **0.0052** |     **464 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 21    | 234.84 ns | 17.037 ns | 0.934 ns | 234.11 ns | 235.89 ns | 234.31 ns | 235.20 ns | 234.51 ns | 0.0012 |     464 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **34**    | **536.57 ns** |  **4.529 ns** | **4.015 ns** | **531.91 ns** | **545.24 ns** | **533.92 ns** | **537.54 ns** | **535.44 ns** | **0.0086** |     **744 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 34    | 350.08 ns |  8.667 ns | 0.475 ns | 349.55 ns | 350.47 ns | 349.88 ns | 350.34 ns | 350.21 ns | 0.0019 |     744 B |
