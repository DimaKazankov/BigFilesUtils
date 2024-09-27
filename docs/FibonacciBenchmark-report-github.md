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
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **1**     |  **49.04 ns** |   **0.673 ns** | **0.597 ns** | **0.159 ns** |  **48.02 ns** |  **50.15 ns** |  **48.84 ns** |  **49.11 ns** |  **48.93 ns** | **20,391,570.7** |    **1** | **0.0015** |     **128 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 1     |  49.03 ns |   7.500 ns | 0.411 ns | 0.237 ns |  48.61 ns |  49.43 ns |  48.83 ns |  49.24 ns |  49.04 ns | 20,396,573.9 |    1 | 0.0004 |     128 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **2**     |  **81.67 ns** |   **0.466 ns** | **0.436 ns** | **0.113 ns** |  **80.87 ns** |  **82.53 ns** |  **81.43 ns** |  **81.92 ns** |  **81.66 ns** | **12,244,564.9** |    **2** | **0.0019** |     **168 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 2     |  68.17 ns |   9.111 ns | 0.499 ns | 0.288 ns |  67.64 ns |  68.63 ns |  67.94 ns |  68.44 ns |  68.24 ns | 14,669,089.2 |    2 | 0.0005 |     168 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **3**     |  **91.79 ns** |   **0.440 ns** | **0.390 ns** | **0.104 ns** |  **91.40 ns** |  **92.70 ns** |  **91.49 ns** |  **91.95 ns** |  **91.72 ns** | **10,894,465.1** |    **3** | **0.0019** |     **168 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 3     |  73.68 ns |  35.036 ns | 1.920 ns | 1.109 ns |  72.30 ns |  75.87 ns |  72.58 ns |  74.37 ns |  72.87 ns | 13,572,034.0 |    2 | 0.0005 |     168 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **5**     | **130.27 ns** |   **0.446 ns** | **0.372 ns** | **0.103 ns** | **129.80 ns** | **131.05 ns** | **129.95 ns** | **130.51 ns** | **130.19 ns** |  **7,676,541.1** |    **3** | **0.0026** |     **224 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 5     | 103.65 ns |  10.809 ns | 0.593 ns | 0.342 ns | 103.19 ns | 104.32 ns | 103.32 ns | 103.88 ns | 103.44 ns |  9,647,746.0 |    3 | 0.0005 |     224 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **8**     | **161.36 ns** |   **0.729 ns** | **0.682 ns** | **0.176 ns** | **159.66 ns** | **162.06 ns** | **161.28 ns** | **161.71 ns** | **161.51 ns** |  **6,197,469.5** |    **4** | **0.0026** |     **224 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 8     | 118.87 ns |   6.355 ns | 0.348 ns | 0.201 ns | 118.55 ns | 119.24 ns | 118.69 ns | 119.03 ns | 118.82 ns |  8,412,491.3 |    3 | 0.0005 |     224 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **13**    | **234.14 ns** |   **1.118 ns** | **0.873 ns** | **0.252 ns** | **233.20 ns** | **236.08 ns** | **233.48 ns** | **234.67 ns** | **233.83 ns** |  **4,270,931.3** |    **5** | **0.0036** |     **312 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 13    | 169.74 ns | 114.695 ns | 6.287 ns | 3.630 ns | 165.80 ns | 176.99 ns | 166.11 ns | 171.71 ns | 166.43 ns |  5,891,364.0 |    4 | 0.0007 |     312 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **21**    | **346.09 ns** |   **3.578 ns** | **2.988 ns** | **0.829 ns** | **337.40 ns** | **349.27 ns** | **345.14 ns** | **347.74 ns** | **347.07 ns** |  **2,889,395.7** |    **6** | **0.0052** |     **464 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 21    | 241.11 ns |  27.559 ns | 1.511 ns | 0.872 ns | 239.92 ns | 242.81 ns | 240.26 ns | 241.70 ns | 240.59 ns |  4,147,526.9 |    5 | 0.0010 |     464 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **34**    | **520.20 ns** |   **4.055 ns** | **3.595 ns** | **0.961 ns** | **516.31 ns** | **528.17 ns** | **518.04 ns** | **522.31 ns** | **518.69 ns** |  **1,922,342.6** |    **7** | **0.0086** |     **744 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 34    | 349.75 ns |  50.487 ns | 2.767 ns | 1.598 ns | 347.03 ns | 352.57 ns | 348.35 ns | 351.12 ns | 349.66 ns |  2,859,149.8 |    6 | 0.0019 |     744 B |
