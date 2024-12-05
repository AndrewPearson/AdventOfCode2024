using System.Reflection.Metadata.Ecma335;
using Day5;

var path = "input.txt";

var (rules, updates) = DataReader.FromFile(path);
Console.WriteLine($"{rules.Count} rules, {updates.Count} updates");
Console.WriteLine();

var groupByPass = updates
    .GroupBy(u => rules.TrueForAll(rule => rule.Check(u)), static u => u)
    .ToDictionary(static x=> x.Key, static x => x.AsEnumerable().ToList());

var passed = groupByPass[true];
var failed = groupByPass[false];


Console.WriteLine($"==== {passed.Count} Updates Pass Rules ====");
foreach (var update in passed)
{
    Console.WriteLine(update);
}
Console.WriteLine();

var sumMid = passed.Select(static u => u.MidPage).Sum();
Console.WriteLine($"Sum Of Mid Pages = {sumMid}");

var resolved = failed.Select(u => Fix(u, rules)).ToList();
Console.WriteLine($"==== {passed.Count} Fixed Updates ====");
foreach (var update in resolved)
{
    Console.WriteLine(update);
}
Console.WriteLine();

var sumMidFixed = resolved.Select(static u => u.MidPage).Sum();
Console.WriteLine($"Sum Of Mid Pages In Fixed = {sumMidFixed}");



static Update Fix(Update update, List<Rule> rules)
{
    var fixing = update;

    while (!rules.TrueForAll(r => r.Check(fixing)))
    {
        foreach (var rule in rules)
        {
            fixing = rule.Fix(fixing);
        }
    }

    return fixing;
}