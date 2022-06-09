using System;
using System.Collections.Generic;

namespace L01._Box_of_T
{
    public class Box<T>
    {
        private List<T> items = new List<T>();

        public int Count { get; set; }

        public void Add(T element)
        { 
            items.Add(element);
        }

        public T Remove()
        {
            T elementForRemove = items[items.Count - 1];
            items.RemoveAt(items.Count - 1);
            return elementForRemove;
        }
        //        Create a class Box<> that can store anything.It should have two public methods:
        //•	void Add(element) – adds an element on the top of the list.
        //•	element Remove() – removes the topmost element.
        //•	int Count { get; }

    }
}
