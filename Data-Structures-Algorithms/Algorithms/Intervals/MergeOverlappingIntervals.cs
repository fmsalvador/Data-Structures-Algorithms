using System;
using System.Linq;

namespace Data_Structures_Algorithms.Algorithms
{
    public class MergeOverlappingIntervals
    {
        //Time complexity: O(N*log(N))
        //Auxiliary Space: O(1)
        public void Test()
        {
            //We have only two overlapping intervals here,[1,3] and [2, 4].Therefore we will merge these two and return [1, 4],[6,8], [9,10].
            Interval[] arr = new Interval[4];
            arr[0] = new Interval(6, 8);
            arr[1] = new Interval(1, 9);
            arr[2] = new Interval(2, 4);
            arr[3] = new Interval(4, 7);
            MergeIntervals(arr);
        }

        //sort the intervals in increasing order of start time
        public static void MergeIntervals(Interval[] arr)
        {
            // Sort Intervals in increasing order of
            // start time
            arr = arr.OrderBy(x => x.start).ToArray();

            int index = 0; // Stores index of last element
                           // in output array (modified arr[])

            // Traverse all input Intervals
            for (int i = 1; i < arr.Length; i++)
            {
                // If this is not first Interval and overlaps
                // with the previous one
                if (arr[index].end >= arr[i].start)
                {
                    // Merge previous and current Intervals
                    arr[index].end
                        = Math.Max(arr[index].end, arr[i].end);
                }
                else
                {
                    index++;
                    arr[index] = arr[i];
                }
            }

            // Now arr[0..index-1] stores the merged Intervals
            Console.WriteLine("The Merged Intervals are: ");
            for (int i = 0; i <= index; i++)
            {
                Console.WriteLine("[" + arr[i].start + ","
                                  + arr[i].end + "]");
            }
        }
    }

    public class Interval
    {
        public int start, end;
        public Interval(int start, int end)
        {
            this.start = start;
            this.end = end;
        }
    }
}

