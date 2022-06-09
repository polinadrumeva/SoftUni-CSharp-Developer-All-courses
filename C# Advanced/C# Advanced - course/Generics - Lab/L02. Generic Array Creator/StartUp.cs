using System;

namespace L02._Generic_Array_Creator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] strings = ArrayCreator.Create(5, "Pesho");
            int[] integers = ArrayCreator.Create(5, 33);

            Console.WriteLine(string.Join(" ", integers));

        }
    }
}
