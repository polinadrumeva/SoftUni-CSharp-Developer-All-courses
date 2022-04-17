using System;
using System.Linq;

namespace ME03._Treasure_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] key = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            string line;
            while ((line = Console.ReadLine()) != "find")
            {
                string texts = line;
                string decryptText = string.Empty;
                int count = 0;
                bool isTurned = false;

                for (int i = 0; i < texts.Length; i++)
                {
                    for (int k = 0; k < key.Length; k++)
                    {
                        decryptText += (char)((int)texts[i] - key[k]);
                        count++;

                        if (count == key.Length)
                        {
                            k = -1;
                            count = 0;
                        }
                        if (i == texts.Length - 1)
                        {
                            isTurned = true;
                            break;
                        }
                        else
                        {
                            i++;
                        }

                    }

                    if (isTurned)
                    {
                        isTurned = false;
                        break;
                    }
                }

                int indexType = decryptText.LastIndexOf("&") - decryptText.IndexOf("&");
                string typesMaterial = decryptText.Substring(decryptText.IndexOf("&"), indexType).Replace("&", "").Trim();
                int indexCordinate = decryptText.IndexOf(">") - decryptText.IndexOf("<");
                string coordinate = decryptText.Substring(decryptText.IndexOf("<"), indexCordinate).Replace("<", "").Trim();

                Console.WriteLine($"Found {typesMaterial} at {coordinate}");
            }


        }
    }
}
