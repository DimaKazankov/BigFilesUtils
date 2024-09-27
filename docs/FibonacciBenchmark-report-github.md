```

BenchmarkDotNet v0.14.0, Ubuntu 22.04.5 LTS (Jammy Jellyfish)
AMD EPYC 7763, 1 CPU, 2 logical cores and 1 physical core
.NET SDK 8.0.402
  [Host]   : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  ShortRun : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Server=True  

```
| Method    | Job       | Toolchain              | IterationCount | LaunchCount | WarmupCount | Count | Mean      | Error      | StdDev    | StdErr   | Min       | Max       | Q1        | Q3        | Median    | Op/s         | Rank | Gen0   | Allocated |
|---------- |---------- |----------------------- |--------------- |------------ |------------ |------ |----------:|-----------:|----------:|---------:|----------:|----------:|----------:|----------:|----------:|-------------:|-----:|-------:|----------:|
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **1**     |  **47.84 ns** |   **0.360 ns** |  **0.301 ns** | **0.083 ns** |  **47.48 ns** |  **48.50 ns** |  **47.58 ns** |  **48.05 ns** |  **47.79 ns** | **20,902,389.7** |    **1** | **0.0015** |     **128 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 1     |  48.39 ns |   2.805 ns |  0.154 ns | 0.089 ns |  48.24 ns |  48.55 ns |  48.32 ns |  48.47 ns |  48.39 ns | 20,664,340.6 |    1 | 0.0004 |     128 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **2**     |  **79.94 ns** |   **0.684 ns** |  **0.640 ns** | **0.165 ns** |  **79.18 ns** |  **81.29 ns** |  **79.45 ns** |  **80.23 ns** |  **79.86 ns** | **12,509,409.2** |    **2** | **0.0019** |     **168 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 2     |  69.18 ns |   7.890 ns |  0.432 ns | 0.250 ns |  68.72 ns |  69.58 ns |  68.98 ns |  69.41 ns |  69.24 ns | 14,455,289.0 |    2 | 0.0005 |     168 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **3**     |  **90.56 ns** |   **0.616 ns** |  **0.546 ns** | **0.146 ns** |  **89.42 ns** |  **91.23 ns** |  **90.38 ns** |  **90.90 ns** |  **90.76 ns** | **11,042,814.8** |    **3** | **0.0019** |     **168 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 3     |  73.67 ns |  16.600 ns |  0.910 ns | 0.525 ns |  72.94 ns |  74.69 ns |  73.16 ns |  74.03 ns |  73.37 ns | 13,574,782.9 |    2 | 0.0005 |     168 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **5**     | **130.84 ns** |   **1.336 ns** |  **1.184 ns** | **0.317 ns** | **129.33 ns** | **133.41 ns** | **129.84 ns** | **131.47 ns** | **131.14 ns** |  **7,643,056.8** |    **3** | **0.0026** |     **224 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 5     | 102.82 ns |   8.173 ns |  0.448 ns | 0.259 ns | 102.31 ns | 103.11 ns | 102.68 ns | 103.08 ns | 103.06 ns |  9,725,266.5 |    3 | 0.0006 |     224 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **8**     | **161.78 ns** |   **1.824 ns** |  **1.617 ns** | **0.432 ns** | **158.95 ns** | **164.77 ns** | **161.17 ns** | **162.86 ns** | **162.01 ns** |  **6,181,392.6** |    **4** | **0.0026** |     **224 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 8     | 121.14 ns |  21.983 ns |  1.205 ns | 0.696 ns | 119.93 ns | 122.34 ns | 120.54 ns | 121.74 ns | 121.15 ns |  8,255,107.1 |    3 | 0.0005 |     224 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **13**    | **240.96 ns** |   **1.876 ns** |  **1.663 ns** | **0.444 ns** | **238.29 ns** | **243.70 ns** | **239.58 ns** | **242.08 ns** | **240.85 ns** |  **4,150,005.4** |    **5** | **0.0033** |     **312 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 13    | 180.41 ns |  28.458 ns |  1.560 ns | 0.901 ns | 178.89 ns | 182.01 ns | 179.61 ns | 181.17 ns | 180.33 ns |  5,542,973.1 |    4 | 0.0007 |     312 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **21**    | **353.38 ns** |   **6.560 ns** |  **6.136 ns** | **1.584 ns** | **341.73 ns** | **362.99 ns** | **352.78 ns** | **356.97 ns** | **354.67 ns** |  **2,829,816.9** |    **6** | **0.0052** |     **464 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 21    | 243.69 ns | 204.574 ns | 11.213 ns | 6.474 ns | 237.10 ns | 256.64 ns | 237.22 ns | 246.99 ns | 237.33 ns |  4,103,544.0 |    5 | 0.0010 |     464 B |
| **Fibonacci** | **InProcess** | **InProcessEmitToolchain** | **Default**        | **Default**     | **Default**     | **34**    | **536.40 ns** |   **3.992 ns** |  **3.734 ns** | **0.964 ns** | **530.56 ns** | **541.50 ns** | **532.92 ns** | **539.64 ns** | **536.29 ns** |  **1,864,283.1** |    **7** | **0.0086** |     **744 B** |
| Fibonacci | ShortRun  | Default                | 3              | 1           | 3           | 34    | 350.86 ns |  35.173 ns |  1.928 ns | 1.113 ns | 348.85 ns | 352.69 ns | 349.94 ns | 351.86 ns | 351.03 ns |  2,850,164.5 |    6 | 0.0019 |     744 B |
