using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures_Algorithms.Algorithms
{
    public class LongestCommonSubSequence
    {
        public void Test()
        {
            String s1 = "fish";
            String s2 = "fosh";

            char[] X = s1.ToCharArray();
            char[] Y = s2.ToCharArray();
            int m = X.Length;
            int n = Y.Length;

            Console.Write("Length of LCS is" + " " + LCS(X, Y, m, n));
        }
        static int LCS(char[] X, char[] Y, int m, int n)
        {
            int[,] L = new int[m + 1, n + 1];

            /* Following steps build L[m+1][n+1] 
            in bottom up fashion. Note 
            that L[i][j] contains length of 
            LCS of X[0..i-1] and Y[0..j-1] */
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                        L[i, j] = 0;
                    else if (X[i - 1] == Y[j - 1])
                        L[i, j] = L[i - 1, j - 1] + 1;
                    else
                        L[i, j] = Max(L[i - 1, j], L[i, j - 1]);
                }
            }
            return L[m, n];
        }

        /* Utility function to get max of 2 integers */
        static int Max(int a, int b)
        {
            return (a > b) ? a : b;
        }
    }
}
