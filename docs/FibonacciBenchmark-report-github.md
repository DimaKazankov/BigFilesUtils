```

BenchmarkDotNet v0.14.0, Ubuntu 22.04.5 LTS (Jammy Jellyfish)
AMD EPYC 7763, 1 CPU, 2 logical cores and 1 physical core
.NET SDK 8.0.402
  [Host]   : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  ShortRun : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Server=True  

```
| Method    | Job       | Toolchain              | IterationCount | LaunchCount | WarmupCount | Count | Mean      | Error      | StdDev   | StdErr   | Min       | Max       | Q1        | Q3        | Median    | Op/s         | Rank | Gen0   | Allocated |
|---------- |---------- |----------------------- |--------------- |------------ |------------ |------ |----------:|-----------:|---------:|---------:|----------:|----------:|----------:|----------:|----------:|-------------:|-----:|-------:|----------:|
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **1**     |  **47.43 ns** |   **0.227 ns** | **0.189 ns** | **0.053 ns** |  **47.16 ns** |  **47.87 ns** |  **47.33 ns** |  **47.54 ns** |  **47.37 ns** | **21,082,611.3** |    **1** | **0.0015** |     **128 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 1     |  48.61 ns |   4.228 ns | 0.232 ns | 0.134 ns |  48.46 ns |  48.88 ns |  48.48 ns |  48.69 ns |  48.50 ns | 20,570,816.8 |    1 | 0.0004 |     128 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **2**     |  **77.62 ns** |   **0.306 ns** | **0.271 ns** | **0.073 ns** |  **77.00 ns** |  **78.05 ns** |  **77.49 ns** |  **77.72 ns** |  **77.64 ns** | **12,883,152.1** |    **2** | **0.0019** |     **168 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 2     |  70.46 ns |   9.809 ns | 0.538 ns | 0.310 ns |  69.87 ns |  70.93 ns |  70.22 ns |  70.75 ns |  70.57 ns | 14,192,698.4 |    2 | 0.0005 |     168 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **3**     |  **87.07 ns** |   **0.351 ns** | **0.293 ns** | **0.081 ns** |  **86.52 ns** |  **87.69 ns** |  **86.88 ns** |  **87.25 ns** |  **87.11 ns** | **11,485,669.2** |    **3** | **0.0019** |     **168 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 3     |  72.79 ns |   6.661 ns | 0.365 ns | 0.211 ns |  72.43 ns |  73.16 ns |  72.60 ns |  72.97 ns |  72.78 ns | 13,738,971.0 |    2 | 0.0005 |     168 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **5**     | **123.84 ns** |   **1.311 ns** | **1.162 ns** | **0.311 ns** | **121.73 ns** | **125.93 ns** | **123.25 ns** | **124.68 ns** | **123.85 ns** |  **8,074,819.1** |    **3** | **0.0026** |     **224 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 5     | 102.44 ns |   8.384 ns | 0.460 ns | 0.265 ns | 102.04 ns | 102.94 ns | 102.19 ns | 102.64 ns | 102.34 ns |  9,762,058.3 |    3 | 0.0006 |     224 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **8**     | **151.94 ns** |   **2.672 ns** | **2.499 ns** | **0.645 ns** | **147.32 ns** | **154.83 ns** | **150.55 ns** | **153.45 ns** | **152.97 ns** |  **6,581,748.4** |    **4** | **0.0026** |     **224 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 8     | 119.63 ns |  12.810 ns | 0.702 ns | 0.405 ns | 118.97 ns | 120.36 ns | 119.26 ns | 119.96 ns | 119.56 ns |  8,359,203.2 |    3 | 0.0005 |     224 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **13**    | **224.82 ns** |   **1.196 ns** | **0.999 ns** | **0.277 ns** | **223.46 ns** | **226.63 ns** | **223.90 ns** | **225.52 ns** | **224.85 ns** |  **4,447,971.6** |    **5** | **0.0036** |     **312 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 13    | 168.92 ns | 106.095 ns | 5.815 ns | 3.358 ns | 165.37 ns | 175.63 ns | 165.56 ns | 170.69 ns | 165.75 ns |  5,920,081.2 |    4 | 0.0007 |     312 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **21**    | **332.92 ns** |   **5.883 ns** | **5.503 ns** | **1.421 ns** | **319.27 ns** | **339.61 ns** | **331.90 ns** | **336.15 ns** | **335.01 ns** |  **3,003,730.9** |    **6** | **0.0052** |     **464 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 21    | 234.44 ns |  13.814 ns | 0.757 ns | 0.437 ns | 233.74 ns | 235.24 ns | 234.04 ns | 234.80 ns | 234.35 ns |  4,265,428.3 |    5 | 0.0012 |     464 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **34**    | **502.48 ns** |   **3.962 ns** | **3.308 ns** | **0.918 ns** | **497.61 ns** | **510.64 ns** | **500.22 ns** | **504.18 ns** | **502.13 ns** |  **1,990,148.1** |    **7** | **0.0086** |     **744 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 34    | 349.54 ns |  21.883 ns | 1.199 ns | 0.693 ns | 348.22 ns | 350.56 ns | 349.03 ns | 350.20 ns | 349.85 ns |  2,860,890.7 |    6 | 0.0019 |     744 B |
