namespace Day9;

public static class BlockMapExtensions
{
    public static BlockMap Defrag1(this BlockMap original)
    {
        var newBlocks = (Block[])original.Blocks.Clone();

        int iEmpty = FindFirstEmpty(newBlocks, 0);
        int iLast = FindLastData(newBlocks, newBlocks.Length - 1);
        while (iEmpty < iLast)
        {
            // swap items
            newBlocks[iEmpty] = newBlocks[iLast];
            newBlocks[iLast] = Block.Empty();

            iEmpty = FindFirstEmpty(newBlocks, iEmpty + 1);
            iLast = FindLastData(newBlocks, iLast - 1);
        }

        return new BlockMap(newBlocks);
    }

    private static int FindFirstEmpty(Block[] data, int from)
    {
        for (int i = from; i < data.Length; ++i)
        {
            if (data[i].IsEmpty())
                return i;
        }

        return data.Length;
    }

    private static int FindLastData(Block[] data, int from)
    {
        for (int i = from; i >= 0; i--)
        {
            if (!data[i].IsEmpty())
                return i;
        }

        return -1;
    }

    public static long CheckSum(this BlockMap blockMap)
    {
        var sums = blockMap.Blocks
            .Select(static (b, i) => (long)i * (b.Id < 0 ? 0 : b.Id))
            .ToArray();
        var checkSum = sums.Sum();
        return checkSum;
    }


    public static BlockMap Defrag2(this BlockMap original)
    {
        var newBlocks = (Block[])original.Blocks.Clone();

        var file = FindLastFile(original.Blocks, original.Blocks.Length - 1);
        while (file != null)
        {
            // move file
            var destination = FindFreeSpace(newBlocks, 0, file.Value.Length);
            if (destination != null && destination < file.Value.Start)
            {
                for (int i = 0; i < file.Value.Length; i++)
                {
                    newBlocks[destination.Value + i] = newBlocks[file.Value.Start + i];
                    newBlocks[file.Value.Start + i] = Block.Empty();
                }
            }

            // find next file
            file = FindLastFile(original.Blocks, file.Value.Start - 1);
        }

        return new BlockMap(newBlocks);
    }

    private static (int Start, int Length)? FindLastFile(Block[] blocks, int from)
    {
        if (from < 0)
            return null;

        int end = from;
        // find first non-empty block
        while (end >= 0 && blocks[end].IsEmpty())
            end--;

        int start = end - 1;
        while (start >= 0 && blocks[start].Id == blocks[end].Id)
            start--;

        var length = end - start;
        return (start + 1, length);
    }

    private static int? FindFreeSpace(Block[] blocks, int from, int length)
    {
        int index = from;

        do
        {
            // find first free spot
            while (index < blocks.Length - length && !blocks[index].IsEmpty())
                index++;

            if (blocks[index..(index + length)].All(static b => b.IsEmpty()))
                return index;

            // if here then there is data inside this 'space'
            // move to first non-space
            while (index < blocks.Length - length && blocks[index].IsEmpty())
                index++;

        } while (index < blocks.Length - length);

        return null;
    }
}