using System;
using System.Collections.Generic;

namespace E06.Money_Transactions
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int,BankAcount> allaccount = new Dictionary<int, BankAcount>(); 

            string[] all = Console.ReadLine().Split(",");
            for (int i = 0; i < all.Length; i++)
            {
                string[] current = all[i].Split("-");
                BankAcount newaccount = new BankAcount(int.Parse(current[0]), double.Parse(current[1]));
                allaccount.Add(int.Parse(current[0]),newaccount);
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArg = command.Split(" ");

                try
                {
                    string typeCmd = cmdArg[0];
                    if (typeCmd == "Deposit")
                    {
                        int account = int.Parse(cmdArg[1]);
                        if (!allaccount.ContainsKey(account))
                        {
                            throw new InvalidOperationException("Invalid account!");
                        }
                        double balance = double.Parse(cmdArg[2]);
                        allaccount[account].Balance += balance;
                        Console.WriteLine($"Account {account} has new balance: {allaccount[account].Balance:f2}");
                    }
                    else if (typeCmd == "Withdraw")
                    {
                        int account = int.Parse(cmdArg[1]);
                        if (!allaccount.ContainsKey(account))
                        {
                            throw new InvalidOperationException("Invalid account!");
                        }
                        double balance = double.Parse(cmdArg[2]);
                        if (balance > allaccount[account].Balance)
                        {
                            throw new IndexOutOfRangeException("Insufficient balance!");
                        }
                        else
                        {
                            allaccount[account].Balance -= balance; 
                            Console.WriteLine($"Account {account} has new balance: {allaccount[account].Balance:f2}");
                        }

                    }
                    else
                    {
                        throw new ArgumentException("Invalid command!");
                    }


                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (InvalidOperationException invex)
                {
                    Console.WriteLine(invex.Message);
                }
                catch (IndexOutOfRangeException outEx)
                {
                    Console.WriteLine(outEx.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
                

            }
        }
    }
}
