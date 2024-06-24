using ATM.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Factories
{
    public abstract class AccountFactory   // Factory Method - Basen för att skapa olika typer av bank konton
    {
        public abstract BankAccount CreateAccount(string accountNumber);
    }
}
