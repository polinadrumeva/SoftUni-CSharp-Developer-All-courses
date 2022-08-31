namespace CollectionHierarchy
{
    using System;
    using Models.Interfaces;
    using Models;
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ');
            int operationCount = int.Parse(Console.ReadLine());

            IAddCollection<string> addCollection = new AddCollection<string>();
            IAddRemoveCollection<string> addRemoveCollection = new AddRemoveCollection<string>();
            IMyList<string> myListCollection = new MyList<string>();

            foreach (var word in words)
            {
                Console.Write(addCollection.Add(word) + " ");
            }
            Console.WriteLine();

            foreach (var word in words)
            {
                Console.Write(addRemoveCollection.Add(word) + " ");
            }
            Console.WriteLine();

            foreach (var word in words)
            {
                Console.Write(myListCollection.Add(word) + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < operationCount; i++)
            {
                Console.Write(addRemoveCollection.Remove() + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < operationCount; i++)
            {
                Console.Write(myListCollection.Remove() + " ");
            }
            Console.WriteLine();


        }
    }
}
