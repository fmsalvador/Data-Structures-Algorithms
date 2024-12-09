using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures_Algorithms.Data_Structures.Stacks
{
    internal class LargestRectangleInArea
    {
        public void Test()
        {
            //Integer[] areas = {11, 11, 10, 10, 10};//50
            //Integer[] area = {1, 2, 3, 4, 5};//9
            int[] areas = { 2, 1, 5, 6, 2, 3 };//10;
            var maxArea = LargestRectangleArea(areas);
            Console.Write("Max rectangle is " + maxArea);
        }

        // 1 - Look at the height for a column.
        // 2 - If the height is greater than or equal to the first height at the top of the stack or if the stack is empty, push the height onto the stack.
        // 3 - Otherwise pop from the stack.  The maximum rectangular area that exists for this popped height is then calculated.
        // 4 - Continue to pop until the top stack height is less than the column height from step 1.
        static int LargestRectangleArea(int[] heights)
        {
            int n = heights.Length;
            Stack<int> heightsPositionStack = new Stack<int>();
            int maxArea = 0;

            // Traverse all bars of the histogram
            for (int i = 0; i < n; i++)
            {
                // Process the stack while the current element 
                // is smaller than the element corresponding to 
                // the top of the stack
                while (heightsPositionStack.Count > 0 && heights[heightsPositionStack.Peek()] >= heights[i])
                {
                    var topHeight = heightsPositionStack.Pop();
                    //Minus 1 to the get index of the current top height in stack
                    //Index i is the width we came across so far (this width does not include the element
                    //that we are iterating now)
                    //The width is determined by the difference between the current index and the new top of the stack.
                    int width = heightsPositionStack.Count == 0 ? i : i - heightsPositionStack.Peek() - 1;
                    int lastMaxAreaCalculated = heights[topHeight] * width;
                    maxArea = Math.Max(maxArea, lastMaxAreaCalculated);
                }
                heightsPositionStack.Push(i);
            }
            return maxArea;
        }
    }
}
