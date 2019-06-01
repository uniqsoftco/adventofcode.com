using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_SumOfAllMetadata
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input =
                new List<string>(
                File.ReadAllText("input.txt")
                    .Split(new[] { ' ' }));
            int allMetaDataSum = ProcessChild(input, 0);

            /*int i = 0;
            int
                childCount = 0,
                metaDataCount = 0;
            while (input.Count > 0)
            {
                if (i >= input.Count)
                    i = 0;

                childCount = int.Parse(input[i]);
                metaDataCount = int.Parse(input[i + 1]);

                if (childCount == 0)
                {
                    input[i - 2] = (int.Parse(input[i - 2]) - 1).ToString();
                    for (int m = i + 2; m <= i + 2 + metaDataCount; ++m)
                    {
                        allMetaDataSum += int.Parse(input[m]);
                    }
                    input.RemoveRange(i, 2 + metaDataCount);
                }
                else
                {
                    i += 2;
                }
            }*/

            Console.Write($"Answer: {allMetaDataSum}");
            Console.ReadLine();
        }

        static int ProcessChild(List<string> input, int headerStartingIndex)
        {
            int childMetaDataSum = 0;
            while (true)
            {
                int childCount = int.Parse(input[headerStartingIndex]);
                int metaDataCount = int.Parse(input[headerStartingIndex + 1]);

                if (childCount > 0)
                {
                    childMetaDataSum += ProcessChild(input, headerStartingIndex + 2);
                }
                else
                {
                    if (headerStartingIndex > 0)
                        input[headerStartingIndex - 2] = (int.Parse(input[headerStartingIndex - 2]) - 1).ToString();
                    for (int m = headerStartingIndex + 2; m < headerStartingIndex + 2 + metaDataCount; ++m)
                    {
                        childMetaDataSum += int.Parse(input[m]);
                    }
                    input.RemoveRange(headerStartingIndex, 2 + metaDataCount);

                    return childMetaDataSum;
                }
            }
        }
    }
}
