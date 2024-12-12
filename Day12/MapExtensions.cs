namespace Day12;

public static class MapExtensions
{
    public static List<Plot> FindPlots(this Map map)
    {
        bool finished;
        var plots = new List<Plot>();
        do
        {
            var start = map.Squares.Where(static s => !s.InPlot).FirstOrDefault();
            finished = start is null;

            if (start is not null)
            {
                var plotSquares = map.FindPlotFrom(start);
                plots.Add(new Plot(plotSquares));
            }
        } while (!finished);

        return plots;
    }

    private static HashSet<Square> FindPlotFrom(this Map map, Square start)
    {
        var locs = new HashSet<Square> { start };
        map.FindPlot(locs, start);
        return locs;
    }

    private static void FindPlot(this Map map, HashSet<Square> squaresSoFar, Square squareToCheck)
    {
        var locsToCheck = new[]
        {
            squareToCheck.Location with { Row = squareToCheck.Location.Row - 1 }, // up
            squareToCheck.Location with { Row = squareToCheck.Location.Row + 1 }, // down
            squareToCheck.Location with { Column = squareToCheck.Location.Column - 1 }, // left
            squareToCheck.Location with { Column = squareToCheck.Location.Column + 1 }, // right
        };

        foreach (var location in locsToCheck)
        {
            if (!map.Contains(location))
                continue;

            var sq = map.At(location);
            if (squaresSoFar.Contains(sq))
                continue;

            if (sq.Type == squareToCheck.Type)
            {
                squaresSoFar.Add(sq);
                map.FindPlot(squaresSoFar, sq);
            }
        }
    }

    public static void PrintPlot(this TextWriter writer, Map map, Plot plot)
    {
        var locs = plot.Squares.Select(static s => s.Location).ToHashSet();
        for (int r = 0; r < map.RowCount; ++r)
        {
            for (int c = 0; c < map.ColumnCount; ++c)
            {
                var loc = new Location(r, c);
                var text = locs.Contains(loc)
                    ? $"{map.At(loc).Type}"
                    : ".";
                writer.Write(text);
            }
            writer.WriteLine();
        }
        writer.WriteLine();

    }

    public static void PrintMap(this TextWriter writer, Map map)
    {
        for (int r = 0; r < map.RowCount; ++r)
        {
            for (int c = 0; c < map.ColumnCount; ++c)
            {
                var loc = new Location(r, c);
                writer.Write(map.At(loc).Type);
            }
            writer.WriteLine();
        }
        writer.WriteLine();

    }}