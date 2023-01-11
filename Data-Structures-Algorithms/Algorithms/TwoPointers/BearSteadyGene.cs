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
            var numberOfMinimumSubStr = FindMinSubStr("GAAATAAA");//5
            //var numberOfMinimumSubStr = FindMinSubStr("TGATGCCGTCCCCTCAACTTGAGTGCTCCTAATGCGTTGC");//5

            Console.WriteLine(numberOfMinimumSubStr);
        }


        public static int FindMinSubStr(string gene)
        {
            var charCounts = new Dictionary<char, int>
            {
                { 'A', 0 },
                { 'C', 0 },
                { 'G', 0 },
                { 'T', 0 }
            };

            for (int i = 0; i < gene.Length; i++)//Counting the number of each chars in the string
            {
                charCounts[gene[i]]++;
            }

            char nucleotide;
            var geneLength = gene.Length;
            var maxNucleotideCount = geneLength / 4;

            // "Extras" are any count that is over max_nucleotide_count
            if (!ValidateIfCharCountIsValid(charCounts, maxNucleotideCount))
            {
                return 0;
            }

            // find smallest subset of string containing all extras
            // using moving window
            var rightRunner = 0;
            var leftRunner = 0;
            var minSubstringLength = int.MaxValue;

            while (rightRunner < geneLength)
            {
                // O(n)
                // if extras still available...
                while (rightRunner < geneLength && ValidateIfCharCountIsValid(charCounts, maxNucleotideCount))
                {
                    // move right runner and remove nucleotide from all_counts
                    nucleotide = gene[rightRunner];
                    charCounts[nucleotide] -= 1;
                    rightRunner += 1;
                }
                while (leftRunner < geneLength && !ValidateIfCharCountIsValid(charCounts, maxNucleotideCount))
                {
                    // no extras available => window may contain best substring
                    // move left runner and add nucleotide to all_counts
                    nucleotide = gene[leftRunner];
                    charCounts[nucleotide] += 1;
                    leftRunner += 1;
                }
                minSubstringLength = Math.Min(minSubstringLength, rightRunner - leftRunner + 1);
            }
            return minSubstringLength;
        }

        public static bool ValidateIfCharCountIsValid(Dictionary<char, int> charCounts, int maxNucleotideCount)
        {
            // loop through all counts
            foreach (var counts in charCounts.Values)
            {
                // if any count is greater than max_nucleotide_count, return True
                if (counts > maxNucleotideCount)
                {
                    return true;
                }
            }
            // if got past loop, no extras found => return False
            return false;
        }
    }
}
