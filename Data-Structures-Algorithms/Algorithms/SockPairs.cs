using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Data_Structures_Algorithms.Algorithms
{
    public class SockPairs
    {
        public void Test()
        {
            int n = 9;

            List<int> ar = new List<int>
            {
              10, 20, 20, 10, 10, 30, 50, 10, 20
            };

            int result = sockMerchant(n, ar);

            Console.WriteLine(result);
        }

        public static int sockMerchant(int n, List<int> ar)
        {
            List<int> listPairs = new List<int>();
            List<int> numberWithoutPairs = new List<int>();
            var firstNine = ar.Take(n);

            foreach (var item in firstNine)
            {
                if (numberWithoutPairs.Any(w => w == item))
                {
                    listPairs.Add(item);
                    numberWithoutPairs.Remove(item);
                }
                else
                {
                    numberWithoutPairs.Add(item);
                }
            }

            return listPairs.Count;
        }
    }
}

