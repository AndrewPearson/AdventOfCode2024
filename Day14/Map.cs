namespace Day14;

public class Map
{
    public Map(int rowCount, int colCount)
    {
        RowCount = rowCount;
        ColCount = colCount;
    }

    public int RowCount { get; }

    public int ColCount { get; }

    // -1 if not in a quadrant
    // 0 for top left
    // 1 for top right
    // 2 for bottom left
    // 3 for bottom right
    public int QuadrantFor(Location loc)
    {
        var midX = ColCount / 2;
        var midY = RowCount / 2;

        if (loc.X < 0 || loc.X > ColCount || loc.X == midX)
            return -1;
        if (loc.Y < 0 || loc.Y > RowCount || loc.Y == midY)
            return -1;

        int qx = loc.X < midX ? 0 : 1;
        int qy = loc.Y < midY ? 0 : 1;

        return qx + 2 * qy;
    }
}