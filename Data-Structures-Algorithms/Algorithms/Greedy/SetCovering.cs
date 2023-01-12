using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_Structures_Algorithms.Algorithms
{
    public class SetCovering
    {
        public void Test()
        {
            var statesNeeded = new HashSet<string> { "mt", "wa", "or", "id", "nv", "ut", "ca", "az" };
            var stationsAvailable = new Dictionary<string, HashSet<string>>
            {
                { "kone", new HashSet<string> { "id", "nv", "ut" } },
                { "ktwo", new HashSet<string> { "wa", "id", "mt" } },
                { "kthree", new HashSet<string> { "or", "nv", "ca" } },
                { "kfour", new HashSet<string> { "nv", "ut" } },
                { "kfive", new HashSet<string> { "ca", "az" } }
            };

            GetBestStationSet(statesNeeded, stationsAvailable);
        }

        public void GetBestStationSet(HashSet<string> statesNeeded, Dictionary<string, HashSet<string>> stationsAvailable)
        {
            var finalStations = new HashSet<string>();

            while (statesNeeded.Any())
            {
                string bestStation = null;
                var statesCovered = new HashSet<string>();

                foreach (var station in stationsAvailable)
                {
                    var covered = new HashSet<string>(statesNeeded.Intersect(station.Value));
                    if (covered.Count > statesCovered.Count)
                    {
                        bestStation = station.Key;
                        statesCovered = covered;
                    }
                }
                statesNeeded.RemoveWhere(s => statesCovered.Contains(s));
                finalStations.Add(bestStation);
            }
            Console.WriteLine(string.Join(", ", finalStations));
        }
    }
}
