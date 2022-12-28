using System;

namespace Data_Structures_Algorithms.Data_Structures
{
    public class BinaryHeapPriorityQueue
    {
        public void Test()
        {
                     /*45
                    /     \
                   31      14
                  / \     / \
                13  20   7   11
               / \
              12  7

            Create a priority queue shown in example in a binary max heap.
            Queue as an array: 45 31 14 13 20 7 11 12 7 */

            // Insert the element to the priority queue
            Insert(45);
            Insert(20);
            Insert(14);
            Insert(12);
            Insert(31);
            Insert(7);
            Insert(11);
            Insert(13);
            Insert(7);

            int i = 0;

            // Priority queue before extracting max
            Console.Write("Priority Queue : ");
            while (i <= size)
            {
                Console.Write(heap[i] + " ");
                i++;
            }

            Console.Write("\n");

            // Node with maximum priority
            Console.Write("Node with maximum priority : " + ExtractMax() + "\n");

            // Priority queue after extracting max
            Console.Write("Priority queue after extracting maximum : ");
            int j = 0;

            while (j <= size)
            {
                Console.Write(heap[j] + " ");
                j++;
            }

            Console.Write("\n");

            // Change the priority of element
            // present at index 2 to 49
            ChangePriority(2, 49);
            Console.Write("Priority queue after priority change : ");

            int k = 0;
            while (k <= size)
            {
                Console.Write(heap[k] + " ");
                k++;
            }

            Console.Write("\n");

            // Remove element at index 3
            Remove(3);
            Console.Write("Priority queue after removing the element : ");
            int l = 0;
            while (l <= size)
            {
                Console.Write(heap[l] + " ");
                l++;
            }
        }

        static int[] heap = new int[50];
        static int size = -1;

        // Function to return the index of the parent node of a given node
        static int GetIndexParent(int i)
        {
            return (i - 1) / 2;
        }

        // Function to return the index of the left child of the given node
        static int LeftChild(int i)
        {
            return ((2 * i) + 1);
        }

        // Function to return the index of the right child of the given node
        static int RightChild(int i)
        {
            return ((2 * i) + 2);
        }

        // Function to shift up the node in order to maintain the heap property
        static void ShiftUp(int i)
        {
            while (i > 0 && heap[GetIndexParent(i)] < heap[i])
            {
                // Swap parent and current node
                Swap(GetIndexParent(i), i);

                // Update i to parent of i
                i = GetIndexParent(i);
            }
        }

        // Function to shift down the node in order to maintain the heap property
        static void ShiftDown(int i)
        {
            int maxIndex = i;

            // Left Child
            int l = LeftChild(i);

            if (l <= size && heap[l] > heap[maxIndex])
            {
                maxIndex = l;
            }

            // Right Child
            int r = RightChild(i);

            if (r <= size &&
                heap[r] > heap[maxIndex])
            {
                maxIndex = r;
            }

            // If i not same as maxIndex
            if (i != maxIndex)
            {
                Swap(i, maxIndex);
                ShiftDown(maxIndex);
            }
        }

        // Function to insert a new element in the Binary Heap
        static void Insert(int p)
        {
            size++;
            heap[size] = p;

            // Shift Up to maintain heap property
            ShiftUp(size);
        }

        // Function to extract the element with maximum priority
        static int ExtractMax()
        {
            int result = heap[0];

            // Replace the value at the root with the last leaf
            heap[0] = heap[size];
            size--;

            // Shift down the replaced element to maintain the heap property
            ShiftDown(0);
            return result;
        }

        // Function to change the priority of an element
        static void ChangePriority(int index, int newPriority)
        {
            int oldpriority = heap[index];
            heap[index] = newPriority;

            if (newPriority > oldpriority)
                ShiftUp(index);
            else
                ShiftDown(index);
        }

        // Function to get value of the current maximum element
        static int GetMax()
        {
            return heap[0];
        }

        // Function to remove the element located at given index
        static void Remove(int i)
        {
            Console.WriteLine($"Will remove the {heap[i]} element");
            heap[i] = GetMax() + 1;

            // Shift the node to the root of the heap
            ShiftUp(i);

            // Extract the node
            ExtractMax();
        }

        static void Swap(int i, int j)
        {
            int temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }
    }

    //Time Complexity: All the operation is O(log N) except for GetMax() which
    //has time complexity of O(1). 
    //Auxiliary Space: O(N)
}
