// See https://aka.ms/new-console-template for more information

using Day4;

var path = "input.txt";

var grid = GridReader.FromFile(path);
Console.WriteLine("==== GRID ====");
Console.WriteLine();
Console.Write(grid);
Console.WriteLine();

var xmases = XmasFinder.Check(grid);
Console.WriteLine("==== XMAS LOCATIONS ====");
foreach (var xmas in xmases)
{
    Console.WriteLine(xmas);
}
Console.WriteLine();
Console.WriteLine($"Found {xmases.Count} XMAS's");

var crossmases = CrossMasFinder.Check(grid);
Console.WriteLine();
Console.WriteLine("==== X-MAS LOCATIONS ====");
foreach (var xmas in crossmases)
{
    Console.WriteLine(xmas);
}
Console.WriteLine();
Console.WriteLine($"Found {crossmases.Count} X-MAS's");
