namespace Day12;

public class Map
{
    private readonly List<Square[]> _squares;

    public Map(List<string> rows)
    {
        _squares = rows.Select(static (row, i) =>
            {
                return row
                    .Select((c, j) => new Square(new Location(i, j), c))
                    .ToArray();
            })
            .ToList();
    }

    public int RowCount => _squares.Count;

    public int ColumnCount => _squares[0].Length;

    public Square At(Location loc) => _squares[loc.Row][loc.Column];

    public IEnumerable<Square> Squares => _squares.SelectMany(static r => r);

    public bool Contains(Location loc)
    {
        return loc.Row >= 0
               && loc.Row < RowCount
               && loc.Column >= 0
               && loc.Column < ColumnCount;
    }


}