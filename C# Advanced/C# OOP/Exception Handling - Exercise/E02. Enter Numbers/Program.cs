using System;

namespace E02._Enter_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int[] result = ReadNumber(2, 100, number);
            Console.WriteLine(string.Join(", ", result));

        }

        static int[] ReadNumber(int start, int end, string number)
        {
            int[] result = new int[10];
            int count = 0;

            while (count != 10)
            {
                try
                {
                    int num = int.Parse(number);
                    if (num > start && num < end)
                    {
                        result[count] = num;
                        count++;
                    }
                    else if (num <= start || num >= end)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    else
                    {
                        throw new FormatException();
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine($"Your number is not in range {number} -100!");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Number!");
                }
                
                if (count == 10)
                {
                    break;
                }
                else
                {
                    number = Console.ReadLine();
                }
                
            }
            
            return result;
        }
        
    }
}
