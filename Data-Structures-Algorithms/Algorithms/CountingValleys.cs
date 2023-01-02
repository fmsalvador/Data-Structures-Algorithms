using System;
using System.Collections.Generic;

namespace Data_Structures_Algorithms.Algorithms
{
    public class CountingValleys
    {
        public void Test()
        {
            //D are steps down and U are steps up
            int result = ReturnNumberOfValleys("DDUUDDUDUUUD");
            Console.WriteLine(result);
        }

        public static int ReturnNumberOfValleys(string path)
        {
            var numberOfValleys = 0;
            var stepUp = 'U';
            var listOfUps = new List<int>();
            var listOfDowns = new List<int>();
            bool descending;

            foreach (char step in path)
            {
                if (step == stepUp)
                {
                    listOfUps.Add(1);
                    descending = false;
                }
                else
                {
                    listOfDowns.Add(1);
                    descending = true;
                }

                if (listOfDowns.Count == listOfUps.Count && !descending)
                {
                    listOfDowns.Clear();
                    listOfUps.Clear();
                    numberOfValleys++;
                }
            }

            return numberOfValleys;
        }
    }
}
