using System.Text;

namespace Day14;

public class Model
{
    public Model(Map map, List<Robot> robots)
    {
        Map = map;
        Robots = robots;
    }

    public Map Map { get; }

    public List<Robot> Robots { get; }

    public void Tick()
    {
        foreach (var robot in Robots)
        {
            robot.Tick(Map);
        }
    }

    public List<(Location Location, int NumRobots)> RobotLocations()
    {
        return Robots.GroupBy(r => r.Location)
            .Select(x => (Location: x.Key, x.Count()))
            .ToList();
    }

    public List<(int Quadrant, int NumRobots)> RobotsByQuadrant()
    {
        var robots = RobotLocations();

        var byQuadrant = robots
            .Select(r => (Quadrant: Map.QuadrantFor(r.Location), r.NumRobots))
            .GroupBy(static x => x.Quadrant, static x => x.NumRobots)
            .Select(static x => (Quadrant: x.Key, NumRobots: x.Sum()))
            .OrderBy(static x => x.Quadrant)
            .ToList();
        return byQuadrant;
    }

    public override string ToString()
    {
        var robots = RobotLocations()
            .ToDictionary(static x => x.Location, static x=>x.NumRobots);

        var sb = new StringBuilder();
        for (int y = 0; y < Map.RowCount; ++y)
        {
            for (int x = 0; x < Map.ColCount; ++x)
            {
                var loc = new Location(x, y);
                var nRobots = robots.GetValueOrDefault(new Location(x, y), 0);
                var text = nRobots == 0 ? "." : $"{nRobots}";
                sb.Append(text);
            }
            sb.AppendLine();
        }
        return sb.ToString();
    }

    public int LargestContiguousRow()
    {
        var robots = RobotLocations().Select(x => x.Location).ToHashSet();

        int maxSoFar = 0;
        for (int y = 0; y < Map.RowCount; ++y)
        {
            int maxInRow = 0;
            var blockCount = 0;
            bool inBlock = false;
            for (int x = 0; x < Map.ColCount; ++x)
            {
                var loc = new Location(x, y);

                var isRobot = robots.Contains(loc);

                // enter block
                if (!inBlock && isRobot)
                {
                    inBlock = true;
                    blockCount += 1;
                }
                // in block
                else if (inBlock && isRobot)
                {
                    blockCount += 1;

                }
                // exit block
                else if (inBlock && !isRobot)
                {
                    if (blockCount > maxInRow)
                        maxInRow = blockCount;

                    blockCount = 0;
                    inBlock = false;
                }
                // not in block and empty - nothing to do
            }

            if (maxInRow > maxSoFar)
                maxSoFar = maxInRow;
        }

        return maxSoFar;
    }
}