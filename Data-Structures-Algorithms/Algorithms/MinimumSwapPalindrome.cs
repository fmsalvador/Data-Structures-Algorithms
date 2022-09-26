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

        static int MinimumSwap(string input)
        {
            var arr = input.ToCharArray();
            int count = 0;
            int length = input.Length;
            // A loop which run in half
            // string from starting
            for (int i = 0; i < length / 2; i++)
            {
                int left = i;
                int right = length - 1 - i;
                // A loop which run from
                // right pointer to left pointer
                while (left < right)
                {
                    // if both char same
                    // then break the loop
                    // if not same then we
                    // have to move right
                    // pointer to one step
                    // left
                    if (arr[left] == arr[right]) 
                        break;
                    else 
                        right--;
                }

                // it denotes both pointer at
                // same position and we don't
                // have sufficient char to make
                // palindrome string
                if (left == right) 
                    return -1;
                else
                {
                    for (int j = right; j < length - 1 - left; j++)
                    {
                        AdjacentSwap(arr, j);
                        count++;
                    }
                }
            }
            return count;
        }

        static void AdjacentSwap(char[] arr, int i)
        {
            char temp = arr[i];
            arr[i] = arr[i + 1];
            arr[i + 1] = temp;
        }
    }
}
