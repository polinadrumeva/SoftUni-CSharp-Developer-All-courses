using System;
using System.Collections.Generic;
using System.Linq;

namespace ME03._MOBA_Challenger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> rankList = new Dictionary<string, Dictionary<string, int>>();

            Dictionary<string, int> allPeople = new Dictionary<string, int>();

            Dictionary<string, string> namesAndPosition = new Dictionary<string, string>();

            string command;
            while ((command = Console.ReadLine()) != "Season end")
            {
                string[] commands = command.Split().ToArray();
                if (!commands.Contains("vs"))
                {
                    string[] rangs = command.Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string player = rangs[0];
                    string position = rangs[1];
                    int skill = int.Parse(rangs[2]);

                    if (!rankList.ContainsKey(player))
                    {
                        rankList.Add(player, new Dictionary<string, int>());
                        rankList[player].Add(position, skill);
                        allPeople.Add(player, skill);
                        namesAndPosition.Add(player, position);
                    }
                    else
                    {
                        rankList[player].Add(position, skill);

                        if (rankList[player][position] < skill)
                        {
                            rankList[player][position] = skill;
                        }

                        allPeople[player] += skill;
                    }

                    continue;
                }

                string[] fight = command.Split().ToArray();
                string firstPlayer = fight[0];
                string secondPlayer = fight[2];

                if (rankList.ContainsKey(firstPlayer) && rankList.ContainsKey(secondPlayer))
                {
                      bool isFirstRemove = false; 
                      bool isSecondRemove = false;

                        foreach (var first in rankList[firstPlayer])
                        {
                            foreach (var second in rankList[secondPlayer])
                            {
                                if (first.Key == second.Key)
                                {
                                    if (first.Value > second.Value)
                                    {
                                        isSecondRemove = true;
                                    }
                                    else
                                    {
                                        isFirstRemove = true;
                                    }
                                }
                            }

                            if (isSecondRemove)
                            {
                                allPeople.Remove(secondPlayer);
                                rankList.Remove(secondPlayer);
                                isSecondRemove = false;
                            }
                            else if (isFirstRemove)
                            {
                                allPeople.Remove(firstPlayer);
                                rankList.Remove(firstPlayer);
                                isFirstRemove = false;
                            }
                        }

                }

            }

            foreach (var item in allPeople.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value} skill");

                foreach (var rank in rankList)
                {
                    foreach (var other in rank.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                    {
                        if (item.Key == rank.Key)
                        {
                            Console.WriteLine($"- {other.Key} <::> {other.Value}");
                        }

                    }
                }


            }
        }
    }
}
