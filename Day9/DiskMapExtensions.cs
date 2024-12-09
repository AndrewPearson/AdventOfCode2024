namespace Day9;

public static class DiskMapExtensions
{
    public static BlockMap ToBlockMap(this DiskMap diskMap)
    {
        var isBlock = true;
        var currentId = 0;
        var blocks = diskMap.Data.SelectMany(c =>
        {
            int val = c - '0';
            int blockId = isBlock ? currentId++ : -1;

            isBlock = !isBlock;
            return Enumerable.Repeat(0, val)
                .Select(_ => new Block(blockId));
        })
        .ToArray();

        return new BlockMap(blocks);
    }
}