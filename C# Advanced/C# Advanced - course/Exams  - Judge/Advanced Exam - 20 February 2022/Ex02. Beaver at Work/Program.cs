using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex02._Beaver_at_Work
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] pond = new char[n,n];
            List<char> branches = new List<char>();

            for (int row = 0; row < pond.GetLength(0); row++)
            {
                char[] data = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();

                for (int col = 0; col < pond.GetLength(1); col++)
                {
                    pond[row,col] = data[col];
                }
            }
            
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "up":
                        pond = MoveUp(pond,branches);
                        break;
                    case "down":
                        pond = MoveDown(pond, branches);
                        break;
                    case "right":
                        pond = MoveRight(pond, branches);
                        break;
                    case "left":
                        pond = MoveLeft(pond, branches);
                        break;
                
                }
            }

            for (int row = 0; row < pond.GetLength(0); row++)
            {
                for (int co = 0; co < pond.GetLength(1); co++)
                {
                    Console.Write(pond[row,co]);
                }
                Console.WriteLine();
            }
        }

        private static char[,] MoveLeft(char[,] pond, List<char> branches)
        {
            bool isStop = false;
            for (int row = 0; row < pond.GetLength(0); row++)
            {
                if (isStop)
                {
                    break;
                }
                for (int col = 0; col < pond.GetLength(1); col++)
                {
                    if (isStop)
                    {
                        break;
                    }
                    if (pond[row, col] == 'B')
                    {
                        isStop = true;
                        if (col - 1 < 0)
                        {
                            CheckBranches(branches);
                        }
                        else if (Char.IsLower((char)pond[row, col - 1]))
                        {
                            branches.Add(pond[row, col - 1]);
                            pond[row, col] = '-';
                            pond[row, col - 1] = 'B';
                        }
                        else if (pond[row, col - 1] == 'F')
                        {
                            pond[row, col - 1] = '-';
                            pond[row, 0] = 'B';
                            if (pond[row, 0] == 'F')
                            {
                                pond[row, 0] = '-';
                                pond[row, pond.GetLength(1) - 1] = 'B';
                                if (Char.IsLower(pond[row, pond.GetLength(1) - 1]))
                                {
                                    branches.Add(pond[row, pond.GetLength(1) - 1]);
                                }
                            }
                        }

                        row = 0;
                        col = 0;
                    }
                   
                }
                
            }

            return pond;
        }

        private static char[,] MoveRight(char[,] pond, List<char> branches)
        {
            bool isStop = false;
            for (int row = 0; row < pond.GetLength(0); row++)
            {
                if (isStop)
                {
                    break;
                }
                for (int col = 0; col < pond.GetLength(1); col++)
                {
                    if (isStop)
                    {
                        break;
                    }
                    if (pond[row, col] == 'B')
                    {
                        isStop = true;
                        if (col + 1 > pond.GetLength(1) - 1)
                        {
                            CheckBranches(branches);
                        }
                        else if (Char.IsLower((char)pond[row, col+1]))
                        {
                            branches.Add(pond[row, col+1]);
                            pond[row, col] = '-';
                            pond[row, col+1] = 'B';
                        }
                        else if (pond[row, col+1] == 'F')
                        {
                            pond[row, col+1] = '-';
                            pond[row, pond.GetLength(1) - 1] = 'B';
                            if (pond[row, pond.GetLength(1) - 1] == 'F')
                            {
                                pond[row, pond.GetLength(1) - 1] = '-';
                                pond[row, 0] = 'B';
                                if (Char.IsLower(pond[row, 0]))
                                {
                                    branches.Add(pond[row, 0]);
                                }
                            }
                        }

                        row = 0;
                        col = 0;
                       

                    }
                }
                
            }

            return pond;
        }

        private static char[,] MoveDown(char[,] pond, List<char> branches)
        {
            bool isStop = false;
            for (int row = 0; row < pond.GetLength(0); row++)
            {
                if (isStop)
                {
                    break;
                }
                for (int col = 0; col < pond.GetLength(1); col++)
                {
                    if (isStop)
                    {
                        break;
                    }
                    if (pond[row, col] == 'B')
                    {
                        isStop = true;
                        if (row + 1 > pond.GetLength(0) -1)
                        {
                            CheckBranches(branches);
                        }
                        else if (Char.IsLower((char)pond[row + 1, col]))
                        {
                            branches.Add(pond[row + 1, col]);
                            pond[row, col] = '-';
                            pond[row + 1, col] = 'B';
                        }
                        else if (pond[row + 1, col] == 'F')
                        {
                            pond[row + 1, col] = '-';
                            pond[pond.GetLength(0)-1, col] = 'B';
                            if (pond[pond.GetLength(0) - 1, col] == 'F')
                            {
                                pond[pond.GetLength(0) - 1, col] = '-';
                                pond[0, col] = 'B';
                                if (Char.IsLower(pond[0, col]))
                                {
                                    branches.Add(pond[0, col]);
                                }
                            }
                        }

                        row = 0;
                        col = 0;
                        

                    }
                }
                
            }

            return pond;
        }

        public static char[,] MoveUp(char[,] pond, List<char> branches)
        {
            bool isStop = false;
            for (int row = 0; row < pond.GetLength(0); row++)
            {
                if (isStop)
                {
                    break;
                }
                for (int col = 0; col < pond.GetLength(1); col++)
                {
                    if (isStop)
                    {
                        break;
                    }
                    if (pond[row, col] == 'B')
                    {
                        isStop = true;
                        if (row - 1 < 0)
                        {
                            CheckBranches(branches);
                        }
                        else if (Char.IsLower((char)pond[row - 1, col]))
                        { 
                            branches.Add(pond[row-1, col]);
                            pond[row, col] = '-';
                            pond[row-1, col] = 'B';
                        }
                        else if (pond[row-1,col] == 'F')
                        {
                            pond[row - 1, col] = '-';
                            pond[0, col] = 'B';
                            if (pond[0,col] == 'F')
                            {
                                pond[0, col] = '-';
                                pond[pond.GetLength(0) - 1, col] = 'B';
                                if (Char.IsLower(pond[pond.GetLength(0) - 1, col]))
                                {
                                    branches.Add(pond[pond.GetLength(0) - 1, col]);
                                }
                            }
                        }

                        row = 0;
                        col = 0;
                        

                    }
                    
                }
                
            }

            return pond;
        }

        public static List<char> CheckBranches(List<char> branches)
        {
            if (branches.Count> 0)
            {
                branches.RemoveAt(branches.Count - 1);
            }

            return branches;
        }
    }
}
