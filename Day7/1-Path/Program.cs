using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPart;

namespace _1_Path
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            Dictionary<char, Part> parts = new Dictionary<char, Part>();
            List<Part> queue = new List<Part>();

            for (int l = 0; l < input.Length; ++l)
            {
                string[] tmp = input[l].Split(new[] { "tep " }, StringSplitOptions.RemoveEmptyEntries);
                char first = tmp[1][0];
                char second = tmp[2][0];

                if (!parts.ContainsKey(first))
                    parts.Add(first, new Part(first));
                if (!parts.ContainsKey(second))
                    parts.Add(second, new Part(second));

                parts[first].NextParts.Add(parts[second]);
                parts[second].PreviousParts.Add(parts[first]);
            }

            foreach (var part in parts)
            {
                if (part.Value.PreviousParts.Count == 0)
                {
                    queue.Add(parts[part.Key]);
                }
            }

            List<Part> doneList = new List<Part>();
            while (queue.Count > 0)
            {
                queue.Sort();
                Part part = null;

                for (int i = 0; i < queue.Count; ++i)
                {
                    if (queue[i].IsDone)
                    {
                        queue.RemoveAt(i);
                        --i;
                        continue;
                    }

                    if (queue[i].PreviousParts.Count == 0 || IsPreviousPartsDone(queue[i]))
                    {
                        part = queue[i];
                    }
                }

                if (part == null)
                    continue;

                queue.Remove(part);
                part.IsDone = true;
                doneList.Add(part);

                for (int i = 0; i < part.NextParts.Count; ++i)
                {
                    if (!part.NextParts[i].IsDone)
                        queue.Add(part.NextParts[i]);
                }
            }

            Console.Write("Answer: ");
            foreach (var part in doneList)
            {
                Console.Write(part.Symbol);
            }

            Console.ReadLine();
        }

        static bool IsPreviousPartsDone(Part part)
        {
            foreach (var previousPart in part.PreviousParts)
            {
                if (!previousPart.IsDone)
                    return false;
            }

            return true;
        }
    }
}
