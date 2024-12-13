namespace Day12;

public class Plot
{
    private readonly HashSet<Square> _squares;

    public Plot(HashSet<Square> squares)
    {
        _squares = squares;
        foreach (var square in _squares)
        {
            square.InPlot = true;
        }

        Type = _squares.First().Type;
        Perimeter = this.CalculatePerimeter();
        Sides = this.CountSides();
    }

    public IEnumerable<Square> Squares => _squares;

    public char Type { get; }

    public long Perimeter { get; }

    public long Sides { get; }

    public long Area => _squares.Count;
}