using Day13;

var filePath= "Data/input.txt";
var puzzles = PuzzleReader.Load(filePath);

var solutions = puzzles.Select(static p => (Puzzle: p, Solution: p.Solve())).ToList();

Console.WriteLine($"==== {solutions.Count} Puzzles, {solutions.Count(static s => s.Solution.IsValid)} solutions found ====");
foreach (var s in solutions)
{

    Console.WriteLine($"Button A: X+{s.Puzzle.A.Dx}, Y+{s.Puzzle.A.Dy}");
    Console.WriteLine($"Button B: X+{s.Puzzle.B.Dx}, Y+{s.Puzzle.B.Dy}");
    Console.WriteLine($"Prize: X={s.Puzzle.Prize.X}, Y={s.Puzzle.Prize.Y}");
    Console.WriteLine($"Press A {s.Solution.APresses} times, B {s.Solution.BPresses} times");
    Console.WriteLine($"Tokens: {s.Solution.Tokens}");
    Console.WriteLine();
}

var totalCost = solutions.Select(static s => s.Solution.Tokens).Sum();
Console.WriteLine($"Total Cost = {totalCost}");