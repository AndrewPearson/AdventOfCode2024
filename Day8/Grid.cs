namespace Day8;

public class Grid
{
    public Grid(int rowCount, int colCount, List<Antenna> antennae)
    {
        RowCount = rowCount;
        ColumnCount = colCount;
        Antennae = antennae;
    }

    public int RowCount { get; }
    public int ColumnCount { get; }
    public List<Antenna> Antennae { get; }

    public bool Contains(Position pos)
    {
        return pos.Row >= 0
               && pos.Row < RowCount
               && pos.Column >= 0
               && pos.Column < ColumnCount;
    }
}