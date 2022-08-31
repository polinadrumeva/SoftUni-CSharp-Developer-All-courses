using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Citizens : ISociety, IBirthday, IBuyer
    {
        private const int foodCitizenIncrease = 10;
        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
        public string BirthdayDate { get; set; }
        public int Food { get; set; }

        public Citizens(string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.BirthdayDate = birthday;
            this.Food = 0;
        }

        public double BuyFood()
        {
            this.Food += foodCitizenIncrease;
            return foodCitizenIncrease;
        }
    }
}
