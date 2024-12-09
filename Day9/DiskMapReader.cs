namespace Day9;

public static class DiskMapReader
{
    public static DiskMap Load(string filePath)
    {
        using var reader = new StreamReader(File.OpenRead(filePath));
        var line = reader.ReadLine();
        return new DiskMap(line!);
    }
}