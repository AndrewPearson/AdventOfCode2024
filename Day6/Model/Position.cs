namespace Day6.Model;

public record Position(int Row, int Column);

public record PositionAndDirection(Position Position, string Direction);
