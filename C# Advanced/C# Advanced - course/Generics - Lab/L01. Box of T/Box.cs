using System;
using System.Collections.Generic;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> items;

        public int Count { get { return items.Count; } }

        public Box()
        {
            this.items = new List<T>();
        }

        public void Add(T element)
        { 
            items.Add(element);
        }

        public T Remove()
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("The box is empty.");
            }

            T elementForRemove = items[items.Count - 1];
            items.RemoveAt(items.Count - 1);
            return elementForRemove;
        }
       

    }
}
