using System;
using System.Collections.Generic;
using System.Linq;

namespace DragonArmy
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfDragons = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int[]>> dragonsInfo = new Dictionary<string, Dictionary<string, int[]>>();
            var info = new string[] { "damage: ", "health: ", "armor: " };
            for (int i = 0; i < numberOfDragons; i++)
            {
                string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string type = input[0];
                string name = input[1];
                if (input[2] == "null")
                {
                    input[2] = "45";
                }
                if (input[3] == "null")
                {
                    input[3] = "250";
                }
                if (input[4] == "null")
                {
                    input[4] = "10";
                }
                int damage = int.Parse(input[2]);
                int health = int.Parse(input[3]);
                int armor = int.Parse(input[4]);
                if (!dragonsInfo.ContainsKey(type))
                {
                    dragonsInfo.Add(type, new Dictionary<string, int[]>());
                }
                if (!dragonsInfo[type].ContainsKey(name))
                {
                    dragonsInfo[type].Add(name, new int[3]);
                }
                dragonsInfo[type][name][0] = damage;
                dragonsInfo[type][name][1] = health;
                dragonsInfo[type][name][2] = armor;
            }
            var add = new List<string>();
            foreach (var item in dragonsInfo)
            {
                string b = "";
                int counter = 0;
                double damage = 0.00;
                double health = 0.00;
                double armor = 0.00;
                foreach (var dragon in item.Value)
                {
                    damage += dragon.Value[0];
                    health += dragon.Value[1];
                    armor += dragon.Value[2];
                    counter++;
                }
                damage = damage / counter;
                damage = Math.Round(damage, 2);
                health = health / counter;
                armor = armor / counter;
                b = "::(" + String.Format("{0:0.00}", damage) + "/" + String.Format("{0:0.00}", health) + "/" + String.Format("{0:0.00}", armor) + ")";
                add.Add(b);
            }
            int count = 0;
            foreach (var item in dragonsInfo)
            {
                Console.WriteLine(item.Key + add[count]);
                foreach (var dragons in item.Value.OrderBy(x => x.Key))
                {
                    Console.Write("-" + dragons.Key + " -> ");
                    for (int i = 0; i < dragons.Value.Length; i++)
                    {
                        if (i == dragons.Value.Length - 1)
                        {
                            Console.Write(info[i] + dragons.Value[i]);
                        }
                        else
                        {
                            Console.Write(info[i] + dragons.Value[i] + ", ");
                        }
                    }
                    Console.WriteLine();
                }
                count++;
            }
        }
    }
}