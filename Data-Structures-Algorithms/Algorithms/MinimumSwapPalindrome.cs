using System;

namespace Data_Structures_Algorithms.Algorithms
{
    class MinimumSwapPalindrome
    {
        static void Main(string[] args)
        {
            var string = "001010";
            Console.WriteLine(MinMovesToMakePalindrome(string));
        }

        static int MinMovesToMakePalindrome(String s)
        {
            var ans = 0;
            var firstPointer = 0;
            var end = s.Length - 1;
            char[] ch = s.ToCharArray();

            if (CanFormPalindrome(s) == false)
                return -1;

            while (firstPointer < end)
            {
                var secondPointer = end;
                if (ch[firstPointer] == ch[end])
                {
                    Console.WriteLine($"First pointer ({ch[firstPointer]}) is equal to the last ({ch[end]}) ");
                    //The chars are the same in the index pointers
                    firstPointer++; // first char will remain in the same index, so it will be ignored 
                    end--; // last char will remain in the same index so it will be ignored 

                    if (firstPointer < end)
                        Console.WriteLine($"Nothing happens. First pointer is now index {firstPointer} and second pointer is index {end}");

                    continue;
                }

                while (ch[firstPointer] != ch[secondPointer])
                {
                    Console.WriteLine($"First pointer ({ch[firstPointer]}) in the index {firstPointer} is different to second pointer({ch[secondPointer]}) in the index {secondPointer}, so the second pointer will jump to index {secondPointer - 1}");
                    secondPointer--;//decreasing until find the same chars between the two pointers
                }


                if (firstPointer == secondPointer)//If both reach the same index, swap the chars so it never get stucked in a infinite loop
                {
                    Swap(ch, secondPointer, secondPointer + 1); // Change one char with the rightmost one
                    ans++;
                }
                else
                {
                    while (secondPointer < end)
                    {
                        Swap(ch, secondPointer, secondPointer + 1); // Change one char with the rightmost one
                        ans++;
                        secondPointer++;
                    }
                }
            }

            return ans;
        }

        static void Swap(char[] ch, int i, int j)
        {
            Console.WriteLine("The char" + ch[j] + " of index " + j + " are goint to index " + i + " that was the char: " + ch[i] + $".The index {i} will receive the char {ch[j]}");
            var temp = ch[i];
            ch[i] = ch[j];
            ch[j] = temp;
        }

        static bool CanFormPalindrome(string str)
        {
            int NO_OF_CHARS = 256;

            // Create a count array and initialize all
            // values as 0
            int[] count = new int[NO_OF_CHARS];
            Array.Fill(count, 0);

            // For each character in input strings,
            // increment count in the corresponding
            // count array
            for (int i = 0; i < str.Length; i++)
            {
                count[(int)(str[i])]++;
            }

            // Count odd occurring characters
            int odd = 0;
            for (int i = 0; i < NO_OF_CHARS; i++)
            {
                if ((count[i] & 1) == 1)
                    odd++;

                if (odd > 1)
                    return false;
            }

            // Return true if odd count is 0 or 1,
            return true;
        }
    }
}
