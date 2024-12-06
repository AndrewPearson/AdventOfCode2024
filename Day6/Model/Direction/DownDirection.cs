namespace Day6.Model.Direction;

public class DownDirection : IDirection
{
    public string Text => "v";

    public Position NextFrom(Position current)
    {
        return current with { Row = current.Row + 1 };
    }

    public IDirection Rotate() => new LeftDirection();
}