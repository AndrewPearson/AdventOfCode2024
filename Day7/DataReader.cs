namespace Day7;

public static class DataReader
{
    public static List<Equation> ReadEquations(string filePath)
    {
        using var reader = new StreamReader(File.OpenRead(filePath));

        var equations = new List<Equation>();
        while (reader.ReadLine() is { } line)
        {
            var data = line.Split([':', ' '], StringSplitOptions.RemoveEmptyEntries)
                .Select(static x => long.Parse(x))
                .ToArray();

            var value = data[0];
            var inputs = data[1..];
            var equation = new Equation(value, inputs);
            equations.Add(equation);
        }

        return equations;
    }
}