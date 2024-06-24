using ATM.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Strategies
{
    public class NormalWithdraw : IWithdrawStrategy   // Strategy - kan byggas ut med flera tjänster för att ta ut pengar.
    {
        public bool Withdraw(BankAccount account, decimal amount)
        {
            return account.Withdraw(amount);
        }
    }
}
