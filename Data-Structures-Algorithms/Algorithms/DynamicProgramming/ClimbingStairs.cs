using System;


namespace Data_Structures_Algorithms.Algorithms
{
    public class ClimbingStairs
    {
        //Dynamic Programming.
        //Create two variables prev and prev2 to store the ways to climb one stair or two stairs.
        //Run a for loop to count the total number of ways to reach the top.
        public void Test()
        {
            int n = 3;
            Console.WriteLine("Number of ways = "+ ClimbStairs(n));
        }

        public static int ClimbStairs(int n)
        {
            //Two variables to store the count
            int prev = 1;
            int prev2 = 1;
            // Running for loop to count all possible ways
            for (int i = 2; i <= n; i++)
            {
                int curr = prev + prev2;
                prev2 = prev;
                prev = curr;
            }
            return prev;
        }
        //Time Complexity: O(N)
    }
}
