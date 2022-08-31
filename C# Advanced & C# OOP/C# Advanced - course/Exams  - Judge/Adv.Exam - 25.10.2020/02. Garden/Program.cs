using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Garden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int rows = sizes[0];
            int cols = sizes[1];
            int[,] garden = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    garden[row, col] = 0;
                }
            }

            List<int> flowers = new List<int>();
            string command;
            while ((command = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] datas = command.Split(' ').Select(int.Parse).ToArray();
                int flowerRow = datas[0];
                int flowerCol = datas[1];

                if (flowerRow < 0 || flowerRow > rows - 1 || flowerCol < 0 || flowerCol > cols - 1)
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }
                else
                {
                    garden[flowerRow, flowerCol]++;
                    flowers.Add(flowerRow);
                    flowers.Add(flowerCol);
                }
            }


            for (int k = 0; k < flowers.Count; k+=2)
            {
                int row = flowers[k];
                int col = flowers[k + 1];

                for (int j = 0; j < cols; j++)
                {
                    garden[row, j]++;
                }

                garden[row, col]--;
                for (int j = 0; j < rows; j++)
                {
                    garden[j, col]++;
                }

                garden[row, col]--;

            }
            

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{garden[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}

