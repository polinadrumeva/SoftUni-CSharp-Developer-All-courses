using System;

namespace CustomQueue_Class
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomQueue customQueue = new CustomQueue();
            customQueue.Enqueue(10);
            customQueue.Enqueue(20);
            customQueue.Enqueue(30);
            customQueue.Enqueue(40);

            customQueue.Print();
            customQueue.Dequeue();
            customQueue.Print();

            Console.WriteLine(customQueue.Peek());
            customQueue.Print();

            customQueue.Clear();
            customQueue.Print();

            customQueue.ForEach();
            customQueue.Print();

            customQueue.Enqueue(10);
            customQueue.Enqueue(20);
            customQueue.Enqueue(30);
            customQueue.Enqueue(10);
            customQueue.Print();

            Console.WriteLine(customQueue.Count);
        }
    }
}
