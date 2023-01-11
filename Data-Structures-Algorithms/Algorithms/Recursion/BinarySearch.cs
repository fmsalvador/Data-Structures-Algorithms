 using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures_Algorithms.Algorithms.Recursion
{
    public class BinarySearch
    {
        public void Test()
        {
            int[] arr = { 2, 3, 4, 10, 40 };
            int n = arr.Length;
            int x = 10;

            int result = BinarySearchRecursive(arr, 0, n - 1, x);

            if (result == -1)
                Console.WriteLine("Element not present");
            else
                Console.WriteLine("Element found at index " + result);
        }
        static int BinarySearchRecursive(int[] array, int left, int right, int elementToFind)
        {
            if (right >= left)
            {
                int mid = left + (right - left) / 2;

                // If the element is present at the middle itself
                if (array[mid] == elementToFind)
                    return mid;

                // If element is smaller than mid, then
                // it can only be present in left subarray
                if (array[mid] > elementToFind)
                    return BinarySearchRecursive(array, left, mid - 1, elementToFind);

                // Else the element can only be present
                // in right subarray
                return BinarySearchRecursive(array, mid + 1, right, elementToFind);
            }

            // We reach here when element is not present
            // in array
            return -1;
        }

        //Time Complexity: O(log n)
        //Auxiliary Space: O(log n)
    }
}
