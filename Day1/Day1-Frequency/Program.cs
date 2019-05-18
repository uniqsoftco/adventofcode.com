using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_Frequency
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"input.txt");
            int i = 0;

            char sign;
            int number;
            foreach (string line in input)
            {
                sign = line.Substring(0, 1)[0];
                number = int.Parse(line.Substring(1));

                if (sign == '-')
                    i -= number;
                else
                    i += number;
            }

            Console.WriteLine(i);
            Console.ReadLine();
        }
    }
}
