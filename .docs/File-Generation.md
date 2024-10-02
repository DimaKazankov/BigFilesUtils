# File Generation

This document describes the file generation algorithms implemented in the project.

## Algorithms

### 1. Original

- **Implementation**: `FileGenerator` class
- **Description**: Basic file generation using `StreamWriter`.
- **Characteristics**: Simple implementation, suitable for small to medium-sized files.

### 2. Buffered

- **Implementation**: `FileGeneratorBuffered` class
- **Description**: Uses a `StringBuilder` for buffering before writing to the file.
- **Characteristics**: Improved performance for larger files by reducing I/O operations.

### 3. Parallel

- **Implementation**: `FileGeneratorParallel` class
- **Description**: Generates file content in parallel using multiple threads.
- **Characteristics**: Significantly faster for large files, especially on multi-core systems.

### 4. MemoryMapped

- **Implementation**: `FileGeneratorMemoryMapped` class
- **Description**: Uses memory-mapped files for generation.
- **Characteristics**: Efficient for very large files, allows direct memory access.

For details on other implementations, please refer to the source code.