using System;

namespace CustomList_Class
{
    public class List
    {
        private int[] items;

        public List()
        {
            items = new int[2];
        }

        public int Count { get; private set; }
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

        public void Add(int element)
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

        public void Print()
        {
            Console.WriteLine(string.Join(" ", items));
        }

        public int RemoveAt(int index)
        {
            int returnedElement = items[index];
            items[index] = 0;

            for (int i = index; i < Count; i++)
            {
                items[i] = items[i + 1];
            }
            Count--;

            if (Count <= items.Length / 4)
            {
                int[] tempArray = new int[items.Length / 2];
                for (int i = 0; i < Count; i++)
                {
                    tempArray[i] = items[i];
                }

                items = tempArray;
            }

            return returnedElement;
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == element)
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            if (firstIndex < 0 || firstIndex >=Count || secondIndex < 0 || secondIndex >=Count)
            {
                throw new IndexOutOfRangeException();
            }

            int current = items[firstIndex];
            items[firstIndex] = items[secondIndex]; 
            items[secondIndex] = current;   
        }


    }
}
