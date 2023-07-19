using System;
using System.Collections.Generic;
using System.Linq;

namespace Data_Structures_Algorithms.Algorithms
{
    //https://www.javatpoint.com/display-all-subsets-of-an-integer-array-in-java
    //Step 1: Create a 2D array list answer for keeping all of the subsets.
    //Step 2: Also create a list tmp for keeping the current subset.
    //Step 3: Make a recursive method FindSubsets() that has the following four parameters:
    //One is for keeping the current index. The second one is for storing the current subset. The third one is for storing all of the generated subsets (2D list),
    //and the fourth one is the input array.
    //Step 5: Invoke the method with the current index as 0, empty current vector(initially, there will be no subset), the empty 2D list, and the input integer array.
    //Step 6: In the FindSubsets() method, we include the element into the list tmp and recursively invoke FindSubsets() with value i + 1.
    //Step 7: When the method call is returned, we delete the element from the tmp list and then invoke FindSubsets() method again with i + 1.
    //Step 8: If the value of i is the same as the size of the input array, then add the list tmp to the list answer.

    //Considering this fact gives the time complexity (2N). Also, O(N) time requires printing each subset.
    //Therefore, the total time complexity of the program is O(N x 2N).

    public class Subset
    {
        public void Test()
        {
            int[] nums = { 1, 2, 3 };

            Console.Write("For the array list: " + nums + " \n");
            Console.Write("The subsets are: ");

            DisplayAllSubsets(nums.Count(), nums);
        }

        // method that displays all the subsets with the help of the method getSubsets  
        public void DisplayAllSubsets(int s, int[] inputArrList)
        {
            //2D list for keeping all the subset found answer  
            List<List<int>> answer = new List<List<int>>();

            //A temporary list for keeping the current subset  
            List<int> tmp = new List<int>();

            // the first call to the recursive method  
            FindSubsets(0, tmp, answer, inputArrList);

            //Printing the final answer  
            for (int i = 0; i < answer.Count(); i++)
            {
                Console.Write("[");
                for (int j = 0; j < answer[i].Count(); j++)
                {
                    Console.Write((answer[i][j]));
                }
                Console.Write("]");
            }

            Console.ReadLine();
        }

        private void FindSubsets(int i, List<int> tmp, List<List<int>> answer, int[] inputArrList)
        {
            //Base case  
            if (i == inputArrList.Count())
            {
                //Including the generated current subset (which is non empty) to the 2D list answer  
                if (tmp.Count() > 0)
                {
                    answer.Add(tmp);
                }
                return;
            }

            //Generating the subset that has array element inside it  
            List<int> tmp1 = new List<int>(tmp);
            tmp1.Add(inputArrList[i]);
            FindSubsets(i + 1, tmp1, answer, inputArrList);

            //Generating the subset that will not contain the array element   
            FindSubsets(i + 1, tmp, answer, inputArrList);
        }
    }
}
