using System;

namespace Data_Structures_Algorithms.Algorithms
{
    public class LongestCommonSubstring
    {
        static String X, Y;

        public void Test()
        {
            int n, m;
            X = "fosh";
            Y = "fish";

            n = X.Length;
            m = Y.Length;

            Console.Write(lcs(n, m, 0));
        }

        // Returns length of function for
        // longest common substring of
        // X[0..m-1] and Y[0..n-1]
        static int lcs(int i, int j, int count)
        {
            if (i == 0 || j == 0)
            {
                return count;
            }

            if (X[i - 1] == Y[j - 1])
            {
                count = lcs(i - 1, j - 1, count + 1);
            }
            count = Math.Max(count, Math.Max(lcs(i, j - 1, 0),
                                             lcs(i - 1, j, 0)));
            return count;
        }

    }
}

