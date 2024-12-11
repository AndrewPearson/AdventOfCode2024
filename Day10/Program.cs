using Day10;

var filePath = "Data/input.txt";

var map = MapReader.Load(filePath);
Console.WriteLine("==== Map ====");
Console.Out.PrintMap(map);

var trails = map.FindTrails();

// Console.WriteLine("==== Trails ====");
// foreach (var trail in trails)
// {
//     Console.Out.PrintTrail(map, trail);
//     // Console.WriteLine($"Start: {trail.Start}, Head: {trail.Head}");
// }

var trailHeadScores = trails
    .Select(static t => (Head: t.Head, End: t.End))
    .Distinct()
    .GroupBy(static t => t.Head)
    .ToDictionary(static x => x.Key, static x => x.Count());

Console.WriteLine("==== Trail Head Scores ====");
foreach (var (location, count) in trailHeadScores)
{
    Console.WriteLine($"{location}: score = {count}");
}
Console.WriteLine();

var totalScore = trailHeadScores.Sum(static x => x.Value);
Console.WriteLine($"Total Score = {totalScore}");

var trailHeadRatings = trails
    .GroupBy(static t => t.Head)
    .ToDictionary(static x => x.Key, static x => x.Count());

Console.WriteLine("==== Trail Head Ratings ====");
foreach (var (location, count) in trailHeadRatings)
{
    Console.WriteLine($"{location}: rating = {count}");
}
Console.WriteLine();

var totalRating = trailHeadRatings.Sum(static x => x.Value);
Console.WriteLine($"Total Rating = {totalRating}");
