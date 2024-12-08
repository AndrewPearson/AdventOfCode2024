using Day8;

var filePath = "Data/input.txt";

var grid = DataReader.ReadEquations(filePath);

var antinodes = AntiNode.Find(grid);

Console.WriteLine("==== AntiNodes ====");
foreach (var antinode in antinodes)
{
    Console.WriteLine(antinode);
}
Console.WriteLine();

Console.WriteLine($"# anti-nodes = {antinodes.Count}");