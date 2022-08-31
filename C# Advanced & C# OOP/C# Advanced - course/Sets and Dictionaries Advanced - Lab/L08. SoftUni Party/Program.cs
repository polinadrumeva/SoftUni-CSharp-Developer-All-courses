using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace L08._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vipguest = new HashSet<string>();
            HashSet<string> guests = new HashSet<string>();
            string patternVIP = @"\d{1}[A-Za-z0-9]{7}";
            string patternGuest = @"[A-Za-z]{1}[A-Za-z0-9]{7}";



            string command;
            while ((command = Console.ReadLine()) != "PARTY")
            {
                Match matchVIP = Regex.Match(command, patternVIP);
                if (matchVIP.Success)
                {
                    vipguest.Add(command);
                }

                Match matchGuest = Regex.Match(command, patternGuest);
                if (matchGuest.Success)
                {
                    guests.Add(command);
                }
            }

            string guest;
            while ((guest = Console.ReadLine()) != "END")
            {
                if (vipguest.Contains(guest))
                {
                    vipguest.Remove(guest);
                }
                else if (guests.Contains(guest))
                {
                    guests.Remove(guest);
                }
            }

            Console.WriteLine(vipguest.Count + guests.Count);
            foreach (var item in vipguest)
            {
                Console.WriteLine(item);
            }
            foreach (var person in guests)
            {
                Console.WriteLine(person);
            }

        }
    }
}
