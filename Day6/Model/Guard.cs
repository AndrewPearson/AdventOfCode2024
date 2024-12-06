using Day6.Model.Direction;

namespace Day6.Model;

public class Guard
{
    private readonly Map _map;
    private IDirection _direction;

    private readonly Position _startPosition;
    private readonly IDirection _startDirection;

    public Guard(Map map, int row, int col, IDirection direction)
    {
        _map = map;
        Position = new Position(row, col);
        _direction = direction;

        _startPosition = Position;
        _startDirection = direction;
    }

    public Position Position { get; private set; }

    public PositionAndDirection PositionAndDirection => new(Position, _direction.Text);

    public bool Move()
    {
        var next = _direction.NextFrom(Position);
        if (!_map.OnMap(next))
            return false;

        while (_map.At(next).IsBlocked())
        {
            _direction = _direction.Rotate();
            next = _direction.NextFrom(Position);
        }

        Position = next;
        return _map.OnMap(next);
    }

    public override string ToString()
    {
        return $"Row: {Position.Row}, Column: {Position.Column}, Direction: {_direction.Text}";
    }

    public void Reset()
    {
        Position = _startPosition;
        _direction = _startDirection;
    }
}