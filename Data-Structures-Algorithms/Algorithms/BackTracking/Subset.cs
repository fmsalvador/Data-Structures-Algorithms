using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_Structures_Algorithms.Algorithms
{
    //Considering this fact gives the time complexity (2N). Also, O(N) time requires printing each subset.
    //Therefore, the total time complexity of the program is O(N x 2N).
    //https://www.youtube.com/watch?v=bGC2fNALbNU&t=11s

    public class Subset
    {
        public void Test()
        {
            int[] givenArray = { 1, 2 };
            FindSubsets(givenArray);
        }

        static void FindSubsets(int[] givenArray)
        {
            //A temporary list for keeping the current subset  
            int[] sub = new int[givenArray.Length];
            Helper(givenArray, sub, 0);
            Console.ReadLine();
        }

        static void Helper(int[] givenArray, int[] sub, int index)
        {
            //if the position variable p has iterated all elements   
            if (index == givenArray.Length)
            {
                Console.WriteLine("Index is the same that given array lenght. Subset will be printed without zeros");
                //Print non zero elements  
                Console.Write("[");
                string s = "";
                for (int i = 0; i < givenArray.Length; i++)
                {
                    if (sub[i] != 0)
                    {
                        s += sub[i].ToString();

                    }
                }
                Console.Write(s);
                Console.Write("]");
                Console.WriteLine();
            }
            else
            {
                //Should we add the current index in the subset?
                //First choice (not adding the current index)
                sub[index] = 0;
                var msgToPrint = "";
                msgToPrint = "Not adding the current index in the subset";
                PrintIndexAndTemporarySubSet(msgToPrint, index, sub, givenArray);
                Helper(givenArray, sub, index + 1);
                //Second choice (adding the current index)
                sub[index] = givenArray[index];
                msgToPrint = "Adding the current index in the subset";
                PrintIndexAndTemporarySubSet(msgToPrint, index, sub, givenArray);
                Helper(givenArray, sub, index + 1);
            }
        }

        static void PrintIndexAndTemporarySubSet(string msgToPrint, int currentIndex, int[] sub, int[] givenArray)
        {
            Console.WriteLine("Current value: " + givenArray[currentIndex]);
            Console.WriteLine(msgToPrint);
            Console.Write("Temporary Subset:");
            Console.Write("[");
            foreach (var s in sub)
            {
                Console.Write(s);
            }
            Console.Write("]");
            Console.WriteLine();
        }
    }
}
