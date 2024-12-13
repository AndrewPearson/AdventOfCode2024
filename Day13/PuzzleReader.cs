using System.Text.RegularExpressions;

namespace Day13;

public static class PuzzleReader
{
    private static readonly Regex ButtonRegex = new Regex(@"Button [AB]: X\+(\d+), Y\+(\d+)", RegexOptions.Compiled);
    private static readonly Regex PrizeRegex = new Regex(@"Prize: X=(\d+), Y=(\d+)", RegexOptions.Compiled);

    public static List<Puzzle> Load(string filePath)
    {
        using var reader = new StreamReader(File.OpenRead(filePath));

        var puzzles = new List<Puzzle>();
        do
        {
            var lineA = reader.ReadLine();
            var lineB = reader.ReadLine();
            var linePrize = reader.ReadLine();

            var puzzle = new Puzzle(
                ReadButton(lineA!),
                ReadButton(lineB!),
                ReadPrize(linePrize!));

            puzzles.Add(puzzle);
        } while (reader.ReadLine() is not null);

        return puzzles;
    }

    private static Button ReadButton(string line)
    {
        var m = ButtonRegex.Match(line);
        if (!m.Success)
            throw new InvalidOperationException();

        var dx = long.Parse(m.Groups[1].ToString());
        var dy = long.Parse(m.Groups[2].ToString());
        return new Button(dx, dy);
    }

    private static Prize ReadPrize(string line)
    {
        var m = PrizeRegex.Match(line);
        if (!m.Success)
            throw new InvalidOperationException();

        var x = long.Parse(m.Groups[1].ToString());
        var y = long.Parse(m.Groups[2].ToString());

        x += 10000000000000;
        y += 10000000000000;
        return new Prize(x, y);
    }
}