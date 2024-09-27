# Load necessary libraries
library(ggplot2)
library(gridExtra)   # For arranging multiple plots
library(reshape2)
library(scales)      # For number formatting

# Read the CSV file
data <- read.csv("BenchmarkDotNet.Artifacts/results/FileGeneratorBenchmark-report.csv")

# Function to remove the "ns" suffix and convert to numeric
clean_ns <- function(column) {
  as.numeric(gsub(" ns", "", column))
}

# Apply the cleaning function to all relevant columns
data$Min <- clean_ns(data$Min)
data$Q1 <- clean_ns(data$Q1)
data$Median <- clean_ns(data$Median)
data$Mean <- clean_ns(data$Mean)
data$Q3 <- clean_ns(data$Q3)
data$Max <- clean_ns(data$Max)
data$StdDev <- clean_ns(data$StdDev)

# Convert times from nanoseconds to seconds
data$MinSec <- data$Min / 1e9
data$Q1Sec <- data$Q1 / 1e9
data$MedianSec <- data$Median / 1e9
data$MeanSec <- data$Mean / 1e9
data$Q3Sec <- data$Q3 / 1e9
data$MaxSec <- data$Max / 1e9
data$StdDevSec <- data$StdDev / 1e9

# Convert FileSizeInBytes to MB
data$FileSizeMB <- data$FileSizeInBytes / (1024^2)

# Convert FileSizeMB to factor for boxplot
data$FileSizeMB_Factor <- factor(data$FileSizeMB, levels = sort(unique(data$FileSizeMB)))

# Prepare data for boxplot
boxplot_data <- data.frame(
  FileSizeMB = data$FileSizeMB_Factor,
  Min = data$MinSec,
  Q1 = data$Q1Sec,
  Median = data$MedianSec,
  Q3 = data$Q3Sec,
  Max = data$MaxSec
)

# Since we have summary statistics, we can use geom_boxplot with stat = "identity"
p1 <- ggplot(boxplot_data, aes(x = FileSizeMB, ymin = Min, lower = Q1, middle = Median, upper = Q3, ymax = Max)) +
  geom_boxplot(stat = "identity", fill = "steelblue") +
  labs(title = "Execution Time Distribution",
       x = "File Size (MB)",
       y = "Time (seconds)") +
  theme_minimal(base_size = 12) +
  theme(
    plot.title = element_text(size=14, face="bold", hjust=0.5),
    axis.title.x = element_text(face="bold", size=12),
    axis.title.y = element_text(face="bold", size=12)
  )

# Prepare data for line plot with error bars
plot_data <- data.frame(
  FileSizeMB = data$FileSizeMB,
  MeanSec = data$MeanSec,
  StdDevSec = data$StdDevSec
)

# Line plot with error bars
p2 <- ggplot(plot_data, aes(x = FileSizeMB, y = MeanSec)) +
  geom_line(color = "steelblue", size = 1) +
  geom_point(color = "steelblue", size = 2) +
  geom_errorbar(aes(ymin = MeanSec - StdDevSec, ymax = MeanSec + StdDevSec), width = 5, color = "orange") +
  labs(title = "Mean Execution Time with Standard Deviation",
       x = "File Size (MB)",
       y = "Mean Time (seconds)") +
  theme_minimal(base_size = 12) +
  theme(
    plot.title = element_text(size=14, face="bold", hjust=0.5),
    axis.title.x = element_text(face="bold", size=12),
    axis.title.y = element_text(face="bold", size=12)
  )

# Throughput calculation
data$ThroughputMBps <- data$FileSizeMB / data$MeanSec  # MB / sec

# Throughput plot
p3 <- ggplot(data, aes(x = FileSizeMB, y = ThroughputMBps)) +
  geom_line(color = "green", size = 1) +
  geom_point(color = "green", size = 2) +
  labs(title = "Throughput vs File Size",
       x = "File Size (MB)",
       y = "Throughput (MB/s)") +
  theme_minimal(base_size = 12) +
  theme(
    plot.title = element_text(size=14, face="bold", hjust=0.5),
    axis.title.x = element_text(face="bold", size=12),
    axis.title.y = element_text(face="bold", size=12)
  )

# Arrange all plots in one image
combined_plot <- grid.arrange(p1, p2, p3, ncol = 1)

# Save the combined plot as a PNG file
ggsave("BenchmarkDotNet.Artifacts/results/FileGeneratorBenchmark-plot.png", plot = combined_plot, width = 8, height = 18, dpi = 300)
