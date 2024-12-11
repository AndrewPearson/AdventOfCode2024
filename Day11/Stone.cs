namespace Day11;

public class Stone
{
    public Stone(long value, long multiplier)
    {
        Value = value;
        Multiplier = multiplier;
    }

    public long Value { get; }

    public long Multiplier { get; private set; }

    public override string ToString()
    {
        return $"({Multiplier}*{Value})";
    }

    public IEnumerable<Stone> Blink()
    {
        // RULE 1 - O replaced by 1
        if (Value == 0)
        {
            yield return new Stone(1L, Multiplier);
            yield break;
        }

        // RULE 2 - split even # digits into two stones
        var valueText = $"{Value}";
        if (valueText.Length % 2 == 0)
        {
            var halfLen = valueText.Length / 2;

            var s1 = valueText.Substring(0, halfLen);
            var v1 = long.Parse(s1);
            yield return new Stone(v1, Multiplier);

            var s2 = valueText.Substring(halfLen, halfLen);
            var v2 = long.Parse(s2);
            yield return new Stone(v2, Multiplier);

            yield break;
        }

        // RULE 3 - multiply value by 2024
        yield return new Stone(Value * 2024L, Multiplier);
    }

    public void AddToMultiplier(long additional) => Multiplier += additional;

}