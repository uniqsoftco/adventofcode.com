using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_CheckSumOfAll
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"input.txt");
            List<List<CharCount>> lineList = new List<List<CharCount>>();


            for (int intLine = 0; intLine < input.Length; ++intLine)
            {
                string line = input[intLine];
                List<CharCount> charList = new List<CharCount>();
                lineList.Add(charList);
                for (int intChar = 0; intChar < line.Length; ++intChar)
                {
                    char chr = line[intChar];
                    CharCount charCount = charList.Find(c => c.Char == chr);
                    if (charCount != null)
                    {
                        charCount.Count++;
                    }
                    else
                    {
                        charList.Add(new CharCount { Char = chr, Count = 1 });
                    }
                }
            }

            int hasTwo = 0, hasThree = 0;

            foreach (var line in lineList)
            {
                foreach (var chr in line)
                {
                    if (chr.Count == 2)
                    {
                        hasTwo++;
                        break;
                    }
                }

                foreach (var chr in line)
                {
                    if (chr.Count == 3)
                    {
                        hasThree++;
                        break;
                    }
                }
            }

            Console.WriteLine(hasTwo);
            Console.WriteLine(hasThree);
            Console.WriteLine(hasTwo * hasThree);
            Console.ReadLine();
        }
    }
}
