using System;

namespace Data_Structures_Algorithms.Algorithms
{
    public class LongestUniqueSubsttr
    {
        public void Test()
        {
            var str = "geeksforgeeks";
            Console.WriteLine("The input string is " + str);
            var len = CountLongestUniqueSubsttr(str);
            Console.WriteLine("The length of the longest " + "non-repeating character " + "substring is " + len.ToString());
        }
        public static int CountLongestUniqueSubsttr(String str)
        {
            var test = "";

            // Result
            var maxLength = -1;

            // Return zero if string is empty
            if (str.Length == 0)
            {
                return 0;
            }
            else if (str.Length == 1)
            {
                return 1;
            }

            foreach (char c in str.ToCharArray())
            {
                var current = c + "";

                // If string already contains the character
                // Then substring after repeating character
                if (test.Contains(current))
                {
                    test = test.Substring(test.IndexOf(current) + 1);
                }
                test += c;
                maxLength = Math.Max(test.Length, maxLength);
            }
            return maxLength;
        }

        //Time Complexity: O(n)
    }
}
