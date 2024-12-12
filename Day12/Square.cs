namespace Day12;

public record Square(Location Location, char Type)
{
    public bool InPlot { get; set; } = false;
}