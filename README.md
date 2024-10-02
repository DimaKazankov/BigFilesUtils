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
