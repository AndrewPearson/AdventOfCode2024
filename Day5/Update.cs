namespace Day5;

public class Update
{
    private readonly int[] _pages;

    public Update(int[] pages)
    {
        _pages = pages;
    }

    public IReadOnlyList<int> Pages => _pages;

    public int MidPage
    {
        get
        {
            int mid = _pages.Length / 2;
            return _pages[mid];
        }
    }

    public override string ToString()
    {
        return string.Join(',', _pages);
    }
}