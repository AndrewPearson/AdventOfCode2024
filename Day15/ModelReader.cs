namespace Day15;

public static class ModelReader
{
    public static Model Load(string filePath)
    {
        using var reader = new StreamReader(File.OpenRead(filePath));

        var rows = new List<State[]>();
        var moves = new Queue<Move>();

        var inMap = true;
        while (reader.ReadLine() is { } line)
        {
            if (line.Length == 0)
            {
                inMap = false;
                continue;
            }

            if (inMap)
            {
                var row = ProcessRow(line);
                rows.Add(row);
            }
            else
            {
                var lineMoves = ReadMoves(line);
                foreach (var move in lineMoves)
                    moves.Enqueue(move);
            }
        }

        var map = new Map(rows);
        return new Model(map, moves);
    }

    private static State[] ProcessRow(string line)
    {
        return line
            .Select(static c => c.ToState())
            .ToArray();
    }

    private static IEnumerable<Move> ReadMoves(string line)
    {
        return line.Select(static c =>
        {
            return c switch
            {
                '<' => Move.Left,
                '>' => Move.Right,
                '^' => Move.Up,
                'v' => Move.Down,
                _ => throw new InvalidOperationException($"Unknown move '{c}'")
            };
        });
    }
}