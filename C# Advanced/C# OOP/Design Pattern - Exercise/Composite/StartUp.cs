using System;

namespace Composite
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            var phone = new SingleGift("Samsung", 300);
            phone.CalculatePrice();
            Console.WriteLine();

            var rootBox = new CompositeGift("RootBox", 0);
            var truck = new SingleGift("Truck", 30);
            var train = new SingleGift("Train", 10);
            rootBox.Add(train);
            rootBox.Add(truck);

            Console.WriteLine($"Total price of this composite present is: {rootBox.CalculatePrice()} $");

        }
    }
}
