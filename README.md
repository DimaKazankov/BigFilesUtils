# File Algorithms Project

## Requirements
For more detailed information, please refer to the following [documentation](.docs/Requirements.md):

## Decision way

Here’s an improved version of the translation with enhanced clarity and flow:

The test task turned out to be surprisingly interesting. I've wanted to work with BenchmarkDotNet for a long time, and this opportunity allowed me to dive into the framework.

Regarding the task, a few challenges became immediately clear:
- The code will be tested on files as large as 100GB. Even after clearing as much space as possible from my hard drive, I wouldn't have enough storage to test my solution under those conditions. So, what can I do? I decided to implement multiple algorithm variations.
- Let's assume I get these algorithms working. Without the proper infrastructure to capture and analyze performance results, it would be difficult to determine which algorithm performs best. To complicate matters further, the code will eventually be run in different environments, and conclusions drawn from smaller files (less than 10GB) may not hold true for 100GB files. That's why I developed code that can be easily executed to capture results in other environments. I’ve included instructions for this as well.

These considerations guided me toward the solution I implemented.

I understand that I could have focused on just one algorithm without making modifications for performance.

I realize I could have concentrated on refining that single algorithm and improving its efficiency.

Had I focused solely on one, the algorithm could have been more performant, and the code quality might have been higher.


However, given the limited time, I chose to build a solution that makes it easy to evaluate which algorithm performs best. This also allows for new algorithms to be added and tested effortlessly.

Regards,
Dima

## Introduction

This project implements various algorithms for generating and sorting large files. It's designed to handle files of different sizes efficiently, using various techniques such as buffering, parallelization, and memory-mapped files.

The project also includes benchmarking capabilities to measure and compare the performance of different algorithms.

## Project Structure

The project is organized into several namespaces:

- `FileAlgorithms.Generator`: Contains file generation algorithms
- `FileAlgorithms.Sorter`: Contains file sorting algorithms
- `FileAlgorithms.Benchmark`: Contains benchmarking code
- `FileAlgorithms.Tests`: Contains unit tests

## Benchmarking results

## GitHub benchmark results are regenerating on every pipeline run: [GitHub benchmark results](.docs/GitHubResults.md)

Github runner machine info: **AMD EPYC 7763, 1 CPU, 2 logical cores and 1 physical core**

### File Generation Algorithms

#### 1GB File Generation:

1. **Parallel**: Fastest (5.6-5.8s)
    - Utilizes multi-threading effectively
    - Lowest memory allocation (4100MB)

2. **Buffered**: Second fastest (7.4-8.2s)
    - Efficient use of StringBuilder for buffering
    - Higher memory allocation due to buffer (5125MB)

3. **Original**: Third (8.4-8.9s)
    - Simple implementation, but less efficient
    - Moderate memory allocation (5992MB)

4. **MemoryMapped**: Slowest (9.9-10.2s)
    - Unexpected slower performance for large files
    - Highest memory allocation (8115MB)

### 100MB File Generation:

1. **Parallel**: Remains fastest (0.54-0.55s)
    - Consistent performance across file sizes

2. **Buffered**: Second fastest (0.74-0.76s)
    - Maintains efficiency for smaller files

3. **Original**: Third (0.82-0.84s)
    - Performance gap narrows for smaller files

4. **MemoryMapped**: Still slowest (0.89-0.90s)
    - Performance improves relative to other methods for smaller files

### File Sorting Algorithms

#### 100MB File Sorting:

1. **MemoryMapped (Default)**: Fastest (17.4-17.6s)
    - Efficient for this file size
    - Lower memory allocation compared to other methods

2. **ExternalMerge (Default)**: Second fastest (18.3-18.5s)
    - Consistently good performance

3. **Parallel**: Mixed results
    - With Default sorter: Fast (18.6-19.2s)
    - With Quick sorter: Slower (20.1-20.4s)

4. **KWayMerge**: Similar to ExternalMerge
    - Slightly slower with Default sorter (18.9-19.2s)
    - Slower with Quick sorter (20.5-21.5s)

5. **ChunkedMemoryMapped**: Slowest for 100MB (20.5-22.4s)
    - Overhead of chunking might not be beneficial for this file size

#### 50MB File Sorting:

1. **ChunkedMemoryMapped (Default)**: Fastest (7.1-7.2s)
    - Performs better on smaller files
    - Lowest memory allocation

2. **MemoryMapped (Default)**: Second fastest (8.1-8.2s)
    - Consistent performance across file sizes

3. **ExternalMerge, KWayMerge, Parallel**: Similar performance (8.6-8.9s)
    - Less differentiation for smaller files

4. **Quick sorter variants**: Generally slower across all methods

### Key Observations:

1. **Parallel processing** is most effective for file generation, especially for larger files.
2. **Memory-mapped** approaches are more efficient for sorting, particularly for smaller files.
3. The **Default sorter** generally outperforms the **Quick sorter** across all methods.
4. **ChunkedMemoryMapped** shows interesting behavior:
    - Poor performance for larger files (100MB)
    - Best performance for smaller files (50MB)
5. The choice between **ExternalMerge**, **KWayMerge**, and **Parallel** sorting depends on the specific file size and system characteristics.


## Manual run on my machine: [My local machine benchmark results](.docs/MyLocalMachineResults.md)
# File Generation and Sorting Benchmark Analysis

## System Specifications
- RAM: 32GB
- Processor: Intel(R) Core(TM) i7-6820HQ CPU @ 2.70GHz
- Cores: 4 Core(s), 8 Logical Processor(s)

## File Generation Benchmarks

### 1 GB Files

| Method | Performance | Memory Allocation |
|--------|-------------|-------------------|
| Parallel | 1.7-1.8s (fastest) | 4.1 GB (lowest) |
| Buffered | 6.4-7.0s | 5.1 GB |
| Original | 7.3-7.8s | 5.9 GB |
| MemoryMapped | 8.3-8.5s | 7.9 GB (highest) |

- Parallel generator is significantly faster than other methods.
- Memory allocation is lowest for Parallel and highest for MemoryMapped.

### 100 MB Files

| Method | Performance | Memory Allocation |
|--------|-------------|-------------------|
| Parallel | 0.2-0.22s (fastest) | 441 MB |
| Buffered | 0.66-0.7s | 500 MB |
| Original | 0.71-0.74s | 572 MB |
| MemoryMapped | 0.82-0.89s | 772 MB |

- Performance ranking is similar to 1 GB files, but with scaled-down memory allocation.

## File Sorting Benchmarks

### 100 MB Files

- Performance range: 26-38 seconds for most methods
- MemoryMapped with Default sorter: Generally fastest (26-27s)
- Quick sorter: Often slower than the Default sorter
- Parallel sorting: No significant improvements, likely due to overhead

### 50 MB Files

- Sorting times: 11-15 seconds for most methods
- ChunkedMemoryMapped and MemoryMapped: Generally faster (11-13s)
- Quick sorter: Often slower than the Default sorter

## General Observations

1. Parallel generator: Extremely efficient for file generation, but advantage doesn't translate to sorting.
2. MemoryMapped methods: Perform well for sorting, especially with smaller file sizes.
3. Quick sorter: Often performs slower than the Default sorter, possibly due to data nature or implementation details.
4. .NET 8.0 vs default runtime: Generally small performance difference, with some exceptions.
5. Memory allocation: Varies significantly between methods, with Parallel and MemoryMapped often using more memory.

## Analysis

- The Parallel generator's efficiency in file generation is likely due to full utilization of multiple cores.
- High RAM allows for efficient use of memory-mapped files, explaining their good sorting performance.
- For very large files, the advantage of memory-mapped methods might diminish due to increased reliance on disk I/O.

## Conclusions

- For fast file generation: Parallel method is superior.
- For sorting: MemoryMapped or ChunkedMemoryMapped methods offer best performance, especially for smaller files.
- Default sorter generally outperforms Quick sorter, which warrants further investigation.

## Recommendations

The choice of method depends on the specific use case:
1. Prioritize Parallel method for file generation tasks.
2. Use MemoryMapped or ChunkedMemoryMapped for sorting, particularly with files that fit comfortably in RAM.
3. Consider using the Default sorter over the Quick sorter unless specific data characteristics suggest otherwise.
4. For large-scale operations, balance between memory usage and performance based on available system resources.

## Features

- Multiple file generation algorithms
- Multiple file sorting algorithms
- Benchmarking capabilities
- Comprehensive unit tests

## Documentation

For more detailed information, please refer to the following documentation:

- [File Generation](.docs/File-Generation.md)
- [File Sorting](.docs/File-Sorting.md)
- [Benchmarking](.docs/Benchmarking.md)
- [Running the Project](.docs/Running-the-Project.md)

## Getting Started

1. Clone the repository
2. Navigate to the project directory
3. Run `dotnet build` to build the project
4. Run `dotnet run -- --help` for usage instructions

## Requirements

- .NET 8.0 or later
