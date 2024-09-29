# PowerShell script to build the project and run benchmarks

# Change directory to the benchmark project
cd "C:\.projects\BigFilesUtils\src\BigFilesUtils"

# Build the project in Release mode
dotnet build -c Release

# Run the benchmarks
dotnet run -c Release --framework net8.0 --filter * --artifacts ./BenchmarkResults
