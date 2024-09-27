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
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **1**     |  **49.75 ns** |  **0.469 ns** | **0.416 ns** |  **49.19 ns** |  **50.39 ns** |  **49.42 ns** |  **50.01 ns** |  **49.69 ns** | **0.0015** |     **128 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 1     |  50.71 ns | 10.890 ns | 0.597 ns |  50.07 ns |  51.25 ns |  50.44 ns |  51.03 ns |  50.81 ns | 0.0004 |     128 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **2**     |  **81.38 ns** |  **0.510 ns** | **0.452 ns** |  **80.57 ns** |  **82.12 ns** |  **81.05 ns** |  **81.74 ns** |  **81.33 ns** | **0.0019** |     **168 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 2     |  71.35 ns | 18.665 ns | 1.023 ns |  70.62 ns |  72.52 ns |  70.77 ns |  71.72 ns |  70.92 ns | 0.0005 |     168 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **3**     |  **90.76 ns** |  **0.513 ns** | **0.401 ns** |  **89.93 ns** |  **91.31 ns** |  **90.47 ns** |  **91.05 ns** |  **90.87 ns** | **0.0019** |     **168 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 3     |  75.37 ns | 13.193 ns | 0.723 ns |  74.54 ns |  75.87 ns |  75.12 ns |  75.79 ns |  75.70 ns | 0.0005 |     168 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **5**     | **128.21 ns** |  **0.468 ns** | **0.415 ns** | **127.54 ns** | **128.84 ns** | **127.87 ns** | **128.50 ns** | **128.23 ns** | **0.0026** |     **224 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 5     | 108.90 ns |  1.346 ns | 0.074 ns | 108.82 ns | 108.96 ns | 108.88 ns | 108.95 ns | 108.93 ns | 0.0006 |     224 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **8**     | **157.35 ns** |  **0.748 ns** | **0.663 ns** | **156.26 ns** | **158.32 ns** | **156.77 ns** | **157.78 ns** | **157.41 ns** | **0.0026** |     **224 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 8     | 126.12 ns | 35.558 ns | 1.949 ns | 124.42 ns | 128.25 ns | 125.05 ns | 126.96 ns | 125.68 ns | 0.0005 |     224 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **13**    | **233.81 ns** |  **0.805 ns** | **0.672 ns** | **232.83 ns** | **234.71 ns** | **233.25 ns** | **234.27 ns** | **233.67 ns** | **0.0036** |     **312 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 13    | 188.52 ns |  4.507 ns | 0.247 ns | 188.24 ns | 188.71 ns | 188.43 ns | 188.66 ns | 188.62 ns | 0.0007 |     312 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **21**    | **340.02 ns** |  **2.598 ns** | **2.303 ns** | **334.96 ns** | **344.91 ns** | **338.89 ns** | **341.12 ns** | **339.86 ns** | **0.0052** |     **464 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 21    | 249.88 ns | 35.006 ns | 1.919 ns | 248.60 ns | 252.09 ns | 248.78 ns | 250.53 ns | 248.96 ns | 0.0010 |     464 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **34**    | **512.51 ns** |  **3.242 ns** | **3.032 ns** | **507.75 ns** | **516.70 ns** | **510.11 ns** | **515.43 ns** | **512.12 ns** | **0.0086** |     **744 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 34    | 363.13 ns | 46.359 ns | 2.541 ns | 361.42 ns | 366.05 ns | 361.67 ns | 363.98 ns | 361.91 ns | 0.0019 |     744 B |
