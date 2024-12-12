namespace Day12;

public static class MapReader
{
    public static Map Load(string filePath)
    {
        using var reader = new StreamReader(File.OpenRead(filePath));

        var rows = new List<string>();
        while (reader.ReadLine() is { } line)
        {
            rows.Add(line);
        }

        return new Map(rows);
    }
}