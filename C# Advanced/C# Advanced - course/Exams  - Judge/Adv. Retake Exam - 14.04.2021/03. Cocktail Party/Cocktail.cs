using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        public List<Ingredient> Ingredients { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }

        //	Getter CurrentAlcoholLevel – returns the amount of alcohol currently in the cocktail.
        public int CurrentAlcoholLevel { get { return Ingredients.Sum(x => x.Alcohol); } }

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            this.Ingredients = new List<Ingredient>();
            this.Name = name;
            this.Capacity = capacity;
            this.MaxAlcoholLevel = maxAlcoholLevel;
        }

        //  Method Add(Ingredient ingredient) - adds the entity if there isn't an Ingredient with the same name and if there is enough space in terms of quantity and alcohol.

        public void Add(Ingredient ingredient)
        {
            if (!Ingredients.Contains(ingredient) && Ingredients.Count + 1 <= Capacity && ingredient.Alcohol < this.MaxAlcoholLevel)
            {
                Ingredients.Add(ingredient);
            }
        }
        //	Method Remove(string name) - removes an Ingredient from the cocktail with the given name, if such exists and returns bool if the deletion is successful.

        public bool Remove(string name)
        {
            Ingredient ingredientsToRemove = Ingredients.FirstOrDefault(x => x.Name == name);
            if (ingredientsToRemove != null)
            {
                Ingredients.Remove(ingredientsToRemove);
                return true;
            }

            return false;
        }
        //	Method FindIngredient(string name) - returns an Ingredient with the given name.If it doesn't exist, return null.

        public Ingredient FindIngredient(string name)
        {
            Ingredient ingredientToFind = Ingredients.FirstOrDefault(x => x.Name == name);
            if (ingredientToFind != null)
            {
                return ingredientToFind;
            }

            return null;
        }
        //	Method GetMostAlcoholicIngredient() – returns the Ingredient with most Alcohol.

        public Ingredient GetMostAlcoholicIngredient()
        {
            int maxAlchohol = int.MinValue;
            foreach (var ingredient in Ingredients)
            {
                if (ingredient.Alcohol > maxAlchohol)
                {
                    maxAlchohol = ingredient.Alcohol;

                }
            }
            Ingredient mostAlcohol = Ingredients.First(x => x.Alcohol == maxAlchohol);
            return mostAlcohol;
        }
        

        //	Method Report() - returns information about the Cocktail and the Ingredients inside it in the following format:
        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Cocktail: {this.Name} - Current Alcohol Level: {this.CurrentAlcoholLevel}");

            foreach (var ingredient in Ingredients)
            {
                stringBuilder.AppendLine(ingredient.ToString());
            }

            return stringBuilder.ToString();
        }

    }
}

        