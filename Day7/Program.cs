using Day7;

var filePath = "Data/input.txt";

var equations = DataReader.ReadEquations(filePath);

var results = equations
    .Select(static e => (Equation: e, Solution: Solution.Find(e)))
    .ToList();

var solved = results
    .Where(static r => r.Solution is not null)
    .ToList();

var totalSolved = solved
    .Select(static x => x.Equation.Value)
    .Sum();

Console.WriteLine("==== Results ====");
foreach (var ((value, inputs), solution) in results)
{
    Console.Write($"{value}: {string.Join(',', inputs)} - ");
    Console.WriteLine(solution is null ? "solution not found" : string.Join(',', solution));
}
Console.WriteLine();

Console.WriteLine($"Total Equations = {results.Count}");
Console.WriteLine($"Num Solved = {solved.Count}");
Console.WriteLine($"Sum of Solved Equations = {totalSolved}");