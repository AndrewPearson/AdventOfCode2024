﻿using Day12;

var filePath = "Data/input.txt";

var map = MapReader.Load(filePath);
Console.WriteLine("==== Map ====");
Console.Out.PrintMap(map);

var plots = map.FindPlots();

Console.WriteLine("==== Plots ====");
// foreach (var plot in plots)
// {
//     Console.Out.PrintPlot(map, plot);
// }
Console.WriteLine();

Console.WriteLine("==== Plot Prices ====");
foreach (var plot in plots)
{
    Console.WriteLine($"A region of {plot.Type} plants with price {plot.Area}*{plot.Perimeter} = {plot.Area*plot.Perimeter}.");
}
Console.WriteLine();

var totalPrice = plots.Sum(static x => x.Area*x.Perimeter);
Console.WriteLine($"Total Price = {totalPrice}");
Console.WriteLine();


Console.WriteLine("==== Discount Plot Prices ====");
foreach (var plot in plots)
{
    Console.WriteLine($"A region of {plot.Type} plants with discount price {plot.Area}*{plot.Sides} = {plot.Area*plot.Sides}.");
}
Console.WriteLine();

var discountTotalPrice = plots.Sum(static x => x.Area*x.Sides);
Console.WriteLine($"Total Price = {discountTotalPrice}");
