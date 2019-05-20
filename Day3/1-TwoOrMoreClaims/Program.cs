using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPoint;

namespace _1_TwoOrMoreClaims
{
    class Program
    {
        static void Main(string[] args)
        {
            //     left,top: width x height
            //#1 @ 935,649: 22x22
            char[,] display = new char[2000, 2000];
            char emptyChar = display[0, 0];
            string[] input = File.ReadAllLines("input.txt");

            string num;
            Point LeftTop;
            Point WidthHeight;
            foreach (var line in input)
            {
                ParseDrawingString(in line, out num, out LeftTop, out WidthHeight);

                for (int height = LeftTop.HeightOrTop; height < LeftTop.HeightOrTop + WidthHeight.HeightOrTop; ++height)
                {
                    for (int width = LeftTop.WidthOrLeft; width < LeftTop.WidthOrLeft + WidthHeight.WidthOrLeft; ++width)
                    {
                        if (display[width, height] != emptyChar)
                        {
                            display[width, height] = 'x';
                        }
                        else
                        {
                            display[width, height] = num[num.Length - 1];
                        }
                    }
                }
            }

            int xCount = 0;
            for (int h = 0; h < 2000; ++h)
            {
                for (int w = 0; w < 2000; ++w)
                {
                    if (display[h, w] == emptyChar)
                        display[h, w] = '.';
                    else if (display[h, w] == 'x')
                        ++xCount;
                    Console.Write(display[h, w]);
                }

                Console.Write("\r\n");
            }

            Console.WriteLine($"xCount: {xCount}");
            //Console.ReadLine();
        }

        static void ParseDrawingString(in string str, out string num, out Point leftTop, out Point widthHeight)
        {
            string[] tmp =
                str
                    .Replace('#', Char.MinValue)
                    .Replace(" @ ", " ")
                    .Replace(',', ' ')
                    .Replace(": ", " ")
                    .Replace('x', ' ')
                    .Split(' ');

            //1 935 649 22 22
            num = tmp[0];
            leftTop = new Point() { WidthOrLeft = int.Parse(tmp[1]), HeightOrTop = int.Parse(tmp[2]) };
            widthHeight = new Point() { WidthOrLeft = int.Parse(tmp[3]), HeightOrTop = int.Parse(tmp[4]) };
        }
    }
}
