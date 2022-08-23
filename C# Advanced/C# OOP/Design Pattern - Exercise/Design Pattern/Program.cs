using System;

namespace Prototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SandwichMenu menu = new SandwichMenu();

            menu["BLT"] = new Sandwich("Wheat", "Bacon", "", "Tomato");
            menu["LST"] = new Sandwich("White", "Beef", "Chedar", "Onion");
            menu["Turkey"] = new Sandwich("Wheat", "Turkey", "Swiss", "Lettuce, Onion, Tomato");

            menu["Vegetarian"] = new Sandwich("Wheat", "", "Swiss", "Lettuce, Tomato");
            menu["ThreeMeat"] = new Sandwich("White", "Turkey, Beef, Ham", "American", "Lettuce");

            Sandwich sandwich1 = menu["Vegetarian"].Clone() as Sandwich;
            Sandwich sandwich2 = menu["LST"].Clone() as Sandwich;
            Sandwich sandwich3 = menu["Turkey"].Clone() as Sandwich;
        }
    }
}
