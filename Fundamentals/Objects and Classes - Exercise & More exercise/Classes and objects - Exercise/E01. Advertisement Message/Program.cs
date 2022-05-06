using System;
using System.Collections.Generic;

namespace Е01._Advertisement_Message
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> phrases = new List<string> { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product." };
            List<string> events = new List<string> { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };
            List<string> authors = new List<string> { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            List<string> cities = new List<string> { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            int numberOfRotation = int.Parse(Console.ReadLine());
            Random random = new Random();
            for (int i = 0; i < numberOfRotation; i++)
            {
                int randomPhrases = random.Next(0, phrases.Count - 1);
                int randomEvents = random.Next(0, events.Count - 1);
                int randomAutors = random.Next(0, authors.Count - 1);
                int randomCities = random.Next(0, cities.Count - 1);
                Console.WriteLine($"{phrases[randomPhrases]} {events[randomEvents]} {authors[randomAutors]} - {cities[randomCities]}.");
            }

        }
    }
}
