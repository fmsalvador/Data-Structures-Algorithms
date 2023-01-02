using System;
using System.Collections.Generic;

namespace Data_Structures_Algorithms.Data_Structures
{
    public class CircularQueue
    {
        public CircularQueue() { }
        public void Test()
        {
            CircularQueue q = new CircularQueue(5);
            q.EnQueue(14);
            q.EnQueue(22);
            q.EnQueue(13);
            q.EnQueue(-6);
            q.DisplayQueue();

            int element = q.DeQueue();

            // Checking for empty queue.
            if (element != -1)
            {
                Console.Write("Deleted value = ");
                Console.Write(element + "\n");
            }

            element = q.DeQueue();

            // Checking for empty queue.
            if (element != -1)
            {
                Console.Write("Deleted value = ");
                Console.Write(element + "\n");
            }

            q.DisplayQueue();

            q.EnQueue(9);
            q.EnQueue(20);
            q.EnQueue(5);
            q.DisplayQueue();
            q.EnQueue(20);
        }

        private int size, front, rear;

        // Declaring array list of integer type.
        private List<int> queue = new List<int>();

        // Constructor
        CircularQueue(int size)
        {
            this.size = size;
            this.front = this.rear = -1;
        }

        // Method to insert a new element in the queue.
        public void EnQueue(int data)
        {
            // Condition if queue is full.
            if ((front == 0 && rear == size - 1) ||
              (rear == (front - 1) % (size - 1)))
            {
                Console.Write("Queue is Full");
            }

            // condition for empty queue.
            else if (front == -1)
            {
                front = 0;
                rear = 0;
                queue.Add(data);
            }

            else if (rear == size - 1 && front != 0)
            {
                rear = 0;
                queue[rear] = data;
            }

            else
            {
                rear++;

                //Adding a new element
                if (front <= rear)
                    queue.Add(data);

                //Updating old value
                else
                    queue[rear] = data;
            }
        }

        // Function to dequeue an element form the queue
        public int DeQueue()
        {
            int temp;

            // Condition for empty queue.
            if (front == -1)
            {
                Console.Write("Queue is Empty");

                // Return -1 in case of empty queue
                return -1;
            }

            temp = queue[front];

            // Condition for only one element
            if (front == rear)
            {
                front--;
                rear--;
            }

            else if (front == size - 1)
                front = 0;
            else
                front++;

            // Returns the dequeued element
            return temp;
        }

        // Method to display the elements of queue
        public void DisplayQueue()
        {

            // Condition for empty queue.
            if (front == -1)
            {
                Console.Write("Queue is Empty");
                return;
            }

            // If rear has not crossed the max size
            // or queue rear is still greater then
            // front.
            Console.Write("Elements in the circular queue are: ");

            if (rear >= front)
            {
                // Loop to print elements from
                // front to rear.
                for (int i = front; i <= rear; i++)
                {
                    Console.Write(queue[i]);
                    Console.Write(" ");
                }
                Console.Write("\n");
            }

            // If rear crossed the max index and indexing has started in loop
            else
            {
                // Loop for printing elements from
                // front to max size or last index
                for (int i = front; i < size; i++)
                {
                    Console.Write(queue[i]);
                    Console.Write(" ");
                }

                // Loop for printing elements from
                // 0th index till rear position
                for (int i = 0; i <= rear; i++)
                {
                    Console.Write(queue[i]);
                    Console.Write(" ");
                }
                Console.Write("\n");
            }
        }

        //Time complexity of enQueue(), deQueue() operation is O(1) as there is no loop in any of the operation.
    }
}
