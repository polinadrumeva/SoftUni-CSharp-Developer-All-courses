using System;

namespace E07.Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var personInfo = Console.ReadLine().Split();
            var fullName = $"{personInfo[0]} {personInfo[1]}";
            var adress = $"{personInfo[2]}";

            var nameAndBeer = Console.ReadLine().Split();
            var name = nameAndBeer[0];
            var litersBeer = int.Parse(nameAndBeer[1]);

            var numbersInput = Console.ReadLine().Split();  
            var intNum = int.Parse(numbersInput[0]);
            var doubleNum = double.Parse(numbersInput[1]);

            Tuple<string, string> firstTuple = new Tuple<string, string>(fullName, adress);
            Tuple<string, int> secondTuple = new Tuple<string, int>(name, litersBeer);
            Tuple<int, double> thirdTuple = new Tuple<int, double>(intNum, doubleNum);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
