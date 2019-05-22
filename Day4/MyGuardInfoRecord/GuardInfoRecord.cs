using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGuardInfoRecord
{
    public class GuardInfoRecord : IComparable<GuardInfoRecord>
    {
        public DateTime TimeStamp;
        public string GuardId { get; }
        public string Record { get; }
        public bool IsGuardBeginsShift { get; }
        public bool IsGuardFallsAsleep { get; }
        public bool IsGuardWakesUp { get; }

        public GuardInfoRecord(string info)
        {
            Record = info;
            string[] tmp = info.Split(']');
            tmp[0] = tmp[0].Remove(0, 1);
            TimeStamp = DateTime.ParseExact(tmp[0], "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
            tmp[1] = tmp[1].ToLower();
            switch (tmp[1].Substring(1, 1)[0])
            {
                case 'g':
                    int indexOfSharp = tmp[1].IndexOf('#');
                    GuardId = tmp[1]
                        .Substring(
                            indexOfSharp,
                            tmp[1].IndexOf(' ', indexOfSharp) - indexOfSharp);
                    IsGuardBeginsShift = true;
                    break;
                case 'f':
                    IsGuardFallsAsleep = true;
                    break;
                case 'w':
                    IsGuardWakesUp = true;
                    break;
            }
        }

        public int CompareTo(GuardInfoRecord gir)
        {
            if (TimeStamp < gir.TimeStamp) return -1;
            if (TimeStamp == gir.TimeStamp) return 0;
            return 1;
        }
    }
}
