using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGuardInfoRecord;
using MyGuardSleepInfo;

namespace _2_MostSleptMinute
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            List<GuardInfoRecord> guardInfoRecords = new List<GuardInfoRecord>();
            foreach (var line in input)
            {
                guardInfoRecords.Add(new GuardInfoRecord(line));
            }
            guardInfoRecords.Sort();

            Dictionary<string, GuardSleepInfo> guardSleepInfo = new Dictionary<string, GuardSleepInfo>();
            string activeGuardId = "";
            for (int i = 0; i < guardInfoRecords.Count; ++i)
            {
                if (guardInfoRecords[i].IsGuardBeginsShift)
                {
                    if (!guardSleepInfo.ContainsKey(guardInfoRecords[i].GuardId))
                        guardSleepInfo.Add(guardInfoRecords[i].GuardId, new GuardSleepInfo());
                    activeGuardId = guardInfoRecords[i].GuardId;
                    continue;
                }

                if (guardInfoRecords[i].IsGuardWakesUp)
                {
                    guardSleepInfo[activeGuardId].Tsm +=
                        (guardInfoRecords[i].TimeStamp - guardInfoRecords[i - 1].TimeStamp).Minutes;

                    for (int m = guardInfoRecords[i - 1].TimeStamp.Minute; m < guardInfoRecords[i].TimeStamp.Minute; ++m)
                    {
                        ++guardSleepInfo[activeGuardId].Smc[m];
                    }
                }
            }

            /*string file = "";
            foreach (var guard in guardSleepInfo)
            {
                file +=
                    $"{guard.Key}\r\n" +
                    $"TSM: {guard.Value.Tsm}\r\n";
                for (int m = 0; m < 60; ++m)
                {
                    file += $"Minute-{m} Count: {guard.Value.Smc[m]}\r\n";
                }
                file += "\r\n";
            }
            File.WriteAllText("out.txt", file);*/

            GuardSleepInfo hasBiggestSleepMinute = guardSleepInfo.First().Value;
            string guardId = "";
            int minuteNum = 0;

            foreach (var guard in guardSleepInfo)
            {
                for (int m = 0; m < 60; ++m)
                {
                    if (hasBiggestSleepMinute.Smc[minuteNum] < guard.Value.Smc[m])
                    {
                        hasBiggestSleepMinute = guard.Value;
                        guardId = guard.Key;
                        minuteNum = m;
                    }
                }
            }

            Console.WriteLine(
                $"GuardID: {guardId}\n" +
                $"MinuteNum: {minuteNum}\n" +
                $"MinuteCount: {hasBiggestSleepMinute.Smc[minuteNum]}\n" +
                $"Answer: {int.Parse(guardId.Substring(1)) * minuteNum}");

            Console.ReadLine();
        }
    }
}
