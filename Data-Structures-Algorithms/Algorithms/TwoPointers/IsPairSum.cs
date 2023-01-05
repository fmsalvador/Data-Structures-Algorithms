using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures_Algorithms.Algorithms
{
    internal class IsPairSum
    {
        public void Test()
        {
            int[] arr = { 2, 3, 5, 8, 9, 10, 11 };
            // value to search
            int val = 17;

            Console.Write(CountPairSums(arr, val));
        }

        public static int CountPairSums(int[] array, int valToValidateTheSum)
        {
            //first pointer
            int i = 0;
            int lenght = array.Length;
            //second pointer
            int j = lenght - 1;

            while (i < j)
            {
                // If we find a pair
                if (array[i] + array[j] == valToValidateTheSum)
                    return 1;

                // If sum of elements at current
                // pointers is less, we move towards
                // higher values by doing i++
                else if (array[i] + array[j] < valToValidateTheSum)
                    i++;

                // If sum of elements at current
                // pointers is more, we move towards
                // lower values by doing j--
                else
                    j--;
            }
            return 0;
        }
        //Time Complexity:  O(n log n) (As sort function is used)
        //Auxiliary Space: O(1), since no extra space has been taken.
    }
}
