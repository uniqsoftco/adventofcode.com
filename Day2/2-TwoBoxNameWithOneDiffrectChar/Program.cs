using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_TwoBoxNameWithOneDiffrectChar
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"input.txt");

            foreach (var line in input)
            {
                foreach (var line2 in input)
                {
                    int notEqChars = 0;
                    string eqChars = string.Empty;
                    for (int i = 0; i < line.Length; ++i)
                    {
                        if (line[i] == line2[i])
                        {
                            eqChars += line[i];
                        }
                        else
                        {
                            ++notEqChars;
                        }
                    }

                    if (notEqChars == 1)
                    {
                        Console.WriteLine($"Line1: {line}\n" +
                                          $"Line2: {line2}\n" +
                                          $"EqChars: {eqChars}");
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
