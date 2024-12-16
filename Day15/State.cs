namespace Day15;

public enum State
{
    Empty,
    Box,
    Wall,
    Robot
}

public static class StateExtensions
{
    public static char ToChar(this State state)
    {
        return state switch
        {
            State.Empty => '.',
            State.Box => 'O',
            State.Wall => '#',
            State.Robot => '@',
            _ => throw new InvalidOperationException($"Unknown state '{state}'")
        };
    }

    public static State ToState(this char c)
    {
        return c switch
        {
            '.' => State.Empty,
            '@' => State.Robot,
            '#' => State.Wall,
            'O' => State.Box,
            _ => throw new InvalidOperationException($"Unknown cell state '{c}'")
        };
    }
}