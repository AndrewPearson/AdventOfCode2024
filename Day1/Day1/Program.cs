using Day1;

var path = "input.txt";

var (first, second) = DataReader.Read(path);
Console.WriteLine($"{first.Count} rows read from '{path}'");

var dist = CalculateDistance(first, second);
Console.WriteLine($"Total Distance = {dist}");

var similarity = CalculateSimilarity(first, second);
Console.WriteLine($"Total Similarity = {similarity}");

static long CalculateDistance(List<long> first, List<long> second)
{
    return first.Order().Zip(second.Order())
        .Sum(static item => Math.Abs(item.First-item.Second));
}

static long CalculateSimilarity(List<long> first, List<long> second)
{
    var secondFreq = second
        .CountBy(static x => x)
        .ToDictionary(static x => x.Key, static x => x.Value);

    return first
        .Select(f => f * secondFreq.GetValueOrDefault(f, 0))
        .Sum(static x => x);
}