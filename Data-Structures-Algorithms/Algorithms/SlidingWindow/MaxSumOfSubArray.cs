using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures_Algorithms.Algorithms
{
    public class MaxSumOfSubArray
    {
        public void Test()
        {
            int[] arr = { 1, 4, 2, 10, 2, 3, 1, 0, 20 }; //Max sum is 20 + 0 + 1 + 3
            int k = 4;
            Console.WriteLine(MaxSum(arr, k));
        }

        static int MaxSum(int[] arr, int k)
        {
            if (arr.Length < k)
            {
                Console.WriteLine("Invalid");
                return -1;
            }

            // Compute sum of first window of size k
            int maxSum = 0;

            for (int i = 0; i < k; i++)
                maxSum += arr[i];

            // Compute sums of remaining windows by
            // removing first element of previous
            // window and adding last element of
            // current window.
            int windowSum = maxSum;
            for (int i = k; i < arr.Length; i++)
            {
                windowSum += arr[i] - arr[i - k]; //arr[i - k] is the first element of previous window
                maxSum = Math.Max(maxSum, windowSum);
            }

            return maxSum;
        }

        //Complexity is O(n).
    }
}
