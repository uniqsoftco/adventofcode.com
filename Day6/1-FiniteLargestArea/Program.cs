using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using MyLocation;

namespace _1_FiniteLargestArea
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            List<Location> locations = new List<Location>();
            int[,] display = new int[500, 500];

            for (int i = 0; i < input.Length; ++i)
            {
                Location location = new Location(input[i]) { Symbol = i + 1 };
                locations.Add(location);
                display[location.X, location.Y] = location.Symbol;
                /*Console.WriteLine(
                    "Location:\n\t" +
                              $"Symbol: {location.Symbol}\n\t" +
                              $"X: {location.X}\n\t" +
                              $"Y: {location.Y}\n\t" +
                              $"IsInfinite: {location.IsInfinite}\n\t" +
                              $"AreaSize: {location.AreaSize}");*/
            }

            for (int x = 0; x < 500; ++x)
            {
                for (int y = 0; y < 500; ++y)
                {
                    int lowestManhattanIndex = 0;
                    List<int> manhattans = new List<int>();
                    bool zeroSymbol = false;
                    for (int l = 0; l < locations.Count; ++l)
                    {
                        int currentManhattan = Math.Abs(locations[l].X - x) + Math.Abs(locations[l].Y - y);
                        if (manhattans.Contains(currentManhattan))
                            zeroSymbol = true;
                        if (manhattans.All(i => i > currentManhattan))
                            lowestManhattanIndex = l;
                        manhattans.Insert(l, currentManhattan);
                    }

                    if (zeroSymbol)
                        display[x, y] = 0;
                    else
                        display[x, y] = locations[lowestManhattanIndex].Symbol;
                }
            }

            for (int x = 0; x < 500; ++x)
            {
                for (int y = 0; y < 500; ++y)
                {
                    if (display[x, y] > 0)
                    {
                        ++locations[display[x, y]-1].AreaSize;
                        if (x == 0 || y == 0 || x == 499 || y == 499)
                            locations[display[x, y]].IsInfinite = true;
                    }
                }
            }

            Location largestFiniteLocation = locations[0];
            for (int i = 0; i < locations.Count; ++i)
            {
                if (!locations[i].IsInfinite && largestFiniteLocation.AreaSize < locations[i].AreaSize)
                {
                    largestFiniteLocation = locations[i];
                }
            }

            Console.WriteLine(
                    "Answer:\n\t" +
                              $"Symbol: {largestFiniteLocation.Symbol}\n\t" +
                              $"X: {largestFiniteLocation.X}\n\t" +
                              $"Y: {largestFiniteLocation.Y}\n\t" +
                              $"IsInfinite: {largestFiniteLocation.IsInfinite}\n\t" +
                              $"AreaSize: {largestFiniteLocation.AreaSize}");

            Console.ReadLine();
        }
    }
}

