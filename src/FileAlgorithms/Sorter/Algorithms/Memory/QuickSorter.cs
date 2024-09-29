namespace FileAlgorithms.Sorter.Algorithms.Memory;

public class QuickSorter : ISorter
{
    public void Sort(List<string> lines)
    {
        Sort(lines, 0, lines.Count - 1);
    }

    private void Sort(List<string> lines, int low, int high)
    {
        if (low < high)
        {
            var partitionIndex = Partition(lines, low, high);

            Sort(lines, low, partitionIndex - 1);
            Sort(lines, partitionIndex + 1, high);
        }
    }
    
    private int Partition(List<string> lines, int low, int high)
    {
        var pivot = lines[high];
        var i = low - 1;

        for (var j = low; j < high; j++)
        {
            if (CompareLines(lines[j], pivot) <= 0)
            {
                i++;
                (lines[i], lines[j]) = (lines[j], lines[i]);
            }
        }

        (lines[i + 1], lines[high]) = (lines[high], lines[i + 1]);

        return i + 1;
    }
    
    private int CompareLines(string a, string b)
    {
        var compResult = string.Compare(a.Substring(a.IndexOf('.') + 2), b.Substring(b.IndexOf('.') + 2), StringComparison.Ordinal);
        return compResult != 0 ? compResult : int.Parse(a.Substring(0, a.IndexOf('.'))).CompareTo(int.Parse(b.Substring(0, b.IndexOf('.'))));
    }
}