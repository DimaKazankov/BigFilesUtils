# Load necessary libraries
library(ggplot2)
library(reshape2)

# Read the CSV file
data <- read.csv("BenchmarkDotNet.Artifacts/results/FileGeneratorBenchmark-report.csv")

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

# Ensure 'FileSizeInBytes' is treated as a factor (categorical variable)
data$FileSizeInBytes <- as.factor(data$FileSizeInBytes)

# Select the necessary columns for plotting
metrics <- data.frame(
  FileSizeInBytes = data$FileSizeInBytes,  # Include FileSizeInBytes for grouping
  Method = data$Method,
  Mean = data$Mean,
  StdDev = data$StdDev,
  Min = data$Min,
  Max = data$Max,
  Q1 = data$Q1,
  Q3 = data$Q3
)

# Melt the data for ggplot (long format for multiple metrics)
metrics_melted <- melt(metrics, id.vars = c('Method', 'FileSizeInBytes'), 
                       variable.name = 'Metric', value.name = 'Value')

# Ensure the 'Value' column is numeric
metrics_melted$Value <- as.numeric(metrics_melted$Value)

# Create a grouped bar chart showing different metrics for each method and file size
p <- ggplot(metrics_melted, aes(x = Method, y = Value, fill = Metric)) +
  geom_bar(stat="identity", position = "dodge") +
  facet_wrap(~ FileSizeInBytes) +  # Create separate plots for each FileSizeInBytes
  labs(title="File Generator Benchmark Results", x="Method", y="Time (ns)", fill="Metric") +
  theme_minimal(base_size = 15) +
  scale_fill_brewer(palette="Set2") +  # Using a color palette from RColorBrewer
  theme(
    plot.title = element_text(size=20, face="bold", hjust=0.5, color="white"),
    axis.title.x = element_text(face="bold", size=15, color="white"),
    axis.title.y = element_text(face="bold", size=15, color="white"),
    axis.text.x = element_text(angle=45, hjust=1, color="white"),
    axis.text.y = element_text(color="white"),
    legend.title = element_text(color="white"),
    legend.text = element_text(color="white"),
    panel.grid = element_line(color = "gray50"),
    legend.position = "bottom"
  ) +
  scale_y_continuous(labels = scales::comma)

# Save the plot as a PNG file
ggsave("BenchmarkDotNet.Artifacts/results/FileGeneratorBenchmark-plot.png", plot = p, width = 10, height = 6, dpi = 300)
