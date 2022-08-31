using System;

namespace TheBattleOfTheFiveArmies
{
    class Program
    {
        static void Main(string[] args)
        {
            int underArmour = int.Parse(Console.ReadLine());
            int rowsMap = int.Parse(Console.ReadLine());

            char[][] warMap = new char[rowsMap][];

            int armyRow = 0;
            int armyCol = 0;


            for (int row = 0; row < rowsMap; row++)
            {
                char[] statusLooksRows = Console.ReadLine().ToCharArray();

                warMap[row] = statusLooksRows;

            }

            for (int row = 0; row < rowsMap; row++)
            {
                for (int col = 0; col < warMap[row].Length; col++)
                {
                    if (warMap[row][col] == 'A')
                    {
                        armyRow = row;
                        armyCol = col;
                    }
                }
            }

            while (true)
            {
                string[] command = Console.ReadLine().Split();

                string move = command[0];
                int spawnRow = int.Parse(command[1]);
                int spawnCol = int.Parse(command[2]);

                warMap[spawnRow][spawnCol] = 'O';

                if (move == "up" && armyRow - 1 >= 0)
                {
                    warMap[armyRow][armyCol] = '-';
                    armyRow--;

                }
                else if (move == "right" && armyCol + 1 < warMap[armyRow].Length)
                {
                    warMap[armyRow][armyCol] = '-';
                    armyCol++;
                }
                else if (move == "left" && armyCol - 1 >= 0)
                {
                    warMap[armyRow][armyCol] = '-';
                    armyCol--;
                }
                else if (move == "down" && armyRow + 1 < rowsMap)
                {
                    warMap[armyRow][armyCol] = '-';
                    armyRow++;
                }

                underArmour--;

                if (underArmour <= 0)
                {
                    warMap[armyRow][armyCol] = 'X';
                    Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                    break;
                }
                else if (warMap[armyRow][armyCol] == 'O')
                {
                    underArmour -= 2;

                    if (underArmour <= 0)
                    {
                        warMap[armyRow][armyCol] = 'X';
                        Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                        break;
                    }
                }
                else if (warMap[armyRow][armyCol] == 'M')
                {
                    warMap[armyRow][armyCol] = '-';
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {underArmour}");
                    break;
                }

                warMap[armyRow][armyCol] = 'A';
            }

            for (int i = 0; i < rowsMap; i++)
            {
                Console.WriteLine(string.Join("", warMap[i]));
            }
        }
    }
}
