﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Accounts
{
    public abstract class BankAccount         //En abstrakt klass för konton
    {
        public string AccountNumber { get; private set; }
        public decimal Balance { get; private set; }

        protected BankAccount(string accountNumber, decimal balance = 0)
        {
            AccountNumber = accountNumber;
            Balance = balance;
        }

        public abstract string AccountType();

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public bool Withdraw(decimal amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }
    }
}
