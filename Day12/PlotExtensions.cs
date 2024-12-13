using System.Security.Cryptography.X509Certificates;

namespace Day12;

public static  class PlotExtensions
{
    public static int CalculatePerimeter(this Plot plot)
    {
        var locs = plot.Squares.Select(static s => s.Location).ToHashSet();
        return locs.SelectMany(loc =>
        {
            var surrounding = loc.Surrounding();
            return surrounding.Select(x => locs.Contains(x) ? 0 : 1);
        })
        .Sum();
    }

    public static long CountSides(this Plot plot)
    {
        var locs = plot.Squares.Select(static s => s.Location).ToHashSet();

        var vertices = plot.GetVertices();
        var cornerCount = vertices.Select(v =>
            {
                var ul = new Location(v.Row - 1, v.Column - 1);
                var haveUl = locs.Contains(ul) ? 1 : 0;

                var ur = new Location(v.Row - 1, v.Column);
                var haveUr = locs.Contains(ur) ? 1 : 0;

                var dl = new Location(v.Row, v.Column - 1);
                var haveDl = locs.Contains(dl) ? 1 : 0;

                var dr = new Location(v.Row, v.Column);
                var haveDr = locs.Contains(dr) ? 1 : 0;

                var count = haveUl + haveUr + haveDl + haveDr;

                if (count == 1 || count == 3)
                    return 1L;

                if (count == 2 && ((haveUl + haveDr) == 2 || (haveUr + haveDl) == 2))
                    return 2L;

                return 0L;
            })
        .Sum();

        // # sides = # corners
        return cornerCount;
    }

    private static List<Vertex> GetVertices(this Plot plot)
    {
        return plot.Squares
            .SelectMany(static x => x.Location.Vertices())
            .Distinct()
            .OrderBy(static x=> x.Row)
            .ThenBy(static x=> x.Column)
            .ToList();
    }
}