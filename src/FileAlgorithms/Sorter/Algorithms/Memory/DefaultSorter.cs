namespace FileAlgorithms.Sorter.Algorithms.Memory;

public class DefaultSorter : ISorter
{
    public void Sort(List<string> lines)
    {
        lines.Sort((a, b) =>
        {
            var compResult = string.Compare(a.Substring(a.IndexOf('.') + 2), b.Substring(b.IndexOf('.') + 2), StringComparison.Ordinal);
            if (compResult != 0) return compResult;
            return int.Parse(a.Substring(0, a.IndexOf('.'))).CompareTo(int.Parse(b.Substring(0, b.IndexOf('.'))));
        });
    }

}