namespace Day8;

public static class AntiNode
{
    public static List<Position> Find(Grid grid)
    {
        var antennae = grid.Antennae;

        var byName = antennae
            .GroupBy(static a => a.Name)
            .ToDictionary(static x => x.Key, static x => x.ToList());

        var antinodes = byName.Values
            .SelectMany(g => CheckGroup(g, grid))
            .Distinct()
            .ToList();

        return antinodes;
    }

    private static IEnumerable<Position> CheckGroup(List<Antenna> antennae, Grid grid)
    {
        for (int i = 0; i < antennae.Count; ++i)
        {
            for (var j = i+1; j < antennae.Count; j++)
            {
                var first = antennae[i];
                var second = antennae[j];

                var dr = second.Position.Row - first.Position.Row;
                var dc = second.Position.Column - first.Position.Column;

                // up line
                bool onGrid;
                var n = first.Position;
                do
                {
                    onGrid = grid.Contains(n);
                    if (onGrid)
                        yield return n;

                    n = new Position(n.Row - dr, n.Column - dc);
                } while (onGrid);

                // down line
                n = second.Position;
                do
                {
                    onGrid = grid.Contains(n);
                    if (onGrid)
                        yield return n;

                    n = new Position(n.Row + dr, n.Column + dc);
                } while (onGrid);
            }
        }
    }
}