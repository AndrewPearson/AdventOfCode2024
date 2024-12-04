namespace Day4;

public class GridReader
{
    public static Grid FromFile(string path)
    {
        using var r = new StreamReader(File.OpenRead(path));

        var lines = new List<string>();
        while (r.ReadLine() is { } line)
        {
            lines.Add(line);
        }

        return new Grid(lines);
    }
}