using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Accounts;

namespace ATM
{   
    public class ATMSystem         // Singleton - Enligt singleton principen så körs bara en instans av bankomat systemet.
    {
        private static ATMSystem _instance;
        private Dictionary<string, BankAccount> _accounts;

        private ATMSystem()
        {
            _accounts = new Dictionary<string, BankAccount>();
        }

        public static ATMSystem Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ATMSystem();
                }
                return _instance;
            }
        }

        public void AddAccount(BankAccount account)
        {
            _accounts[account.AccountNumber] = account;
        }

        public BankAccount GetAccount(string accountNumber)
        {
            _accounts.TryGetValue(accountNumber, out BankAccount account);
            return account;
        }
        public void DisplayAccountList()
        {
            if (_accounts.Count == 0)
            {
                Console.WriteLine("There are no accounts registered yet.");
                return;
            }
            foreach (var account in _accounts.Values)
            {
                Console.Clear();
                Console.WriteLine($"Account number: {account.AccountNumber} - Account type: {account.AccountType()} - Current balance:  Balance: {account.Balance}\n");
            }
        }
    }
}
