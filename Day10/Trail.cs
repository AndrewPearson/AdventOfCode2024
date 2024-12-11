namespace Day10;

public class Trail
{
    private readonly List<Location> _path;

    public Trail(List<Location> path)
    {
        _path = path;
    }

    public IReadOnlyList<Location> Path => _path;

    public Location Head => _path[0];
    public Location End => _path[^1];

    public override string ToString()
    {
        return $"Head: {Head}, End: {End}";
    }
}