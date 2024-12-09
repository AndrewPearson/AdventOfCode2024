using System.Text;

namespace Day9;

public class BlockMap
{
    public BlockMap(Block[] blocks)
    {
        Blocks = blocks;
    }

    public Block[] Blocks { get; }

    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach (var block in Blocks)
        {
            sb.Append(block);
        }

        return sb.ToString();
    }
}