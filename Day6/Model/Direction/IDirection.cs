namespace Day6.Model.Direction;

public interface IDirection
{
    string Text { get; }

    Position NextFrom(Position current);

    IDirection Rotate();
}