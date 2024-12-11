using Day11;

var filePath = "Data/input.txt";

var stones = StonesReader.Load(filePath);

const int nBlinks = 75;

Console.WriteLine("==== Stones ====");
Console.WriteLine(stones);

for (int i = 0; i < nBlinks; ++i)
{
    stones.Blink();
    // Console.WriteLine($"BLINK - {stones}");
}
Console.WriteLine();

Console.WriteLine($"# Stones after {nBlinks} blinks = {stones.Count}");