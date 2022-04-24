using System;

namespace ME04._Refactoring__Prime_Checker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int count = 0;
            string boolean = string.Empty;
            for (int number = 2; number <= n; number++)

            {

                for (int divided = 2; divided <= number; divided++)
                {
                    if (number % divided == 0)
                    {
                        count++;
                        if (count > 1)
                        {
                            boolean = "false";

                        }
                        else
                        {
                            boolean = "true";
                        }
                    }

                }
                count = 0;

                Console.WriteLine($"{number} -> {boolean}");
            }

        }
    }
}
