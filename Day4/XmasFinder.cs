using System.Text;

namespace Day4;

public static class XmasFinder
{
    public static List<LocationAndDir> Check(Grid grid)
    {
        var xmases = new List<LocationAndDir>();
        for (int r = 0; r < grid.RowCount; ++r)
        {
            for (int c = 0; c < grid.ColumnCount; ++c)
            {
                foreach (var dir in Enum.GetValues<Direction>())
                {
                    var ld = new LocationAndDir(r, c, dir);
                    if (CheckForXmas(grid, ld))
                        xmases.Add(ld);
                }
            }
        }

        return xmases;
    }

    private static bool CheckForXmas(Grid grid, LocationAndDir ld)
    {
        var path = GetPath(grid, ld);
        return "XMAS" == path;
    }

    private static string GetPath(Grid grid, LocationAndDir ld)
    {
        switch (ld.Direction)
        {
            case Direction.Up:
                return UpPath(grid, ld);
            case Direction.UpRight:
                return UpRightPath(grid, ld);
            case Direction.Right:
                return RightPath(grid, ld);
            case Direction.DownRight:
                return DownRightPath(grid, ld);
            case Direction.Down:
                return DownPath(grid, ld);
            case Direction.DownLeft:
                return DownLeftPath(grid, ld);
            case Direction.Left:
                return LeftPath(grid, ld);
            case Direction.UpLeft:
                return UpLeftPath(grid, ld);
            default:
                throw new InvalidOperationException($"The direction {ld.Direction} is not recognised.");
        }
    }

    private static readonly int XmasCount = "XMAS".Length;

    private static string UpPath(Grid grid, LocationAndDir ld)
    {
        int count = 0;
        int row = ld.Row;
        var sb = new StringBuilder();
        do
        {
            sb.Append(grid.At(row, ld.Col));
            row--;
            count++;
        } while (count<XmasCount && row >= 0);

        return sb.ToString();
    }

    private static string DownPath(Grid grid, LocationAndDir ld)
    {
        int count = 0;
        int row = ld.Row;
        var sb = new StringBuilder();
        do
        {
            sb.Append(grid.At(row, ld.Col));
            row++;
            count++;
        } while (count<XmasCount && row < grid.RowCount);

        return sb.ToString();
    }

    private static string UpLeftPath(Grid grid, LocationAndDir ld)
    {
        int count = 0;
        int col = ld.Col;
        int row = ld.Row;
        var sb = new StringBuilder();
        do
        {
            sb.Append(grid.At(row, col));
            col--;
            row--;
            count++;
        } while (count<XmasCount && row >= 0 && col >= 0);

        return sb.ToString();
    }

    private static string UpRightPath(Grid grid, LocationAndDir ld)
    {
        int count = 0;
        int col = ld.Col;
        int row = ld.Row;
        var sb = new StringBuilder();
        do
        {
            sb.Append(grid.At(row, col));
            col++;
            row--;
            count++;
        } while (count<XmasCount && row >= 0 && col < grid.ColumnCount);

        return sb.ToString();
    }

    private static string LeftPath(Grid grid, LocationAndDir ld)
    {
        int count = 0;
        int col = ld.Col;
        var sb = new StringBuilder();
        do
        {
            sb.Append(grid.At(ld.Row, col));
            col--;
            count++;
        } while (count<XmasCount && col >= 0);

        return sb.ToString();
    }

    private static string RightPath(Grid grid, LocationAndDir ld)
    {
        int count = 0;
        int col = ld.Col;
        var sb = new StringBuilder();
        do
        {
            sb.Append(grid.At(ld.Row, col));
            col++;
            count++;
        } while (count<XmasCount && col < grid.ColumnCount);

        return sb.ToString();
    }

    private static string DownLeftPath(Grid grid, LocationAndDir ld)
    {
        int count = 0;
        int col = ld.Col;
        int row = ld.Row;
        var sb = new StringBuilder();
        do
        {
            sb.Append(grid.At(row, col));
            col--;
            row++;
            count++;
        } while (count<XmasCount && row < grid.RowCount && col >= 0);

        return sb.ToString();
    }

    private static string DownRightPath(Grid grid, LocationAndDir ld)
    {
        int count = 0;
        int col = ld.Col;
        int row = ld.Row;
        var sb = new StringBuilder();
        do
        {
            sb.Append(grid.At(row, col));
            col++;
            row++;
            count++;
        } while (count<XmasCount && row < grid.RowCount && col < grid.ColumnCount);

        return sb.ToString();
    }
}