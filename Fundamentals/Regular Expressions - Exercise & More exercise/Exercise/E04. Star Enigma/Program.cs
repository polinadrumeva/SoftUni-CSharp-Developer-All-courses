using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace E04._Star_Enigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\@(?<name>[A-Za-z]+)[^\@\-\!\:\>]*?\:(?<population>\d+)[^\@\-\!\:\>]*?\!(?<type>[A|D]{1})\![^\@\-\!\:\>]*?\-\>(?<soldierCount>\d+)";
            List<string> attckedPlanet = new List<string>();
            List<string> destroyedPlanet = new List<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string cryptMessage = Console.ReadLine();
                string decryptMessage = GetDecryptMessage(cryptMessage);

                Match matchesPlanet = Regex.Match(decryptMessage, pattern);
                if (matchesPlanet.Success)
                {
                    string planetName = matchesPlanet.Groups["name"].Value;
                    string typeAttack = matchesPlanet.Groups["type"].Value;
                    if (typeAttack == "A")
                    {
                        attckedPlanet.Add(planetName);
                    }
                    else if (typeAttack == "D")
                    { 
                        destroyedPlanet.Add(planetName);
                    }
                }
            }

            PrintAllPlanets(attckedPlanet, destroyedPlanet);
        }

        static void PrintAllPlanets(List<string> attackedPlanet, List<string> destroyedPlanet)
        {
            Console.WriteLine($"Attacked planets: {attackedPlanet.Count}");
            foreach (string planetName in attackedPlanet.OrderBy(x=> x))
            {
                Console.WriteLine($"-> {planetName}");
            }
            Console.WriteLine($"Destroyed planets: {destroyedPlanet.Count}");
            foreach (string planetName in destroyedPlanet.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planetName}");
            }

        }

        static string GetDecryptMessage(string cryptMessage)
        {
            StringBuilder decryptMessage = new StringBuilder();
            int keyCount = GetDecryptKey(cryptMessage);
            foreach (char currentChar in cryptMessage)
            {
                char newChar = (char)(currentChar - keyCount);
                decryptMessage.Append(newChar);
            }

            return decryptMessage.ToString();   
        }

        static int GetDecryptKey(string cryptMessage)
        {
            string keyPattern = @"[star]{1}";
            MatchCollection keysInfo = Regex.Matches(cryptMessage, keyPattern, RegexOptions.IgnoreCase);
            return keysInfo.Count;
        }
    }
}
