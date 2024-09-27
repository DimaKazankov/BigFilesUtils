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
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **1**     |  **48.30 ns** |   **0.339 ns** | **0.283 ns** | **0.079 ns** |  **47.98 ns** |  **49.00 ns** |  **48.10 ns** |  **48.38 ns** |  **48.22 ns** | **20,702,122.4** |    **1** | **0.0015** |     **128 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 1     |  48.67 ns |   8.113 ns | 0.445 ns | 0.257 ns |  48.35 ns |  49.18 ns |  48.42 ns |  48.83 ns |  48.48 ns | 20,546,184.6 |    1 | 0.0004 |     128 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **2**     |  **79.51 ns** |   **0.308 ns** | **0.273 ns** | **0.073 ns** |  **79.03 ns** |  **80.06 ns** |  **79.29 ns** |  **79.67 ns** |  **79.53 ns** | **12,576,886.0** |    **2** | **0.0019** |     **168 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 2     |  69.25 ns |   6.728 ns | 0.369 ns | 0.213 ns |  68.92 ns |  69.65 ns |  69.05 ns |  69.42 ns |  69.19 ns | 14,440,177.2 |    2 | 0.0005 |     168 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **3**     |  **89.00 ns** |   **0.885 ns** | **0.785 ns** | **0.210 ns** |  **87.47 ns** |  **90.21 ns** |  **88.69 ns** |  **89.49 ns** |  **89.05 ns** | **11,235,612.2** |    **3** | **0.0019** |     **168 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 3     |  73.57 ns |   2.670 ns | 0.146 ns | 0.085 ns |  73.43 ns |  73.72 ns |  73.50 ns |  73.64 ns |  73.57 ns | 13,592,013.9 |    2 | 0.0005 |     168 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **5**     | **126.57 ns** |   **0.735 ns** | **0.652 ns** | **0.174 ns** | **125.73 ns** | **127.97 ns** | **126.03 ns** | **126.95 ns** | **126.33 ns** |  **7,901,010.7** |    **3** | **0.0026** |     **224 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 5     | 101.36 ns |  12.581 ns | 0.690 ns | 0.398 ns | 100.73 ns | 102.10 ns | 100.99 ns | 101.67 ns | 101.25 ns |  9,865,818.1 |    3 | 0.0006 |     224 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **8**     | **153.60 ns** |   **2.710 ns** | **2.535 ns** | **0.654 ns** | **149.62 ns** | **156.41 ns** | **151.34 ns** | **155.55 ns** | **154.64 ns** |  **6,510,412.6** |    **4** | **0.0026** |     **224 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 8     | 122.59 ns |  64.739 ns | 3.549 ns | 2.049 ns | 120.42 ns | 126.68 ns | 120.54 ns | 123.67 ns | 120.67 ns |  8,157,304.2 |    3 | 0.0005 |     224 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **13**    | **224.25 ns** |   **0.771 ns** | **0.684 ns** | **0.183 ns** | **223.40 ns** | **225.44 ns** | **223.62 ns** | **224.81 ns** | **224.17 ns** |  **4,459,383.1** |    **5** | **0.0036** |     **312 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 13    | 163.69 ns |  30.608 ns | 1.678 ns | 0.969 ns | 162.32 ns | 165.56 ns | 162.76 ns | 164.38 ns | 163.20 ns |  6,109,069.4 |    4 | 0.0007 |     312 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **21**    | **331.19 ns** |   **1.065 ns** | **0.944 ns** | **0.252 ns** | **328.77 ns** | **332.55 ns** | **330.75 ns** | **331.71 ns** | **331.30 ns** |  **3,019,422.1** |    **6** | **0.0052** |     **464 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 21    | 238.48 ns | 113.901 ns | 6.243 ns | 3.605 ns | 232.12 ns | 244.60 ns | 235.41 ns | 241.65 ns | 238.71 ns |  4,193,284.2 |    5 | 0.0012 |     464 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **34**    | **490.92 ns** |   **3.238 ns** | **2.870 ns** | **0.767 ns** | **485.67 ns** | **495.73 ns** | **488.96 ns** | **492.54 ns** | **491.20 ns** |  **2,036,975.7** |    **7** | **0.0086** |     **744 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 34    | 347.15 ns |  33.329 ns | 1.827 ns | 1.055 ns | 345.72 ns | 349.21 ns | 346.12 ns | 347.86 ns | 346.52 ns |  2,880,608.0 |    6 | 0.0019 |     744 B |
