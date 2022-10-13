using System;

namespace Data_Structures_Algorithms.Algorithms
{
    class MinimumSwapPalindrome
    {
        static void Main(string[] args)
        {
            var input = "001010";
            Console.WriteLine(MinimumSwap(input));
        }

        static int MinimumSwap(string s)
        {
            var count = 0;
            var l = 0;
            var r = s.Length - 1;
            var sb = new StringBuilder(s);
            var skip = 0;
            while (l < r)
            {
                var leftChar = sb[l];
                var temp = r;
                while (l < temp && leftChar != sb[temp])
                {
                    temp--;
                }
                if (l == temp)
                {
                    if (s.Length % 2 == 0)
                    {
                        return -1;
                    }
                    else
                    {
                        if (skip == 1)
                        {
                            return -1;
                        }
                        skip = 1;
                        count = count + (s.Length / 2) - l;
                        l++;
                    }
                    continue;
                }
                count = count + r - temp;
                sb.Remove(temp,1);
                sb.Insert(r, leftChar);
                r--;
                l++;
            }
            return count; 
        }
    }
}
