using System;

namespace Custom_Doubly_Linked_List
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var list = new DoublyLinkedList();
            list.AddFirst(1);
            list.AddFirst(2);
            list.AddFirst(3);
            Console.WriteLine(string.Join(" ", list.ToArray()));

            list.AddLast(4);
            list.AddLast(10);
            Console.WriteLine(string.Join(" ", list.ToArray()));

            Console.WriteLine(list.RemoveLast());

            Console.WriteLine(list.RemoveFirst());

            list.ForEach(x => Console.WriteLine(x));

            Console.WriteLine(string.Join(", ",list.ToArray()));



        }
    }
}
