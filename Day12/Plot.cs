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

        // calc perimeter
        var locs = _squares.Select(static s => s.Location).ToHashSet();

        var perim = 0;
        foreach (var loc in locs)
        {
            var surrounding = new[]
            {
                loc with { Row = loc.Row - 1 },
                loc with { Row = loc.Row + 1 },
                loc with { Column = loc.Column - 1 },
                loc with { Column = loc.Column + 1 },
            };

            perim += surrounding.Select(x => locs.Contains(x) ? 0 : 1).Sum();
        }

        Perimeter = perim;
    }

    public IEnumerable<Square> Squares => _squares;

    public char Type { get; }

    public long Perimeter { get; }

    public long Area => _squares.Count;
}