using System.ComponentModel.Design;
using System.Data;

namespace Day8;

public static class DataReader
{
    public static Grid ReadEquations(string filePath)
    {
        using var reader = new StreamReader(File.OpenRead(filePath));

        var ncols = -1;
        var nrows = 0;
        var antennae = new List<Antenna>();
        while (reader.ReadLine() is { } line)
        {

            for (var i = 0; i < line.Length; i++)
            {
                if (line[i] == '.')
                    continue;

                var antenna = new Antenna(line[i], new Position(nrows, i));
                antennae.Add(antenna);
            }

            ++nrows;
            if (ncols < 0)
                ncols = line.Length;
        }

        return new Grid(nrows, ncols, antennae);
    }
}