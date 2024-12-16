namespace Day15;

public class Model
{
    public Model(Map map, Queue<Move> moves)
    {
        Map = map;
        Moves = moves;
    }

    public Map Map { get; }

    public Queue<Move> Moves { get; }

    public bool ApplyNextMove()
    {
        var ok = Moves.TryDequeue(out var nextMove);
        Map.MoveRobot(nextMove);
        return ok;
    }

    public object SumCoordinates()
    {
        var boxes = Map.Boxes();
        var coords = boxes
            .Select(static b => b.Row * 100 + b.Col);

        return coords.Sum();
    }
}