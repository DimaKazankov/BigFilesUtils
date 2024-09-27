# Load necessary libraries
library(ggplot2)

# Read the CSV file
data <- read.csv("BenchmarkDotNet.Artifacts/results/FibonacciBenchmark-report.csv")

# Check the data structure (for debugging)
print(head(data))

# Create a bar chart using ggplot2
p <- ggplot(data, aes(x=Method, y=Mean)) +
     geom_bar(stat="identity", fill="blue") +
     labs(title="Fibonacci Benchmark Results", x="Method", y="Mean Time (ns)") +
     theme_minimal()

# Save the plot as a PNG file
ggsave("docs/FibonacciBenchmark-plot.png", plot = p)
