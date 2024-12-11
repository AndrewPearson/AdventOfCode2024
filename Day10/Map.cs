namespace Day10;

public class Map
{
    private readonly List<int[]> _rows;

    public Map(List<int[]> rows)
    {
        _rows = rows;
    }

    public int RowCount => _rows.Count;

    public int ColumnCount => _rows[0].Length;

    public int At(Location loc) => _rows[loc.Row][loc.Column];

    public IEnumerable<Location> Starts()
    {
        for (int row = 0; row < RowCount; ++row)
        {
            for (int col = 0; col < ColumnCount; ++col)
            {
                if (_rows[row][col] == 0)
                    yield return new Location(row, col);
            }
        }
    }

    public bool Contains(Location loc)
    {
        return loc.Row >= 0
               && loc.Row < RowCount
               && loc.Column >= 0
               && loc.Column < ColumnCount;
    }


}