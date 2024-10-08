```

BenchmarkDotNet v0.14.0, Ubuntu 22.04.5 LTS (Jammy Jellyfish)
AMD EPYC 7763, 1 CPU, 2 logical cores and 1 physical core
.NET SDK 8.0.402
  [Host]            : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  ShortRun          : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  ShortRun-.NET 8.0 : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Runtime=.NET 8.0  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method       | Job               | FileSizeInBytes | Generator    | Mean      | Error     | StdDev   | StdErr   | Min       | Q1        | Median    | Q3        | Max       | Op/s   | Rank | Gen0        | Gen1        | Gen2        | Allocated  |
|------------- |------------------ |---------------- |------------- |----------:|----------:|---------:|---------:|----------:|----------:|----------:|----------:|----------:|-------:|-----:|------------:|------------:|------------:|-----------:|
| **GenerateFile** | **ShortRun**          | **1.00 GB**         | **Original**     |  **8.4315 s** | **17.0948 s** | **0.9370 s** | **0.5410 s** |  **7.4036 s** |  **8.0282 s** |  **8.6528 s** |  **8.9454 s** |  **9.2380 s** | **0.1186** |    **3** |  **75000.0000** |           **-** |           **-** | **5992.15 MB** |
| GenerateFile | ShortRun-.NET 8.0 | 1.00 GB         | Original     |  8.8990 s | 13.7195 s | 0.7520 s | 0.4342 s |  8.0484 s |  8.6107 s |  9.1729 s |  9.3243 s |  9.4757 s | 0.1124 |    3 |  75000.0000 |           - |           - | 5992.33 MB |
| **GenerateFile** | **ShortRun**          | **1.00 GB**         | **Buffered**     |  **7.4304 s** | **15.3526 s** | **0.8415 s** | **0.4859 s** |  **6.9117 s** |  **6.9449 s** |  **6.9781 s** |  **7.6897 s** |  **8.4013 s** | **0.1346** |    **3** | **667000.0000** | **629000.0000** | **629000.0000** | **5125.73 MB** |
| GenerateFile | ShortRun-.NET 8.0 | 1.00 GB         | Buffered     |  8.1789 s | 23.6069 s | 1.2940 s | 0.7471 s |  6.6973 s |  7.7249 s |  8.7526 s |  8.9197 s |  9.0868 s | 0.1223 |    3 | 668000.0000 | 630000.0000 | 630000.0000 | 5125.42 MB |
| **GenerateFile** | **ShortRun**          | **1.00 GB**         | **Parallel**     |  **5.7925 s** |  **0.0830 s** | **0.0046 s** | **0.0026 s** |  **5.7872 s** |  **5.7911 s** |  **5.7949 s** |  **5.7951 s** |  **5.7953 s** | **0.1726** |    **3** |   **5000.0000** |   **5000.0000** |   **5000.0000** | **4099.99 MB** |
| GenerateFile | ShortRun-.NET 8.0 | 1.00 GB         | Parallel     |  5.6746 s |  1.3926 s | 0.0763 s | 0.0441 s |  5.5927 s |  5.6400 s |  5.6872 s |  5.7155 s |  5.7438 s | 0.1762 |    3 |   5000.0000 |   5000.0000 |   5000.0000 | 4100.05 MB |
| **GenerateFile** | **ShortRun**          | **1.00 GB**         | **MemoryMapped** |  **9.9895 s** |  **0.6748 s** | **0.0370 s** | **0.0214 s** |  **9.9567 s** |  **9.9694 s** |  **9.9822 s** | **10.0059 s** | **10.0296 s** | **0.1001** |    **3** | **101000.0000** |           **-** |           **-** | **8115.43 MB** |
| GenerateFile | ShortRun-.NET 8.0 | 1.00 GB         | MemoryMapped | 10.2270 s |  2.1033 s | 0.1153 s | 0.0666 s | 10.0949 s | 10.1866 s | 10.2783 s | 10.2930 s | 10.3077 s | 0.0978 |    3 | 101000.0000 |           - |           - | 8115.31 MB |
| **GenerateFile** | **ShortRun**          | **100.00 MB**       | **Original**     |  **0.8404 s** |  **0.6152 s** | **0.0337 s** | **0.0195 s** |  **0.8031 s** |  **0.8262 s** |  **0.8493 s** |  **0.8590 s** |  **0.8688 s** | **1.1899** |    **2** |   **7000.0000** |           **-** |           **-** |   **585.5 MB** |
| GenerateFile | ShortRun-.NET 8.0 | 100.00 MB       | Original     |  0.8247 s |  0.3404 s | 0.0187 s | 0.0108 s |  0.8118 s |  0.8140 s |  0.8163 s |  0.8312 s |  0.8461 s | 1.2125 |    2 |   7000.0000 |           - |           - |  585.49 MB |
| **GenerateFile** | **ShortRun**          | **100.00 MB**       | **Buffered**     |  **0.7639 s** |  **0.7248 s** | **0.0397 s** | **0.0229 s** |  **0.7201 s** |  **0.7470 s** |  **0.7739 s** |  **0.7858 s** |  **0.7976 s** | **1.3091** |    **2** |  **63000.0000** |  **60000.0000** |  **60000.0000** |  **502.72 MB** |
| GenerateFile | ShortRun-.NET 8.0 | 100.00 MB       | Buffered     |  0.7444 s |  0.9688 s | 0.0531 s | 0.0307 s |  0.6888 s |  0.7193 s |  0.7499 s |  0.7722 s |  0.7945 s | 1.3434 |    2 |  64000.0000 |  61000.0000 |  61000.0000 |  502.77 MB |
| **GenerateFile** | **ShortRun**          | **100.00 MB**       | **Parallel**     |  **0.5480 s** |  **0.1070 s** | **0.0059 s** | **0.0034 s** |  **0.5414 s** |  **0.5458 s** |  **0.5502 s** |  **0.5514 s** |  **0.5525 s** | **1.8247** |    **1** |   **1000.0000** |   **1000.0000** |   **1000.0000** |  **440.75 MB** |
| GenerateFile | ShortRun-.NET 8.0 | 100.00 MB       | Parallel     |  0.5447 s |  0.0614 s | 0.0034 s | 0.0019 s |  0.5424 s |  0.5427 s |  0.5430 s |  0.5458 s |  0.5485 s | 1.8360 |    1 |   2000.0000 |   2000.0000 |   2000.0000 |  440.76 MB |
| **GenerateFile** | **ShortRun**          | **100.00 MB**       | **MemoryMapped** |  **0.8951 s** |  **0.0402 s** | **0.0022 s** | **0.0013 s** |  **0.8933 s** |  **0.8939 s** |  **0.8944 s** |  **0.8960 s** |  **0.8976 s** | **1.1172** |    **2** |   **9000.0000** |           **-** |           **-** |  **792.44 MB** |
| GenerateFile | ShortRun-.NET 8.0 | 100.00 MB       | MemoryMapped |  0.9003 s |  0.2312 s | 0.0127 s | 0.0073 s |  0.8888 s |  0.8935 s |  0.8983 s |  0.9061 s |  0.9139 s | 1.1107 |    2 |   9000.0000 |           - |           - |   792.5 MB |
