# File Algorithms Project

## Requirements
For more detailed information, please refer to the following [documentation](.docs/Requirements.md):

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

GitHub benchmark results are regenerating on every pipeline run
[GitHub benchmark results](.docs/GitHubResults.md)

Manual run on my machine 
[My local machine benchmark results](.docs/MyLocalMachineResults.md)

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
