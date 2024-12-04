namespace Day1;

public static class DataReader
{
    public static (List<long> First, List<long> Second) Read(string path)
    {
        using var r = new StreamReader(File.OpenRead(path));

        var f = new List<long>();
        var s = new List<long>();

        while (r.ReadLine() is { } line)
        {
            var nums = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            f.Add(int.Parse(nums[0]));
            s.Add(int.Parse(nums[1]));
        }

        return (f, s);
    }
}