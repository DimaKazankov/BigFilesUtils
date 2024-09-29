# PowerShell script to build the project and run benchmarks
# Start time
$startTime = Get-Date

# Build the project in Release mode
dotnet build -c Release

# Run the benchmarks
dotnet run -c Release --framework net8.0 --filter *

# End time
$endTime = Get-Date

# Calculate total time
$totalTime = $endTime - $startTime
Write-Host "Total Benchmark Execution Time: $totalTime"