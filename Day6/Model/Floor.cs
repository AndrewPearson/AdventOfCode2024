namespace Day6.Model;

public enum Floor
{
    Empty,
    Obstacle,
    Obstruction
}

public static class FloorExtensions
{
    public static bool IsFree(this Floor floor)
    {
        return floor == Floor.Empty;
    }

    public static bool IsBlocked(this Floor floor)
    {
        return floor != Floor.Empty;
    }
}