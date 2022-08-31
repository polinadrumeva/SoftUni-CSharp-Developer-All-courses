using System;

namespace E08.Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var personInfo = Console.ReadLine().Split();
            var fullName = $"{personInfo[0]} {personInfo[1]}";
            var adress = $"{personInfo[2]}";
            var city = $"{personInfo[3]}";

            var nameAndBeer = Console.ReadLine().Split();
            var name = nameAndBeer[0];
            var litersBeer = int.Parse(nameAndBeer[1]);
            bool isdrink = nameAndBeer[2] == "drunk" ? true : false;

            var nameAndBank = Console.ReadLine().Split();
            var nameForBank = nameAndBank[0];
            var acountbalance = double.Parse(nameAndBank[1]);
            var bankName = nameAndBank[2];

            Threeuple<string, string, string> firstTuple = new Threeuple<string, string, string>(fullName, adress, city);
            Threeuple<string, int, bool> secondTuple = new Threeuple<string, int, bool>(name, litersBeer, isdrink);
            Threeuple<string, double, string> thirdTuple = new Threeuple<string, double, string>(nameForBank, acountbalance, bankName);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
