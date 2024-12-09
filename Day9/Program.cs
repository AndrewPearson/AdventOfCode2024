using Day9;

var filePath = "Data/input.txt";
var diskMap = DiskMapReader.Load(filePath);
Console.WriteLine("==== Disk Map ====");
Console.WriteLine(diskMap);
Console.WriteLine();

var blockMap = diskMap.ToBlockMap();
Console.WriteLine("==== Block Map ====");
Console.WriteLine(blockMap);
Console.WriteLine();

var defrag1 = blockMap.Defrag1();
Console.WriteLine("==== Disk Map After Defrag1 ====");
Console.WriteLine(defrag1);
Console.WriteLine();

var checkSum1 = defrag1.CheckSum();
Console.WriteLine($"Defrag1 Check Sum = {checkSum1}");

var defrag2 = blockMap.Defrag2();
Console.WriteLine("==== Disk Map After Defrag2 ====");
Console.WriteLine(defrag2);
Console.WriteLine();

var checkSum2 = defrag2.CheckSum();
Console.WriteLine($"Defrag2 Check Sum = {checkSum2}");

