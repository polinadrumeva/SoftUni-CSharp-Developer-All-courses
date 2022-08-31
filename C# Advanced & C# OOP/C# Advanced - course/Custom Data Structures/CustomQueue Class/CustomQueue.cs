using System;

namespace CustomQueue_Class
{
    public class CustomQueue
    {
        private int[] items;
        private const int startingCapacity = 4;

        public int Count { get; set; }

        public CustomQueue()
        {
            items = new int[startingCapacity];
        }

        //	void Enqueue(int element) – Adds the given element to the queue
        public void Enqueue(int element)
        {
            if (Count == items.Length)
            {
                int[] tempArr = new int[items.Length * 2];
                for (int i = 0; i < items.Length; i++)
                {
                    tempArr[i] = items[i];
                }

                items = tempArr;
            }

            items[Count++] = element;
        }

        // void Print() - Print all element in the queue
        public void Print()
        {
            Console.WriteLine(string.Join(" ", items));
        }

        // int Dequeue() – Removes the first element

        public int Dequeue()
        {
            var firstElement = items[0];
            items[0] = 0;
            return firstElement;
        }

        //	int Peek() – Returns the first element in the queue without removing it
        public int Peek()
        { 
            var first = items[0];
            return first;
        }

        //	void Clear() – Delete all elements in the queue
        public void Clear()
        {
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = 0;
            }

            Console.WriteLine(string.Join(" ", items));
        }

        //	void ForEach(Action<int> action) – Goes through each of the elements in the queue
        public void ForEach()
        {
            for (int i = 0; i < items.Length; i++)
            {
                Console.WriteLine(items[i]);
            }
        }

    }
}
