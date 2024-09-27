# Load necessary libraries
library(ggplot2)
library(reshape2)

# Read the CSV file
data <- read.csv("BenchmarkDotNet.Artifacts/results/FibonacciBenchmark-report.csv")

# Function to remove the "ns" suffix and convert to numeric
clean_ns <- function(column) {
  as.numeric(gsub(" ns", "", column))
}

# Apply the cleaning function to all relevant columns
data$Mean <- clean_ns(data$Mean)
data$Min <- clean_ns(data$Min)
data$Max <- clean_ns(data$Max)
data$Q1 <- clean_ns(data$Q1)
data$Q3 <- clean_ns(data$Q3)
data$Median <- clean_ns(data$Median)

# Select the necessary columns for plotting
metrics <- data.frame(
  Method = data$Method,
  Mean = data$Mean,
  StdDev = data$StdDev,
  Min = data$Min,
  Max = data$Max,
  Q1 = data$Q1,
  Q3 = data$Q3
)

# Melt the data for ggplot (long format for multiple metrics)
metrics_melted <- melt(metrics, id.vars = 'Method', 
                       variable.name = 'Metric', value.name = 'Value')

# Ensure the 'Value' column is numeric
metrics_melted$Value <- as.numeric(metrics_melted$Value)

# Print the first few rows for debugging
print(head(metrics_melted))

# Create a grouped bar chart showing different metrics for each method
p <- ggplot(metrics_melted, aes(x = Method, y = Value, fill = Metric)) +
  geom_bar(stat="identity", position = "dodge") +
  labs(title="Fibonacci Benchmark Results", x="Method", y="Time (ns)", fill="Metric") +
  theme_minimal(base_size = 15) +
  scale_fill_brewer(palette="Set2") +  # Using a color palette from RColorBrewer
  theme(
    axis.text.x = element_text(angle=45, hjust=1),  # Rotate x-axis labels for readability
    plot.title = element_text(size=20, face="bold", hjust=0.5),
    axis.title.x = element_text(face="bold", size=15),
    axis.title.y = element_text(face="bold", size=15),
    legend.position = "bottom"
  ) +
  scale_y_continuous(labels = scales::comma)  # Format y-axis numbers with commas

# Save the plot as a PNG file
ggsave("BenchmarkDotNet.Artifacts/results/FibonacciBenchmark-plot.png", plot = p, width = 10, height = 6, dpi = 300)
