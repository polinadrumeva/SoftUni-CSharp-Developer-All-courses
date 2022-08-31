using System;

namespace CustomStack_Class
{
    public class CustomStack
    {
        private int[] items;
        private const int InitialCapacity = 4;

        public CustomStack()
        {
            items = new int[InitialCapacity];
        }

        public int Count { get; set; }

        public int this[int i]
        {
            get
            {
                if (i < 0 || i >= Count)
                {
                    throw new IndexOutOfRangeException();
                }

                return items[i];
            }
            set
            {
                if (i < 0 || i >= Count)
                {
                    throw new IndexOutOfRangeException();
                }

                items[i] = value;
            }

        }

        // void Push(int element) – Adds the given element to the stack
        public void Push(int element)
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
        
        // void Print – Print all elements in the stack
        public void Print()
        {
            Console.WriteLine(string.Join(" ", items));
        }

        //	int Pop() – Removes the last added element
        public int Pop()
        {
            var current = 0;
            for (int i = items.Length - 1; i >= 0; i--)
            {
                if (items[i] != 0)
                {
                    current = items[i];
                    items[i] = 0;
                    break;
                }
            }

            return current;
        }

        //	int Peek() – Returns the last element in the stack without removing it
        public int Peek()
        {
            var lastElement = 0;
            for (int i = items.Length - 1; i >= 0; i--)
            {
                if (items[i] != 0)
                {
                    lastElement = items[i];
                    break;
                }
            }

            return lastElement;
        }

        // void ForEach(Action<int> action) – Goes through each of the elements in the stack
        public void ForEach()
        {
            for (int k = 0; k < items.Length; k++)
            {
                Console.WriteLine(items[k]);
            }
        }
        
    }
}
