var path = "input.txt";

var reports = ReadReports(path);
var safes = reports.Select(static r => (Report: r, IsSafe: IsReportSafe(r))).ToList();
var countSafe = safes.Sum(static x => x.IsSafe ? 1 : 0);
Console.WriteLine($"Total Safe = {countSafe}");

static bool IsReportSafe(List<int> levels)
{
    var index = TestReport(levels);
    if (index == levels.Count)
        return true;

    if (TrySkip(levels, index))
        return true;

    if (TrySkip(levels, index + 1))
        return true;

    // if failed at index 1, also need to test if works with first element removed.
    return index == 1 && TrySkip(levels, 0);

}

static bool TrySkip(List<int> levels, int skipIndex)
{
    var skipList = levels.Where((_, i) => i != skipIndex).ToList();
    return TestReport(skipList) == skipList.Count;
}

static int TestReport(List<int> levels)
{
    var size = levels.Count;
    if (size <= 1)
        throw new InvalidOperationException("Must have at least two levels");

    var initDir = GetDirection(levels[0], levels[1]);
    // not safe if any change is flat
    if (initDir == Direction.Same)
        return 0;

    for (int i = 0; i < size - 1; ++i)
    {
        var f = levels[i];
        var s = levels[i + 1];
        var dir = GetDirection(f, s);
        if (initDir != dir || !IsChangeSafe(f, s))
            return i;
    }

    return levels.Count;
}

static IEnumerable<List<int>> ReadReports(string path)
{
    using var r = new StreamReader(File.OpenRead(path));
    while (r.ReadLine() is { } line)
    {
        var nums = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        yield return nums.Select(static x => int.Parse(x)).ToList();
    }
}

static Direction GetDirection(int first, int second)
{
    long del = second - first;
    var dir = del > 0
        ? Direction.Up
        : del == 0
            ? Direction.Same
            : Direction.Down;
    return dir;
}

static bool IsChangeSafe(int first, int second)
{
    long del = Math.Abs(second - first);
    return del is >= 1 and <= 3;
}

enum Direction
{
    Same = 0,
    Up = 1,
    Down = -1,
}
