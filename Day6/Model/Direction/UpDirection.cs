namespace Day6.Model.Direction;

public class UpDirection : IDirection
{
    public string Text => "^";

    public Position NextFrom(Position current)
    {
        return current with { Row = current.Row - 1 };
    }

    public IDirection Rotate() => new RightDirection();
}