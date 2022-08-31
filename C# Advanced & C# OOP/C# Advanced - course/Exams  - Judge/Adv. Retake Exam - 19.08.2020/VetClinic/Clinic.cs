using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        // 	Field data – collection that holds added pets
        private List<Pet> data;
        public List<Pet> Pets { get; set; }
        public int Capacity { get; set; }

        //	Getter Count – returns the number of pets.
        public int Count { get { return Pets.Count; } }

        public Clinic(int capacity)
        {
            this.Pets = new List<Pet>();
            this.Capacity = capacity;
        }


        //	Method Add(Pet pet) – adds an entity to the data if there is an empty cell for the pet.
        public void Add(Pet pet)
        {
            if (!Pets.Contains(pet) && Pets.Count + 1 <= Capacity)
            {
                Pets.Add(pet);
            }
        }

        //	Method Remove(string name) – removes the pet by given name, if such exists, and returns bool.
        public bool Remove(string name)
        {
            Pet petToRemove = Pets.FirstOrDefault(x => x.Name == name);
            if (petToRemove != null)
            { 
                Pets.Remove(petToRemove);
                return true;
            }

            return false;
        }

        //	Method GetPet(string name, string owner) – returns the pet with the given name and owner or null if no such pet exists.
        public Pet GetPet(string name, string owner)
        { 
            Pet petToReturn = Pets.FirstOrDefault(x =>x.Name == name && x.Owner == owner);
            if (petToReturn != null)
            {
                return petToReturn;
            }

            return null;
        }
        //	Method GetOldestPet() – returns the oldest Pet.
        public Pet GetOldestPet()
        {
            int maxAge = Pets.Max(x => x.Age);
            Pet oldestPet = Pets.First(x => x.Age == maxAge);
            return oldestPet;
        }

        //	GetStatistics() – returns a string in the following format:
        public string GetStatistics()
        { 
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");
            foreach (var pet in Pets)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString();
        }

    }
}
