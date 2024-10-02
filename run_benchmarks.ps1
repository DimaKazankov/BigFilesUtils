$startTime = Get-Date

dotnet build -c Release
dotnet publish -c Release --verbosity normal -o ./publish/
dotnet "./publish/FileAlgorithms.Benchmark.dll" --filter "*FileGeneratorBenchmark*" --job short
dotnet "./publish/FileAlgorithms.Benchmark.dll" --filter "*" --job short
# End time
$endTime = Get-Date

# Calculate total time
$totalTime = $endTime - $startTime
Write-Host "Total Benchmark Execution Time: $totalTime"