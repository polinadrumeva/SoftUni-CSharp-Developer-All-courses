using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace E05.GenericCountMethodStrings
{
    public class Box<T> : IComparable<T> where T : IComparable<T>
    {
        public T Element { get; private set; }
        public List<T> Elements { get; private set; }

        public Box(T element)
        {
            this.Element = element;
        }

        public Box(List<T> elementsList)
        {
            this.Elements = elementsList;
        }

        public void Swap(List<T> elementsList, int indexOne, int indexTwo)
        {
            T firstElement = elementsList[indexOne];
            elementsList[indexOne] = elementsList[indexTwo];
            elementsList[indexTwo] = firstElement;

        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (T element in Elements)
            {
                sb.AppendLine($"{element.GetType()}: {element}");
            }

            return sb.ToString().TrimEnd();
        }

        public int CompareTo(T other) => Element.CompareTo(other);

        public int Count<T>(List<T> list, T readLine) where T : IComparable => list.Count(word => word.CompareTo(readLine) > 0); 
    }
}
