using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace E05._Nether_Realms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string demons = Console.ReadLine();
            Dictionary<string, List<double>> listOfDemons = new Dictionary<string, List<double>>(); 

            string[] arrDemons = demons.Split(new char[] {',',' '}, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < arrDemons.Length; i++)
            {
                string currentDemon = arrDemons[i];
                string name = currentDemon;
                listOfDemons.Add(name, new List<double>());

                string healthPattern = @"[^0-9\+\-\*\/\.]";
                double health = 0;
                string healthbattery = string.Empty;
                MatchCollection machtesHealth = Regex.Matches(currentDemon, healthPattern);
                foreach (Match m in machtesHealth)
                {
                    healthbattery += m.Value;
                }
                foreach (char item in healthbattery)
                {
                    health += (int)item;
                }

                string damagePattern = @"(\-\d+(\.\d+)?|\d+(\.\d+)?|\+\d+(\.\d+)?)";
                double damage = 0;
                MatchCollection mathesDamage = Regex.Matches(currentDemon, damagePattern);
                foreach (Match m in mathesDamage)
                { 
                    damage += double.Parse(m.Value);
                }

                foreach (char current in currentDemon)
                {
                    if (current == '*')
                    {
                        damage *= 2;
                    }
                    else if (current == '/')
                    { 
                        damage /= 2;
                    }
                }

                listOfDemons[name].Add(health);
                listOfDemons[name].Add(damage);
            }

            foreach (var item in listOfDemons.OrderBy(x => x.Key).ThenBy(x => x.Value))
            {
                  
                Console.WriteLine($"{item.Key} - {item.Value[0]} health, {item.Value[1]:f2} damage");
                
            }
        }
    }
}
