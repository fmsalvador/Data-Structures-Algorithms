using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures_Algorithms.Algorithms
{
    public class GetMissingNumber
    {
        public void Test()
        {
            int[] a = { 1, 2, 3, 4, 5, 7 };
            var length = a.Length;
            int miss = GetMissingNo(a, length);
            Console.Write(miss);
        }

        static int GetMissingNo(int[] array, int n)
        {
            int total = (n + 1) * (n + 2) / 2;

            for (int i = 0; i < n; i++)
                total -= array[i];

            return total;
        }
    }
}
