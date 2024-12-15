using System.Text.RegularExpressions;

namespace Day14;

public static class DataReader
{
    public static Model Load(string filePath)
    {
        using var reader = new StreamReader(File.OpenRead(filePath));

        var robots = new List<Robot>();
        while (reader.ReadLine() is { } line)
        {
            var robot = ReadRobot(line);
            robots.Add(robot);
        }

        int nrows = 103;
        int ncols = 101;
        if (filePath.Contains("test"))
        {
            nrows = 7;
            ncols = 11;
        }
        var map = new Map(nrows, ncols);

        return new Model(map, robots);
    }

    private static readonly Regex RobotRegex = new(@"p\=(-?\d+),(-?\d+)\s+v\=(-?\d+),(-?\d+)", RegexOptions.Compiled);
    private static Robot ReadRobot(string line)
    {
        var m = RobotRegex.Match(line);
        if (!m.Success)
            throw new InvalidOperationException($"Could not read robot config, '{line}'");

        var position = new Location(
            int.Parse(m.Groups[1].ToString()),
            int.Parse(m.Groups[2].ToString()));

        var velocity = new Velocity(
            int.Parse(m.Groups[3].ToString()),
            int.Parse(m.Groups[4].ToString()));

        return new Robot(position, velocity);
    }
}