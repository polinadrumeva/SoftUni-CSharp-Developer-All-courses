using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ME01._Winning_Ticket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            
            Dictionary<string, List<string>> tickets = new Dictionary<string, List<string>>();
            int count = 0;

            string[] lottaryTickets = input.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < lottaryTickets.Length; i++)
            {
                string charSymbolSuccess = string.Empty;

                for (int l = 0; l < lottaryTickets[i].Length/2; l++)
                {
                    if (lottaryTickets[i][l] == '@' || lottaryTickets[i][l] == '#'|| lottaryTickets[i][l] == '$' || lottaryTickets[i][l] == '^')
                    {
                        count++;
                    }
                }
                int matches = count;

                for (int k = lottaryTickets[i].Length / 2; k < lottaryTickets[i].Length; k++)
                {
                    if (lottaryTickets[i][k] == '@' || lottaryTickets[i][k] == '#' || lottaryTickets[i][k] == '$' || lottaryTickets[i][k] == '^')
                    {
                        charSymbolSuccess = lottaryTickets[i][k].ToString();
                        count--;
                    }
                }
                if (lottaryTickets[i].Length != 20)
                {
                    tickets.Add(lottaryTickets[i], new List<string>());
                    tickets[lottaryTickets[i]].Add("invalid");
                }
                else 
                {
                    if (count == 0)
                    {
                        if (matches >= 6 && matches <= 10)
                        {
                            tickets.Add(lottaryTickets[i], new List<string>());
                            tickets[lottaryTickets[i]].Add(matches.ToString());
                            tickets[lottaryTickets[i]].Add(charSymbolSuccess);
                        }
                        else
                        {
                            tickets.Add(lottaryTickets[i], new List<string>());
                            tickets[lottaryTickets[i]].Add("no match");
                        }
                    }
                    else
                    {
                        tickets.Add(lottaryTickets[i], new List<string>());
                        tickets[lottaryTickets[i]].Add("no match");
                    }

                }
               

                matches = 0;
            }

            foreach (var item in tickets)
            {
                if (item.Value[0] == "invalid")
                {
                    Console.WriteLine("invalid ticket");
                }
                else if (item.Value[0] == "no match")
                {
                    Console.WriteLine($"ticket \"{item.Key}\" - no match");
                }
                else if (int.Parse(item.Value[0]) >=6 && int.Parse(item.Value[0]) < 10)
                {
                    Console.WriteLine($"ticket \"{item.Key}\" - {item.Value[0]}{item.Value[1]}");
                }
                else if (int.Parse(item.Value[0]) == 10)
                {
                    Console.WriteLine($"ticket \"{item.Key}\" - {item.Value[0]}{item.Value[1]} Jackpot!");
                }
                
            }

        }
    }
}
