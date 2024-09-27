# Load necessary libraries
library(ggplot2)
library(dplyr)
library(tidyr)
library(patchwork)  # For arranging multiple plots
library(scales)     # For formatting

# Install required packages if they are not installed
packages <- c("ggplot2", "dplyr", "tidyr", "patchwork", "scales")
install_if_missing <- function(p) {
  if (!requireNamespace(p, quietly = TRUE)) {
    install.packages(p, repos = "https://cloud.r-project.org/")
  }
}
invisible(lapply(packages, install_if_missing))

# Read the CSV file
data <- read.csv("BenchmarkDotNet.Artifacts/results/FileGeneratorBenchmark-report.csv", stringsAsFactors = FALSE)

# Function to remove the "ns" suffix and convert to numeric
clean_ns <- function(column) {
  as.numeric(sub(" ns", "", column))
}

# Clean and prepare data
data_clean <- data %>%
  mutate(
    Mean = clean_ns(Mean),
    Min = clean_ns(Min),
    Max = clean_ns(Max),
    StdDev = clean_ns(StdDev),
    Q1 = clean_ns(Q1),
    Q3 = clean_ns(Q3),
    Median = clean_ns(Median),
    FileSizeBytes = as.numeric(FileSizeInBytes)
  ) %>%
  # Convert times to seconds
  mutate(
    MeanSec = Mean / 1e9,
    MinSec = Min / 1e9,
    MaxSec = Max / 1e9,
    StdDevSec = StdDev / 1e9,
    Q1Sec = Q1 / 1e9,
    Q3Sec = Q3 / 1e9,
    MedianSec = Median / 1e9
  ) %>%
  # Convert file sizes to appropriate units
  mutate(
    FileSizeValue = case_when(
      FileSizeBytes >= 1024^3 ~ FileSizeBytes / 1024^3,
      FileSizeBytes >= 1024^2 ~ FileSizeBytes / 1024^2,
      FileSizeBytes >= 1024    ~ FileSizeBytes / 1024,
      TRUE                     ~ FileSizeBytes
    ),
    FileSizeUnit = case_when(
      FileSizeBytes >= 1024^3 ~ "GB",
      FileSizeBytes >= 1024^2 ~ "MB",
      FileSizeBytes >= 1024   ~ "KB",
      TRUE                    ~ "B"
    ),
    FileSizeLabel = paste0(FileSizeValue, " ", FileSizeUnit)
  )

# Ensure FileSizeLabel is a factor with the correct order
data_clean$FileSizeLabel <- factor(data_clean$FileSizeLabel, levels = unique(data_clean$FileSizeLabel))

# Plot 1: Execution Time Distribution (Boxplot-like Visualization)
p1 <- ggplot(data_clean, aes(x = FileSizeLabel)) +
  geom_boxplot(
    aes(
      ymin = MinSec,
      lower = Q1Sec,
      middle = MedianSec,
      upper = Q3Sec,
      ymax = MaxSec
    ),
    stat = "identity",
    fill = "lightblue"
  ) +
  labs(
    title = "Execution Time Distribution",
    x = "File Size",
    y = "Time (seconds)"
  ) +
  theme_minimal(base_size = 14) +
  theme(
    plot.title = element_text(face = "bold", hjust = 0.5)
  )

# Plot 2: Mean Execution Time with Standard Deviation (Line Plot with Error Bars)
p2 <- ggplot(data_clean, aes(x = FileSizeBytes, y = MeanSec)) +
  geom_line(color = "steelblue", size = 1) +
  geom_point(color = "steelblue", size = 3) +
  geom_errorbar(aes(ymin = MeanSec - StdDevSec, ymax = MeanSec + StdDevSec), width = 0, color = "orange") +
  scale_x_continuous(
    labels = function(x) {
      case_when(
        x >= 1024^3 ~ paste0(x / 1024^3, " GB"),
        x >= 1024^2 ~ paste0(x / 1024^2, " MB"),
        x >= 1024   ~ paste0(x / 1024, " KB"),
        TRUE        ~ paste0(x, " B")
      )
    },
    breaks = data_clean$FileSizeBytes
  ) +
  labs(
    title = "Mean Execution Time with Standard Deviation",
    x = "File Size",
    y = "Mean Time (seconds)"
  ) +
  theme_minimal(base_size = 14) +
  theme(
    plot.title = element_text(face = "bold", hjust = 0.5)
  )

# Plot 3: Throughput vs File Size
data_clean <- data_clean %>%
  mutate(
    ThroughputMBps = (FileSizeBytes / (1024^2)) / MeanSec  # MB per second
  )

p3 <- ggplot(data_clean, aes(x = FileSizeBytes, y = ThroughputMBps)) +
  geom_line(color = "darkgreen", size = 1) +
  geom_point(color = "darkgreen", size = 3) +
  scale_x_continuous(
    labels = function(x) {
      case_when(
        x >= 1024^3 ~ paste0(x / 1024^3, " GB"),
        x >= 1024^2 ~ paste0(x / 1024^2, " MB"),
        x >= 1024   ~ paste0(x / 1024, " KB"),
        TRUE        ~ paste0(x, " B")
      )
    },
    breaks = data_clean$FileSizeBytes
  ) +
  labs(
    title = "Throughput vs File Size",
    x = "File Size",
    y = "Throughput (MB/s)"
  ) +
  theme_minimal(base_size = 14) +
  theme(
    plot.title = element_text(face = "bold", hjust = 0.5)
  )

# Combine plots using patchwork
combined_plot <- p1 / p2 / p3 + plot_layout(ncol = 1)

# Save the combined plot
ggsave("BenchmarkDotNet.Artifacts/results/FileGeneratorBenchmark-plot.png", plot = combined_plot, width = 12, height = 18, dpi = 300)
