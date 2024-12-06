using Day6;
using Day6.Model;

var filePath = "Data/input.txt";

var (guard, map) = MapReader.FromFile(filePath);

var route = new List<PositionAndDirection> { guard.PositionAndDirection };

while (guard.Move())
{
    route.Add(guard.PositionAndDirection);
}

Console.WriteLine("==== PATH ====");
foreach (var position in route)
{
    Console.WriteLine(position);
}

Console.WriteLine();

var distinctRoutePositions = route.Select(static x => x.Position).Distinct().ToList();
Console.WriteLine($"Locations patrolled = {distinctRoutePositions.Count()}");

// Now test for circular routes, only need to check points in the original route
var loopObstaclePositions = new List<Position>();
foreach (var obstaclePosition in distinctRoutePositions)
{
    guard.Reset();
    // var obstaclePosition = new Position(row, col);
    if (guard.Position == obstaclePosition)
        continue; // don't put obstacle where guard starts
    if (map.At(obstaclePosition).IsBlocked())
        continue; // already blocked, can't add obstacle

    map.SetAt(obstaclePosition, Floor.Obstacle);

    var loopPath = new HashSet<PositionAndDirection> { guard.PositionAndDirection };
    bool foundLoop = false;
    while (!foundLoop && guard.Move())
    {
        if (loopPath.Contains(guard.PositionAndDirection))
        {
            // if here then we are repeating a section of the path, i.e. we're in a loop
            foundLoop = true;
            loopObstaclePositions.Add(obstaclePosition);
        }

        loopPath.Add(guard.PositionAndDirection);
    }

    // reset Map to original state
    map.SetAt(obstaclePosition, Floor.Empty);
}

Console.WriteLine("==== Obstacle Positions causing guard to Loop ====");
foreach (var loopObstaclePosition in loopObstaclePositions)
{
    Console.WriteLine(loopObstaclePosition);
}

Console.WriteLine($"Number of valid obstacle positions = {loopObstaclePositions.Count}");