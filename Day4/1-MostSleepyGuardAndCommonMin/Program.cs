using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_MostSleepyGuardAndCommonMin
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

            GuardSleepInfo mostSleepyGuard = guardSleepInfo.First().Value;
            string mSGID = "";
            foreach (var guard in guardSleepInfo)
            {
                if (guard.Value.Tsm > mostSleepyGuard.Tsm)
                {
                    mostSleepyGuard = guardSleepInfo[guard.Key];
                    mSGID = guard.Key;
                }
            }
            string file =
                $"{mSGID}\r\n" +
                $"TSM: {mostSleepyGuard.Tsm}\r\n";
            int mostSleepMin = 0;
            int mostSleepMinCount = 0;
            for (int m = 0; m < 60; ++m)
            {
                if (mostSleepyGuard.Smc[m] > mostSleepMinCount)
                {
                    mostSleepMinCount = mostSleepyGuard.Smc[m];
                    mostSleepMin = m;
                }

            }
            file += $"Most Sleep Minute-{mostSleepMin}: {mostSleepyGuard.Smc[mostSleepMin]}\r\n";
            file += $"Answer: {int.Parse(mSGID.Substring(1)) * mostSleepMin}\r\n";
            file += "\r\n";
            Console.WriteLine(file);
            Console.ReadLine();
        }
    }
}
