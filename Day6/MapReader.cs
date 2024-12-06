using Day6.Model;
using Day6.Model.Direction;

namespace Day6;

public static class MapReader
{
    public static (Guard Guard, Map Map) FromFile(string path)
    {
        using var r = new StreamReader(File.OpenRead(path));

        var map = new Map();
        Guard? guard = null;
        while (r.ReadLine() is { } line)
        {
            var parsed = line
                .Select((c, col) => Read(c, col, map))
                .ToList();

            guard ??= parsed
                .Select(static x => x.Guard)
                .FirstOrDefault(static g => g is not null);

            map.AddRow(parsed.Select(static r => r.Floor).ToArray());
        }

        if (guard is null)
            throw new InvalidOperationException();

        return (guard, map);
    }

    private static (Floor Floor, Guard? Guard) Read(char c, int col, Map map)
    {
        var floor = c switch
        {
            '.' or '^' or 'v' or '<' or '>' => Floor.Empty,
            '#' => Floor.Obstacle,
            _ => throw new InvalidOperationException()
        };

        var direction = ReadDirection(c);
        Guard? guard = null;
        if (direction is not null)
            guard = new Guard(map, map.RowCount, col, direction);

        return (floor, guard);
    }

    private static IDirection? ReadDirection(char c)
    {
        IDirection? dir =  c switch
        {
            '^' => new UpDirection(),
            'v' => new DownDirection(),
            '<' => new LeftDirection(),
            '>' => new RightDirection(),
            _ => null
        };

        return dir;
    }
}