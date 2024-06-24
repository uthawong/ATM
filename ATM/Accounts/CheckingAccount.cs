using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Accounts
{
    public class CheckingAccount : BankAccount
    {
        public CheckingAccount(string accountNumber, decimal balance = 0)
            : base(accountNumber, balance)
        {
        }

        public override string AccountType()
        {
            return "Checking Account";
        }
    }
}
