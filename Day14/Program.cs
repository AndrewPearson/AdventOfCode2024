using Day14;

var filePath = "Data/input.txt";
const int nTicks = 7339;

var model = DataReader.Load(filePath);

// Console.Out.WriteLine(model);
// Console.WriteLine();

for (int i = 1; i <= nTicks; ++i)
{
    model.Tick();
    // Console.WriteLine($"After {i} seconds");
    // Console.Out.WriteLine(model);
    // Console.WriteLine();
    // Console.ReadLine();
}
Console.WriteLine($"After {nTicks} seconds");
Console.Out.WriteLine(model);
Console.WriteLine();

var robotCounts = model.RobotsByQuadrant();

Console.WriteLine("==== Quadrants ====");
foreach (var (quadrant, numRobots) in robotCounts)
{
    Console.WriteLine($"Quadrant ID:{quadrant}, NumRobots={numRobots}");
}
Console.WriteLine();

var score = robotCounts
    .Where(static x => x.Quadrant >= 0) // ignore robots out of quadrants
    .Aggregate(1L, static (sum, x) => sum * x.NumRobots);
Console.WriteLine($"Score = {score}");