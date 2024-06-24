using ATM.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Strategies
{
    public interface IWithdrawStrategy    //Strategy - Flera olika sätt att kunna ta ut pengar ska kunna skapas. IWithdrawStrategy är basen.
    {
        bool Withdraw(BankAccount account, decimal amount);
    }
}
