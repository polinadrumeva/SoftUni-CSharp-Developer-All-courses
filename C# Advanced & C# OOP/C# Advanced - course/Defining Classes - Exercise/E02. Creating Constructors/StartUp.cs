using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            Person person1 = new Person(3);
            Person person2 = new Person("Maria", 4);

            Console.WriteLine($"First person: {person.Name}; Age: {person.Age}");
            Console.WriteLine($"Second person: {person1.Name}; Age: {person1.Age}");
            Console.WriteLine($"Third person: {person2.Name}; Age: {person2.Age}");
        }
    }
}
