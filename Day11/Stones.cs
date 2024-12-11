using System.Text;

namespace Day11;

public class Stones
{
    private List<Stone> _stones;

    public Stones(List<Stone> stones)
    {
        _stones = stones;
    }

    public void Blink()
    {
        var stoneMap = new Dictionary<long, Stone>();

        foreach (var stone in _stones)
        {
            var blinked = stone.Blink();
            foreach (var blinkStone in blinked)
            {
                if (!stoneMap.TryAdd(blinkStone.Value, blinkStone))
                {
                    stoneMap[blinkStone.Value].AddToMultiplier(blinkStone.Multiplier);
                }
            }
        }

        _stones = stoneMap.Values.ToList();

        // var blinkedStones = _stones
        //     .SelectMany(static s => s.Blink())
        //     .ToList();
        // _stones = blinkedStones;
    }

    public long Count => _stones.Sum(static s => s.Multiplier);

    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach (var stone in _stones)
        {
            sb.Append(stone).Append(' ');
        }
        return sb.ToString();
    }
}