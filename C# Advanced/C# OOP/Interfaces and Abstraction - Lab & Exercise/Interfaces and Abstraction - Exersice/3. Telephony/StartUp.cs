using System;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split(' ').ToArray();
            string[] sites = Console.ReadLine().Split(' ').ToArray();

            foreach (string number in phoneNumbers)
            {
                if (number.Length == 10)
                {
                    TheSmartphone newsmartphone = new TheSmartphone();
                    Console.WriteLine(newsmartphone.Call(number));
                }
                else if (number.Length == 7)
                { 
                    TheStationaryPhone newstationary = new TheStationaryPhone();
                    Console.WriteLine(newstationary.Call(number));
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }

            foreach (var site in sites)
            {
                TheSmartphone newphone = new TheSmartphone();
                Console.WriteLine(newphone.SearchWeb(site));
            }
        }
    }
}
