namespace Day10;

public static class MapReader
{
    public static Map Load(string filePath)
    {
        using var reader = new StreamReader(File.OpenRead(filePath));

        var rows = new List<int[]>();
        while (reader.ReadLine() is { } line)
        {
            var row = line.Select(static x => (int)(x - '0')).ToArray();

            rows.Add(row);
        }

        return new Map(rows);
    }
}