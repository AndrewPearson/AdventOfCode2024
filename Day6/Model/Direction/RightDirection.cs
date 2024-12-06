namespace Day6.Model.Direction;

public class RightDirection : IDirection
{
    public string Text => ">";

    public Position NextFrom(Position current)
    {
        return current with { Column = current.Column + 1 };
    }

    public IDirection Rotate() => new DownDirection();
}