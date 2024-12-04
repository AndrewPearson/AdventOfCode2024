using System.Text;

namespace Day4;

public static class CrossMasFinder
{
    public static List<Location> Check(Grid grid)
    {
        var xmases = new List<Location>();
        for (int r = 1; r < grid.RowCount-1; ++r)
        {
            for (int c = 1; c < grid.ColumnCount-1; ++c)
            {
                var l = new Location(r, c);
                    if (CheckLocation(grid, l))
                        xmases.Add(l);
            }
        }

        return xmases;
    }

    private static bool CheckLocation(Grid grid, Location loc)
    {
        int countMatch = 0;
        if (UpLeftPath(grid, loc) == Mas)
            countMatch++;

        if(DownLeftPath(grid, loc)==Mas)
            countMatch++;

        if(UpRightPath(grid, loc)==Mas)
            countMatch++;

        if(DownRightPath(grid, loc)==Mas)
            countMatch++;

        return countMatch == 2;
    }

    private const string Mas = "MAS";

    private static string UpLeftPath(Grid grid, Location loc)
    {
        int count = 0;
        int col = loc.Col+1;
        int row = loc.Row+1;
        var sb = new StringBuilder();
        do
        {
            sb.Append(grid.At(row, col));
            col--;
            row--;
            count++;
        } while (count<Mas.Length && row >= 0 && col >= 0);

        return sb.ToString();
    }

    private static string UpRightPath(Grid grid, Location loc)
    {
        int count = 0;
        int col = loc.Col-1;
        int row = loc.Row+1;
        var sb = new StringBuilder();
        do
        {
            sb.Append(grid.At(row, col));
            col++;
            row--;
            count++;
        } while (count<Mas.Length && row >= 0 && col < grid.ColumnCount);

        return sb.ToString();
    }

    private static string DownLeftPath(Grid grid, Location loc)
    {
        int count = 0;
        int col = loc.Col+1;
        int row = loc.Row-1;
        var sb = new StringBuilder();
        do
        {
            sb.Append(grid.At(row, col));
            col--;
            row++;
            count++;
        } while (count<Mas.Length && row < grid.RowCount && col >= 0);

        return sb.ToString();
    }

    private static string DownRightPath(Grid grid, Location loc)
    {
        int count = 0;
        int col = loc.Col-1;
        int row = loc.Row-1;
        var sb = new StringBuilder();
        do
        {
            sb.Append(grid.At(row, col));
            col++;
            row++;
            count++;
        } while (count<Mas.Length && row < grid.RowCount && col < grid.ColumnCount);

        return sb.ToString();
    }
}