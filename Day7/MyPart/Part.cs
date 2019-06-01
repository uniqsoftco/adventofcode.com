using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPart
{
    public class Part : IComparable<Part>
    {
        public char Symbol;
        public bool IsDone = false;
        public List<Part> NextParts = new List<Part>();
        public List<Part> PreviousParts = new List<Part>();
        public int SecondsTake = 0;
        public Part(char symbol, int secondsTake = 0)
        {
            Symbol = symbol;
            SecondsTake = secondsTake;
        }

        public int CompareTo(Part part)
        {
            if (Symbol > part.Symbol) return -1;
            if (Symbol == part.Symbol) return 0;
            return 1;
        }
    }
}
