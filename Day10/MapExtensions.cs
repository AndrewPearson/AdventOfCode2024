namespace Day10;

public static class MapExtensions
{
    public static List<Trail> FindTrails(this Map map)
    {
        var trails = map.Starts()
            .SelectMany(s => map.FindAllTrailsFrom(s))
            .ToList();

        return trails;
    }

    private static List<Trail> FindAllTrailsFrom(this Map map, Location start)
    {
        var locs = new List<Location> { start };
        var routes = map.FindRoute(locs);

        return routes.Select(static r => new Trail(r)).ToList();
    }

    private static IEnumerable<List<Location>> FindRoute(this Map map, List<Location> pathSoFar)
    {
        var start = pathSoFar[^1];
        var nextHeight = map.At(start) + 1;

        if (nextHeight == 10)
            yield return pathSoFar;

        var locsToCheck = new[]
        {
            start with { Row = start.Row - 1 }, // up
            start with { Row = start.Row + 1 }, // down
            start with { Column = start.Column - 1 }, // left
            start with { Column = start.Column + 1 }, // right
        };

        var routes = locsToCheck.SelectMany(loc =>
            {
                if (map.Contains(loc) && map.At(loc) == nextHeight)
                {
                    var newPaths = new List<Location>(pathSoFar) { loc };

                    var upRoutes = map.FindRoute(newPaths);
                    return upRoutes;
                }

                return [];
            })
            .ToList();

        foreach (var route in routes)
        {
            yield return route;
        }
    }

    public static void PrintTrail(this TextWriter writer, Map map, Trail trail)
    {
        var locs = trail.Path.ToHashSet();
        for (int r = 0; r < map.RowCount; ++r)
        {
            for (int c = 0; c < map.ColumnCount; ++c)
            {
                var loc = new Location(r, c);
                var text = locs.Contains(loc)
                    ? $"{map.At(loc)}"
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
                writer.Write(map.At(loc));
            }
            writer.WriteLine();
        }
        writer.WriteLine();

    }}