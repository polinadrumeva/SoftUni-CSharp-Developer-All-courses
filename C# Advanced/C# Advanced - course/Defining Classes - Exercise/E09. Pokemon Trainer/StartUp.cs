using System;
using System.Collections.Generic;
using System.Linq;

namespace E09.PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

            string datas;
            while ((datas = Console.ReadLine()) != "Tournament")
            {
                string[] dataArgs = datas.Split(" ");
                string trainerName = dataArgs[0];
                string pokemonName = dataArgs[1];
                string pokemonElement = dataArgs[2];
                int pokemonHealth = int.Parse(dataArgs[3]);
                Pokemon newPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                Trainer newTrainer = new Trainer(trainerName, 0, new List<Pokemon>());
                
                if (trainers.ContainsKey(trainerName))
                {
                    trainers[trainerName].CollectionOfPokemons.Add(newPokemon);
                }
                else
                {
                    newTrainer.CollectionOfPokemons.Add(newPokemon);
                    trainers.Add(trainerName, newTrainer);
                }
                
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                trainers = CheckElements(command, trainers);
            }

            foreach (var trainer in trainers.OrderByDescending(x => x.Value.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Key} {trainer.Value.NumberOfBadges} {trainer.Value.CollectionOfPokemons.Count()}");
            }
        }

        public static Dictionary<string, Trainer> CheckElements(string command, Dictionary<string, Trainer> trainers)
        {
            bool isExist = false;
            switch (command)
            {
                case "Fire":
                    foreach (var trainer in trainers)
                    {
                        foreach (var pokemon in trainer.Value.CollectionOfPokemons)
                        {
                            if (pokemon.Element == "Fire")
                            {
                                trainer.Value.NumberOfBadges++;
                                isExist = true;
                                break;
                            }
                            
                        }
                        if (!isExist)
                        {
                            foreach (var pokemon in trainer.Value.CollectionOfPokemons)
                            {
                               
                                    pokemon.Health -= 10;
                                    if (pokemon.Health <= 0)
                                    {
                                        trainer.Value.CollectionOfPokemons.Remove(pokemon);
                                    }
                                
                            }
                        }

                        isExist = false;

                    }
                    break;
                case "Water":
                    foreach (var trainer in trainers)
                    {
                        foreach (var pokemon in trainer.Value.CollectionOfPokemons)
                        {
                            if (pokemon.Element == "Water")
                            {
                                trainer.Value.NumberOfBadges++;
                                isExist=true;
                                break;
                            }
                           
                        }
                        if (!isExist)
                        {
                            foreach (var pokemon in trainer.Value.CollectionOfPokemons)
                            {

                                pokemon.Health -= 10;
                                if (pokemon.Health <= 0)
                                {
                                    trainer.Value.CollectionOfPokemons.Remove(pokemon);
                                }

                            }
                        }

                        isExist = false;

                    }
                    break;
                case "Electricity":
                    foreach (var trainer in trainers)
                    {
                        foreach (var pokemon in trainer.Value.CollectionOfPokemons)
                        {
                            if (pokemon.Element == "Electricity")
                            {
                                trainer.Value.NumberOfBadges++;
                                isExist = true;
                                break;
                            }
                            
                        }
                        if (!isExist)
                        {
                            foreach (var pokemon in trainer.Value.CollectionOfPokemons)
                            {

                                pokemon.Health -= 10;
                                if (pokemon.Health <= 0)
                                {
                                    trainer.Value.CollectionOfPokemons.Remove(pokemon);
                                    break;
                                }

                            }
                        }

                        isExist = false;
                    }
                    break;

            }
            return trainers;
        }
    }
}
