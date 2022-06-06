using System;
using System.Collections.Generic;
using System.Text;

namespace E09.PokemonTrainer
{
    public class Trainer
    {
        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> CollectionOfPokemons { get; set; }

        public Trainer(string trainerName, int numberOfBadges, List<Pokemon> pokemons)
        {
            this.Name = trainerName;
            this.NumberOfBadges = numberOfBadges;
            this.CollectionOfPokemons = pokemons;
        }
    }
}
