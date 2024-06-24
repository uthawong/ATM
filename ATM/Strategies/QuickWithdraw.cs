using ATM.Strategies;
using ATM.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Strategies
{
    public class QuickWithdraw : IWithdrawStrategy  // Strategy - kan byggas ut med flera uttags tjänster.
    {
        public bool Withdraw(BankAccount account, decimal amount)
        {
            if (amount > 500)   // Jag har satt ett max-tak på 500 för snabba uttag.
            {
                Console.WriteLine("Quick withdrawal limit is 500");
                return false;
            }
            return account.Withdraw(amount);
        }
    }
}
