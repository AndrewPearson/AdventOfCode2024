namespace Day12;

public record Location(int Row, int Column);

public static class LocationExtensions
{
    public static Location[] Surrounding(this Location loc)
    {
        return
        [
            loc with { Row = loc.Row - 1 },
            loc with { Row = loc.Row + 1 },
            loc with { Column = loc.Column - 1 },
            loc with { Column = loc.Column + 1 }
        ];
    }

    public static Vertex[] Vertices(this Location location)
    {
        return
        [
            new Vertex(location.Row, location.Column),
            new Vertex(location.Row, location.Column + 1),
            new Vertex(location.Row + 1, location.Column),
            new Vertex(location.Row + 1, location.Column + 1)
        ];
    }
}

public record Vertex(int Row, int Column);