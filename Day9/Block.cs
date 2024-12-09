namespace Day9;

public record Block(int Id)
{
    public bool IsEmpty() => Id < 0;

    public override string ToString()
    {
        return Id < 0 ? "." : $"{Id}";
    }

    public static Block Empty() => new Block(-1);
}