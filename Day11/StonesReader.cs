namespace Day11;

public static class StonesReader
{
    public static Stones Load(string filePath)
    {
        using var reader = new StreamReader(File.OpenRead(filePath));

        var line = reader.ReadLine();
        if (line is null)
            throw new InvalidOperationException();

        var stones = line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(static i => long.Parse(i))
                .Select(static l => new Stone(l, 1))
                .ToList();

        return new Stones(stones);
    }
}