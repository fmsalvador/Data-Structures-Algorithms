using System;
using System.Collections.Generic;
using System.Linq;

namespace Data_Structures_Algorithms.Algorithms
{
    public class Dikstra
    {
        private const double _infinity = double.PositiveInfinity;
        private static Dictionary<string, Dictionary<string, double>> _graph = new Dictionary<string, Dictionary<string, double>>();
        private static List<string> _processed = new List<string>();

        public void Test()
        {

            //        (a)
            //       / | \
            //      6  |  1
            //     /   |   \
            //    (S)  3  (E)
            //     \   |   /
            //      2  |  5
            //       \ | /
            //        (b)

            _graph.Add("start", new Dictionary<string, double>());
            _graph["start"].Add("a", 6.0);
            _graph["start"].Add("b", 2.0);

            _graph.Add("a", new Dictionary<string, double>());
            _graph["a"].Add("fin", 1.0);

            _graph.Add("b", new Dictionary<string, double>());
            _graph["b"].Add("a", 3.0);
            _graph["b"].Add("fin", 5.0);

            _graph.Add("fin", new Dictionary<string, double>());

            //The costs table
            var costs = new Dictionary<string, double>
            {
                { "a", 6.0 },
                { "b", 2.0 },
                { "fin", _infinity }
            };

            var node = FindLowestCostNode(costs);
            while (node != null)
            {
                var cost = costs[node];
                //Go through all the neighbors of this node
                var neighbors = _graph[node];
                foreach (var n in neighbors.Keys)
                {
                    var newCost = cost + neighbors[n];
                    // If it's cheaper to get to this neighbor by going through this node
                    if (costs[n] > newCost)
                    {
                        //Update the cost for this node
                        costs[n] = newCost;
                    }
                }
                _processed.Add(node);
                //Find the next node to process and loop
                node = FindLowestCostNode(costs);
            }

            Console.WriteLine(string.Join(", ", costs.OrderBy(o => o.Value)));

            foreach (var cost in costs.OrderBy(o => o.Value))
            {
                if (cost.Key == "fin")
                    Console.Write(cost.Key + ". Equals to: " + cost.Value);
                else
                    Console.Write(cost.Key + " (" + cost.Value + ") -> ");
            }
        }

        private static string FindLowestCostNode(Dictionary<string, double> costs)
        {
            var lowestCost = double.PositiveInfinity;
            string lowestCostNode = null;
            foreach (var node in costs)
            {
                var cost = node.Value;
                //If it's the lowest cost so far and hasn't been processed yet...
                if (cost < lowestCost && !_processed.Contains(node.Key))
                {
                    //Set it as the new lowest-cost node.
                    lowestCost = cost;
                    lowestCostNode = node.Key;
                }
            }
            return lowestCostNode;
        }
    }
}
