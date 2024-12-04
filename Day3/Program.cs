using System.Text.RegularExpressions;

var path = "input.txt";

var lines = ReadFile(path);

var regex = new Regex(@"(mul)\((\d{1,3}),(\d{1,3})\)|(do)\(\)|(don't)\(\)", RegexOptions.Compiled);

bool active = true;
var muls = lines.Select(line => ReadLine(line, ref active)).ToList();
var sum = muls.SelectMany(static x => x) .Sum(static mul => mul.X*mul.Y);

foreach (var line in muls)
{
    foreach (var mul in line)
    {
        Console.WriteLine($"mul({mul.X},{mul.Y}) = {mul.X*mul.Y}");
    }

    Console.WriteLine("<< NEW LINE >>");
    Console.WriteLine();
}
Console.WriteLine($"Sum = {sum}");

static IEnumerable<string> ReadFile(string path)
{
    using var r = new StreamReader(File.OpenRead(path));

    while (r.ReadLine() is { } line)
        yield return line;
}

IEnumerable<Mul> ReadLine(string line, ref bool active)
{
    var lineMuls = new List<Mul>();
    foreach (Match m in regex.Matches(line))
    {
        if (m.Groups[1].ToString() == "mul")
        {
            var x = long.Parse(m.Groups[2].ToString());
            var y = long.Parse(m.Groups[3].ToString());
            if (active)
                lineMuls.Add(new Mul(x, y));
        }
        else if (m.Groups[4].ToString() == "do")
        {
            active = true;
        }
        else if (m.Groups[5].ToString() == "don't")
        {
            active = false;
        }
    }

    return lineMuls;
}

record Mul(long X, long Y);
