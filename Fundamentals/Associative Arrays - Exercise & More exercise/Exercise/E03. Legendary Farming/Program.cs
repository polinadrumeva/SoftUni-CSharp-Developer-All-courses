using System;
using System.Collections.Generic;
using System.Linq;

namespace E03._Legendary_Farming
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int minQuantity = 250;

            Dictionary<string, int> keyMaterials = new Dictionary<string, int>()
            {
                {"shards", 0},
                {"motes", 0},
                {"fragments", 0}
                
            };
            Dictionary<string, string> craftsTable = new Dictionary<string, string>()
            {
                {"shards", "Shadowmourne"},
                {"fragments", "Valanyr"},
                {"motes", "Dragonwrath"}
            };
            Dictionary<string, int> junks = new Dictionary<string, int>();
            string obtainItem = string.Empty;

            while (String.IsNullOrEmpty(obtainItem))
            {
                string materialsLine = Console.ReadLine().ToLower();
                string[] materials = materialsLine.Split().ToArray();

                for (int i = 0; i < materials.Length; i+=2)
                {
                    int quantity = int.Parse(materials[i]);
                    string material = materials[i + 1];

                    if (keyMaterials.ContainsKey(material))
                    {
                        keyMaterials[material] += quantity;

                        if (keyMaterials[material] >= minQuantity)
                        {
                            obtainItem = craftsTable[material];
                            keyMaterials[material] -= minQuantity;
                            break;
                        }
                    }
                    else
                    {
                        if (!junks.ContainsKey(material))
                        {
                            junks[material] = 0;
                        }
                        junks[material] += quantity;
                    }
                }
            }

            Console.WriteLine($"{obtainItem} obtained!");

            foreach (var item in keyMaterials)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            foreach (var item in junks)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
