using System;
using System.Collections.Generic;
using System.Text;

namespace E06.Money_Transactions
{
    public class BankAcount
    {
        public int AccountNumber { get; set; }
        public double Balance { get; set; }

        public BankAcount(int account, double balance)
        {
            this.AccountNumber = account;
            this.Balance = balance;
        }
    }
}
