using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures_Algorithms.Data_Structures.Stacks
{
    internal class TwoStackQueue
    {

        //    STDIN   Function
        //-----   --------
        //1 42    1st query, enqueue 42
        //2       dequeue front element
        //1 14    enqueue 42
        //3       print the front element
        //1 28    enqueue 28
        //3       print the front element
        //1 60    enqueue 60
        //1 78    enqueue 78
        //2       dequeue front element
        //2       dequeue front element

        public void Test()
        {
            List<int[]> functions = new List<int[]>
            {
                new int[] { 1, 42 },
                new int[] { 2 },
                new int[] { 1, 14 },
                new int[] { 3 },
                new int[] { 1, 28 },
                new int[] { 3 },
                new int[] { 1, 60 },
                new int[] { 1, 78 },
                new int[] { 2 },
                new int[] { 2 }
            };
            CreateTwoStackQueue(functions);
        }


        //A queue is a data structure that follows the First In, First Out (FIFO) principle, while a stack
        // follows the Last In, First Out (LIFO) principle. To implement a queue using two stacks,
        // you can use one stack to handle incoming elements (stack1) and another stack to handle
        // outgoing elements (stack2)
        public static void CreateTwoStackQueue(List<int[]> functions)
        {
            Stack<int> stk1 = new Stack<int>();
            Stack<int> stk2 = new Stack<int>();

            int length;

            foreach (int[] function in functions)
            {
                var type = function[0];
                if (type == 1)
                {
                    stk1.Push(function[1]);
                    Console.WriteLine("Enqueue element " + function[1]);
                }
                else if (type == 2)
                {
                    length = stk1.Count;
                    if (stk2.Count == 0)
                    {
                        for (int j = 0; j < length; j++)
                        {
                            stk2.Push(stk1.Pop());
                        }
                    }
                    var removed = stk2.Pop();
                    Console.WriteLine("Dequeue element " + removed);
                }
                else
                {
                    length = stk1.Count;
                    if (stk2.Count == 0)
                    {
                        for (int j = 0; j < length; j++)
                        {
                            stk2.Push(stk1.Pop());
                        }
                    }
                    Console.WriteLine("Printing the first element: " + stk2.Peek());
                }
            }
        }
    }
}
