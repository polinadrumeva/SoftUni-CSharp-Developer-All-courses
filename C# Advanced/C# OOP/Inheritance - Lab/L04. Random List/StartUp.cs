using System;

namespace L04._Random_List
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            var list = new RandomList();
            list.Add("10");
            list.Add("20");
            list.Add("30");
            list.Add("40");

            Console.WriteLine(list.GetRandomElement());
            Console.WriteLine(list.GetRandomElement());
            Console.WriteLine(list.GetRandomElement());
                

            list.RemoveRandomElement();
            Console.WriteLine(string.Join(", ", list));
        }
    }
}
