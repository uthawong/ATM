using ATM.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Factories
{
    public class CheckingAccountFactory : AccountFactory     // Factory Method - Utan att röra befintliga konton så kan man med lätthet utöka med factory
    {
        public override BankAccount CreateAccount(string accountNumber)
        {
            return new CheckingAccount(accountNumber);
        }
    }
}
