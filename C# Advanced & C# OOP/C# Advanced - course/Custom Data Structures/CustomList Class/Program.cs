using System;

namespace CustomList_Class
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List list = new List();

            list.Add(10);
            list.Add(20);
            list.Add(30);
            list.Print();


            list.RemoveAt(0);

            list.Print();

            
            Console.WriteLine(list.Contains(30));

            list.Swap(0, 1);
            list.Print();

            Console.WriteLine(list.Count);

        }
    }
}
