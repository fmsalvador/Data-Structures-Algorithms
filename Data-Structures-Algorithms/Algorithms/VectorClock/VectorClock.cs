using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures_Algorithms.Algorithms
{
    public class VectorClock
    {
        private Dictionary<string, int> clock;

        public void Test()
        {
            VectorClock clock1 = new VectorClock();
            clock1.Increment("Process1");
            clock1.Increment("Process1");

            VectorClock clock2 = new VectorClock();
            clock2.Increment("Process2");
            clock2.Increment("Process2");
            clock2.Increment("Process2");

            Console.WriteLine("Clocks has concurrent? " + clock1.IsConcurrent(clock2));

            clock1.Merge(clock2);

            Console.WriteLine("Clock 1: " + string.Join(", ", clock1.GetClock()));
            Console.WriteLine("Clock 2: " + string.Join(", ", clock2.GetClock()));
        }

        public VectorClock()
        {
            clock = new Dictionary<string, int>();
        }

        public void Increment(string processID)
        {
            if (!clock.ContainsKey(processID))
                clock[processID] = 1;
            else
                clock[processID]++;
        }

        public bool IsConcurrent(VectorClock otherClock)
        {
            foreach (var entry in clock)
            {
                String processId = entry.Key;
                int localTimestamp = entry.Value;
                int otherTimestamp = otherClock.clock.GetValueOrDefault(processId, 0);

                if (localTimestamp > otherTimestamp)
                {
                    return true;
                }
            }

            return false;
        }

        public void Merge(VectorClock otherClock)
        {
            Console.WriteLine("Merging clocks");

            foreach (var kvp in otherClock.clock)
            {
                string processID = kvp.Key;
                int timestampOther = kvp.Value;

                if (!clock.ContainsKey(processID))
                {
                    clock[processID] = timestampOther;
                }
                else
                {
                    int timestampLocal = clock[processID];
                    clock[processID] = Math.Max(timestampLocal, timestampOther);
                }
            }
        }

        public Dictionary<string, int> GetClock()
        {
            return clock;
        }
    }
}
