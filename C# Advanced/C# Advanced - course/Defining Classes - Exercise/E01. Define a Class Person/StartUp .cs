using System;


namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Name = "Peter";
            person.Age = 20;

            Console.WriteLine($"First: {person.Name} is {person.Age}-years old.");

            Person nextPerson = new Person();
            nextPerson.Name = "Georgi";
            nextPerson.Age = 18;

            Console.WriteLine($"First: {nextPerson.Name} is {nextPerson.Age}-years old.");
        }
    }
}
