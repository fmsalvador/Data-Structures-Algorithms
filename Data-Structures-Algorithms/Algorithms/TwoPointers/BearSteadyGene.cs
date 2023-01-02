using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Data_Structures_Algorithms.Algorithms
{
    public class BearSteadyGene
    {
        public int maxOfAllowedChars;
        public void Test()
        {
            //GAAATAAA
            //Output 5
            //One optimal solution is to replace AAATA with TTCCG resulting in GTTCCGAA .
            //The replaced substring has length 5

            //GACT is a steady gene
            //It is considered to be steady if each of the four letters occurs exactly n/4 times.

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            //var numberOfMinimumSubStr = FindMinSubStr("GAAATAAA");//5
            var numberOfMinimumSubStr = FindMinSubStr("TGATGCCGTCCCCTCAACTTGAGTGCTCCTAATGCGTTGC");//5

            Console.WriteLine(numberOfMinimumSubStr);
        }


        public static int FindMinSubStr(string gene)
        {
            var count = new Dictionary<char, int>
            {
                { 'A', 0 },
                { 'C', 0 },
                { 'G', 0 },
                { 'T', 0 }
            };

            for (int i = 0; i < gene.Length; i++)//Counting the number of each chars in the string
            {
                count[gene[i]]++;
            }

            int maxOfAllowedChars = gene.Length / 4;
            int j = 0;
            int minLength = gene.Length;

            for (int i = 0; i < gene.Length; i++)
            {
                Console.WriteLine("First pointer: " + i);
                while (count['A'] > maxOfAllowedChars || count['T'] > maxOfAllowedChars || count['G'] > maxOfAllowedChars || count['C'] > maxOfAllowedChars)
                {
                    if (j == gene.Length)
                    {
                        return minLength;
                    }

                    count[gene[j]]--;//Decrease until all chars have less thant maxOfAllowedChars
                    j++;
                    Console.WriteLine("Second pointer: " + j);
                }


                //Second pointer (j) will increase to make sure all the string will be iterated
                Console.WriteLine(j - i);
                minLength = Math.Min(minLength, j - i); // The result is the second pointer - the first pointer until the second pointer reach the gene length
                count[gene[i]]++;//Increase just to keep the logic going until the whole string is iterated (j == gene.Length)
            }

            return minLength;

            //Two pointer solution O(n^2)
        }
    }
}
