using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_SeenTwiceFrequency
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"input.txt");
            int result = 0;
            Dictionary<int, int> seenCounter = new Dictionary<int, int>();

            char sign;
            int number;
            int i = 0;
            while (true)
            {
                sign = input[i].Substring(0, 1)[0];
                number = int.Parse(input[i].Substring(1));

                if (seenCounter.ContainsKey(result))
                {
                    ++seenCounter[result];

                    if (seenCounter[result] > 1)
                        break;
                }
                else
                    seenCounter.Add(result, 1);

                if (sign == '-')
                    result -= number;
                else
                    result += number;

                if (i == input.Length - 1)
                    i = 0;
                else
                    ++i;
            }

            Console.WriteLine(result);
            Console.WriteLine(seenCounter[result]);
            Console.ReadLine();
        }
    }
}
