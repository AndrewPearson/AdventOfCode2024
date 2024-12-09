namespace Day9;

public class DiskMap
{
    public DiskMap(string data)
    {
        Data = data;
    }

    public string Data { get; }

    public override string ToString() => Data;
}