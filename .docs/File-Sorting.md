# File Sorting

This document describes the file sorting algorithms implemented in the project.

## Algorithms

### 1. ExternalMerge

- **Implementation**: `ExternalMergeFileSorter` class
- **Description**: Splits the file into sorted chunks and merges them.
- **Characteristics**: Efficient for large files that don't fit in memory.

### 2. KWayMerge

- **Implementation**: `KWayMergeFileSorter` class
- **Description**: Similar to ExternalMerge but with K-way merging.
- **Characteristics**: Can be more efficient than binary merge for certain file sizes.

### 3. Parallel

- **Implementation**: `ParallelExternalFileSorter` class
- **Description**: Sorts chunks of the file in parallel.
- **Characteristics**: Faster on multi-core systems, especially for large files.

### 4. MemoryMapped

- **Implementation**: `MemoryMappedFileSorter` class
- **Description**: Uses memory-mapped files for sorting.
- **Characteristics**: Efficient for very large files, allows direct memory access.

### 5. ChunkedMemoryMapped

- **Implementation**: `ChunkedMemoryMappedFileSorter` class
- **Description**: Combines memory-mapped file access with chunked sorting and K-way merging.
- **Characteristics**: Efficient for very large files, balances memory usage and performance.

## Sorting Strategy

The project uses a combination of external sorting for handling large files and in-memory sorting for individual chunks.

The in-memory sorting is performed by the `ISorter` implementation passed to the `FileSorter` constructor.

Two in-memory sorting algorithms are provided:

1. **DefaultSorter**: Uses LINQ's OrderBy method.
2. **QuickSorter**: Implements the QuickSort algorithm.

You can implement your own `ISorter` for custom in-memory sorting strategies.