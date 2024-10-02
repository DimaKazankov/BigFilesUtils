# Benchmarking

This document describes the benchmarking capabilities of the project.

## Overview

The project uses BenchmarkDotNet to measure and compare the performance of different file generation and sorting algorithms. Two main benchmark classes are provided:

1. `FileGeneratorBenchmark`: Benchmarks file generation algorithms.
2. `FileSorterBenchmark`: Benchmarks file sorting algorithms.

## Benchmark Configuration

Benchmarks are configured using the `CustomConfig` class, which sets up the following:

- R Plot exporter
- GitHub Markdown exporter
- Memory diagnoser
- Columns for method, statistics, and rank
- Summary style with seconds as time unit and MB as size unit

## Benchmark Parameters

### FileGeneratorBenchmark

- `FileSizeInBytes`: Size of the file to generate (100MB and 1GB)
- `Generator`: Type of generator to use (Original, Buffered, Parallel, MemoryMapped)

### FileSorterBenchmark

- `FileSizeInBytes`: Size of the file to sort (50MB and 100MB)
- `Sorter`: Type of sorter to use (ExternalMerge, KWayMerge, Parallel, MemoryMapped)
- `MemorySorter`: Type of in-memory sorter to use (Default, Quick)

This output shows the mean execution time, error, standard deviation, median, rank, and memory allocation for each sorting algorithm.

## Interpreting Results

- **Mean**: Average execution time
- **Error**: Half of 99.9% confidence interval
- **StdDev**: Standard deviation of all measurements
- **Median**: Middle value of all measurements
- **Rank**: Relative ranking of the method (lower is better)
- **Gen0/1/2**: Number of gen 0/1/2 collections
- **Allocated**: Amount of allocated memory

When interpreting results, consider not only the mean execution time but also the memory allocation and garbage collection statistics. The best algorithm may depend on your specific use case and hardware constraints.