using ATM.Accounts;
using ATM.Factories;
using ATM.Strategies;

//Caroline Uthawong-Burr, .NET23

namespace ATM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ATMSystem atmSystem = ATMSystem.Instance;

            AccountFactory savingsFactory = new SavingsAccountFactory();
            AccountFactory checkingFactory = new CheckingAccountFactory();

            IWithdrawStrategy normalWithdrawal = new NormalWithdraw();
            IWithdrawStrategy quickWithdrawal = new QuickWithdraw();

            bool exit = false;
            Console.WriteLine("Welcome to Caroline's ATM!");
            while (!exit)
            {

                Console.WriteLine("Menu:");
                Console.WriteLine("1. Create Savings Account");
                Console.WriteLine("2. Create Checking Account");
                Console.WriteLine("3. Deposit");
                Console.WriteLine("4. Withdraw");
                Console.WriteLine("5. Check Balance");
                Console.WriteLine("6. Display all accounts");
                Console.WriteLine("7. Exit");
                Console.Write("Select an option: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        CreateAccount(atmSystem, savingsFactory);
                        break;
                    case "2":
                        CreateAccount(atmSystem, checkingFactory);
                        break;
                    case "3":
                        Deposit(atmSystem);
                        break;
                    case "4":
                        Withdraw(atmSystem, normalWithdrawal, quickWithdrawal);
                        break;
                    case "5":
                        CheckBalance(atmSystem);
                        break;
                    case "6":
                        atmSystem.DisplayAccountList();
                        break;
                    case "7":
                        Console.WriteLine("Thank you for using Caroline's ATM Service!");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
                Console.WriteLine();
            }


        }

        public static void CreateAccount(ATMSystem atmSystem, AccountFactory factory)
        {
            Console.Write("Please enter an account number: ");
            string accountNumber = Console.ReadLine();
            BankAccount account = factory.CreateAccount(accountNumber);
            atmSystem.AddAccount(account);
            Console.WriteLine($"New {account.AccountType()} created with account number {account.AccountNumber}.");
            Console.Write("Press any key to return to menu: ");
            Console.ReadLine();
            Console.Clear();
        }
        public static void Deposit(ATMSystem atmSystem)
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();
            BankAccount account = atmSystem.GetAccount(accountNumber);
            if (account != null)
            {
                Console.Write("Enter deposit amount: ");
                decimal amount = decimal.Parse(Console.ReadLine());
                account.Deposit(amount);
                Console.WriteLine($"Deposited {amount} to account {account.AccountNumber}. New balance: {account.Balance}");
            }
            else
            {
                Console.WriteLine($"No account with  account number: {accountNumber} was found.");
            }
            Console.Write("Press any key to return to menu: ");
            Console.ReadLine();
            Console.Clear();
        }
        public static void Withdraw(ATMSystem atmSystem, IWithdrawStrategy normalStrategy, IWithdrawStrategy quickStrategy)
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();
            BankAccount account = atmSystem.GetAccount(accountNumber);
            if (account != null)
            {
                Console.Write("Enter withdrawal amount: ");
                decimal amount = decimal.Parse(Console.ReadLine());
                Console.Write("Select withdrawal type (1: Normal, 2: Quick): ");
                string withdrawalType = Console.ReadLine();

                bool success = false;
                if (withdrawalType == "1")
                {
                    success = normalStrategy.Withdraw(account, amount);
                }
                else if (withdrawalType == "2")
                {
                    success = quickStrategy.Withdraw(account, amount);
                }
                else
                {
                    Console.WriteLine("Invalid withdrawal type.");
                }

                if (success)
                {
                    Console.WriteLine($"Withdrew {amount} from account {account.AccountNumber}. New balance: {account.Balance}");
                }
                else
                {
                    Console.WriteLine("Withdrawal failed.");
                }
            }
            else
            {
                Console.WriteLine($"No account with account number: {accountNumber} was found.");
            }
            Console.Write("Press any key to return to menu: ");
            Console.ReadLine();
            Console.Clear();
        }

        public static void CheckBalance(ATMSystem atmSystem)
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();
            BankAccount account = atmSystem.GetAccount(accountNumber);
            if (account != null)
            {
                Console.WriteLine($"Account {account.AccountNumber} balance: {account.Balance}");
            }
            else
            {
                Console.WriteLine($"No account with account number: {accountNumber} was found.");
            }
            Console.Write("Press any key to return to menu: ");
            Console.ReadLine();
            Console.Clear();
        }
    }
}