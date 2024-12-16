namespace Day15;

public record Location(int Row, int Col);

public static class LocationExtensions
{
    public static Location WithMove(this Location loc, Move move)
    {
        return move switch
        {
            Move.Up => loc with { Row = loc.Row - 1 },
            Move.Down => loc with { Row = loc.Row + 1 },
            Move.Left => loc with { Col = loc.Col - 1 },
            Move.Right => loc with { Col = loc.Col + 1 },
            _ => throw new ArgumentOutOfRangeException(nameof(move), move, null)
        };
    }

}