namespace Day5;

public static class DataReader
{
    public static (List<Rule> Rules, List<Update> Updates) FromFile(string path)
    {
        using var r = new StreamReader(File.OpenRead(path));

        var rules = new List<Rule>();
        var updates = new List<Update>();

        bool inRules = true;
        while (r.ReadLine() is { } line)
        {
            if (string.IsNullOrEmpty(line))
            {
                inRules = false;
                continue;
            }

            if (inRules)
            {
                var rule = ReadRule(line);
                rules.Add(rule);
            }
            else
            {
                var update = ReadUpdate(line);
                updates.Add(update);
            }
        }

        return (rules, updates);
    }

    private static Update ReadUpdate(string line)
    {
        var split = line.Split(",", StringSplitOptions.RemoveEmptyEntries);
        var pages = split.Select(static x => int.Parse(x)).ToArray();
        return new Update(pages);
    }

    private static Rule ReadRule(string line)
    {
        var split = line.Split("|", StringSplitOptions.RemoveEmptyEntries);
        var first = int.Parse(split[0]);
        var second = int.Parse(split[1]);
        return new Rule(first, second);
    }
}