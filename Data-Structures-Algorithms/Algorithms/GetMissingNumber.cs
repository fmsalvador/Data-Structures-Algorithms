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
            int miss = GetMissingNo(a);
            Console.Write(miss);
        }

        static int GetMissingNo(int[] array)
        {
            var lenght = array.Length;

            int total = (lenght + 1) * (lenght + 2) / 2;

            for (int i = 0; i < lenght; i++)
                total -= array[i];

            return total;
        }
    }
}
