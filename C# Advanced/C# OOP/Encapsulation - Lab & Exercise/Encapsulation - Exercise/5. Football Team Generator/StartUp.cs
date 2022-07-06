using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
           List<Team> teams = new List<Team>();
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] data = command.Split(";", StringSplitOptions.RemoveEmptyEntries);
                    string cmdType = data[0];
                    string teamName = data[1];
                    if (cmdType == "Team")
                    {
                        Team team = new Team(teamName);
                        teams.Add(team);
                    }
                    else if (cmdType == "Add")
                    {
                        string playerName = data[2];
                       
                        Team teamToExist = teams.FirstOrDefault(x => x.Name == teamName);
                        if (teamToExist == null)
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }

                        int endurance = int.Parse(data[3]);
                        int sprint = int.Parse(data[4]);
                        int dribble = int.Parse(data[5]);
                        int passing = int.Parse(data[6]);
                        int shooting = int.Parse(data[7]);
                        Stats newStats = new Stats(endurance, sprint, dribble, passing, shooting);
                        Player newPlayer = new Player(playerName, newStats);
                        teamToExist.AddPlayer(newPlayer);
                    }
                    else if (cmdType == "Remove")
                    {
                        string playerName = data[2];
                        Team teamToRemove = teams.FirstOrDefault(x => x.Name == teamName);
                        if (teamToRemove == null)
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }
                        teamToRemove.RemovePlayer(playerName);
                    }
                    else if (cmdType == "Rating")
                    {
                        Team teamToRating = teams.FirstOrDefault(x => x.Name == teamName);
                        if (teamToRating == null)
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }

                        Console.WriteLine(teamToRating);
                    }

                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("A name should not be empty.");
                }
              
            }
        }
    }
}
