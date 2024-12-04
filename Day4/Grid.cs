using System.Text;

namespace Day4;

public class Grid
{
    private readonly List<string> _lines;

    public Grid(List<string> lines)
    {
        _lines = lines;
    }

    public char At(int row, int col)
    {
        return _lines[row][col];
    }

    public int RowCount => _lines.Count;

    public int ColumnCount => _lines[0].Length;

    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach (var line in _lines)
        {
            sb.AppendLine(line);
        }
        var ret = sb.ToString();
        return ret;
    }
}