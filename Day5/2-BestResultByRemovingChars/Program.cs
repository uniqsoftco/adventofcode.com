using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BestResultByRemovingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            int shortestPolymer = 0;

            for (int c = 0; c <= 25; ++c)
            {
                char l = (char)(97 + c);
                char u = (char)(65 + c);

                input = File.ReadAllText("input.txt");
                int reactCount;

                Console.WriteLine($"Removing all {u}{l}...");
                do
                {
                    reactCount = 0;
                    for (int i = 0; i < input.Length - 1; ++i)
                    {
                        if (input[i] == l || input[i] == u)
                        {
                            input = input.Remove(i, 1);
                            --i;
                        }
                        else if (input[i] - 32 == input[i + 1] || input[i] + 32 == input[i + 1])
                        {
                            input = input.Remove(i, 2);
                            ++reactCount;
                            --i;
                        }
                    }
                } while (reactCount > 0);

                File.WriteAllText($"out_{u}{l}.txt", input);
                Console.WriteLine($"{u}{l} Len:  {input.Length}\n\n");

                if (shortestPolymer == 0 || input.Length < shortestPolymer)
                {
                    shortestPolymer = input.Length;
                }
            }

            Console.WriteLine($"\n\nAnswer: {shortestPolymer}");
            Console.ReadLine();
        }
    }
}
