using Day15;

var filePath = "Data/input.txt";

var model = ModelReader.Load(filePath);
Console.WriteLine("==== Initial State ====");
Console.WriteLine(model.Map);
Console.WriteLine();
Console.WriteLine($"Moves: {string.Join(',', model.Moves)}");
Console.WriteLine();
Console.WriteLine($"Robot: {model.Map.Robot}");

Console.WriteLine("==== Moves ====");
for(int moveId = 1; model.ApplyNextMove(); ++moveId)
{
    // Console.WriteLine($"==== After Move {moveId} ====");
    // Console.WriteLine(model.Map);
    // Console.WriteLine();
}

var score = model.SumCoordinates();
Console.WriteLine($"Sum Of Box Coordinates = {score}");