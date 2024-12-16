using System.Text;

namespace Day15;

public class Map
{
    private readonly List<State[]> _rows;

    public Map(List<State[]> rows)
    {
        _rows = rows;
    }

    private State this[Location loc]
    {
        get => _rows[loc.Row][loc.Col];
        set => _rows[loc.Row][loc.Col] = value;
    }

    private bool Contains(Location loc)
    {
        return loc.Row >= 0
               && loc.Row < _rows.Count
               && loc.Col >= 0
               && loc.Col < _rows[0].Length;
    }

    public Location Robot()
    {
        for (var r = 0; r < _rows.Count; r++)
        {
            var row = _rows[r];
            for (var c = 0; c < row.Length; c++)
            {
                if (row[c] == State.Robot)
                    return new Location(r, c);
            }
        }

        throw new InvalidOperationException("Could not find the robot on the map.");
    }

    public List<Location> Boxes()
    {
        var boxes = new List<Location>();
        for (var r = 0; r < _rows.Count; r++)
        {
            var row = _rows[r];
            for (var c = 0; c < row.Length; c++)
            {
                if (row[c] == State.Box)
                    boxes.Add(new Location(r, c));
            }
        }

        return boxes;
    }

    public void MoveRobot(Move move)
    {
        var robot = Robot();

        var boxes = new Stack<Location>();

        var next = robot.WithMove(move);
        while (Contains(next) && this[next] == State.Box)
        {
            boxes.Push(next);
            next = next.WithMove(move);
        }

        if (Contains(next) && this[next] == State.Empty)
        {
            // move boxes
            while (boxes.TryPop(out var box))
            {
                var newLoc = box.WithMove(move);
                this[newLoc] = this[box];
                this[box] = State.Empty;
            }

            // move robot
            var newRobot = robot.WithMove(move);
            this[newRobot] = this[robot];
            this[robot] = State.Empty;
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        for (var i = 0; i < _rows.Count; i++)
        {
            foreach (var cell in _rows[i])
                sb.Append(cell.ToChar());

            if (i != _rows.Count - 1)
                sb.AppendLine();
        }

        return sb.ToString();
    }
}