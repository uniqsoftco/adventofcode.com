using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLocation
{
    public class Location
    {
        public int Symbol;
        public int AreaSize;
        public bool IsInfinite;
        public int X;
        public int Y;

        public Location(string line)
        {
            //X=Width======>
            //Y=Height vvvvvvv
            string[] xy = line.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            X = int.Parse(xy[0]);
            Y = int.Parse(xy[1]);
        }
    }
}
