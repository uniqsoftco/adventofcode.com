using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_WhatRemainsAfterReact
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText("input.txt");
            int reactCount = 0;

            do
            {
                reactCount = 0;
                for (int i = 0; i < input.Length - 1; ++i)
                {
                    if (input[i] - 32 == input[i + 1] || input[i] + 32 == input[i + 1])
                    {
                        input = input.Remove(i, 2);
                        ++reactCount;
                        --i;
                    }
                }
            } while (reactCount > 0);

            File.WriteAllText("out.txt", input);
            Console.WriteLine($"Answer:  {input.Length}");
            Console.ReadLine();
        }
    }
}
