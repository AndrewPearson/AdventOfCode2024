namespace Day6.Model;

public class Map
{
    private readonly List<Floor[]> _rows = new();

    public void AddRow(Floor[] row)
    {
        _rows.Add(row);
    }

    public Floor At(Position position) => _rows[position.Row][position.Column];

    public int RowCount => _rows.Count;
    public int ColumnCount => _rows[0].Length;

    public bool OnMap(Position position)
    {
        return position.Row >= 0
               && position.Row < RowCount
               && position.Column >= 0
               && position.Column < ColumnCount;
    }

    public void SetAt(Position position, Floor newType)
    {
        _rows[position.Row][position.Column] = newType;
    }
}