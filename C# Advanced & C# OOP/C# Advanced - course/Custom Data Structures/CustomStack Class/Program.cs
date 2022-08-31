using System;

namespace CustomStack_Class
{
    internal class Program
    {
        static void Main(string[] args)
        {
           CustomStack stack = new CustomStack();

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            stack.Print();

            stack.Pop();

            stack.Print();

            Console.WriteLine(stack.Peek());

            stack.ForEach();

            Console.WriteLine(stack.Count);
        }
    }
}
