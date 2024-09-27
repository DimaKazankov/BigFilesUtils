namespace BigFilesUtils;

public class Fibonacci
{
    public IEnumerable<int> GetFibonacci(int count)
    {
        var w = 1;
        var x = 1;

        yield return x;
        foreach (var _ in Enumerable.Range(1, count - 1))
        {
            var y = w + x;
            yield return y;
            w = x;
            x = y;
        }
    }
}