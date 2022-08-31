using System;
using System.Collections.Generic;
using System.Text;

namespace E02.GenericBoxofInteger
{
    public class Box<T>
    {
        public T Element { get; private set; }

        public Box(T element)
        {
            this.Element = element;
        }

        public override string ToString()
        {
            return $"{typeof(T)}: {Element}";
        }
    }
}
