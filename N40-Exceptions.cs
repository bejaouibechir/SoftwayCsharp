
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    using System;
    #region inner exception
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Call a method that may throw an exception
                DivideByZero();
            }
            catch (Exception ex)
            {
                // Catch the exception and handle it
                Console.WriteLine("An error occurred: " + ex.Message);

                // Check if the exception has inner exception(s)
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner exception:");
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
        }

        static void DivideByZero()
        {
            try
            {
                // This will cause a divide by zero exception
                int result = 10 / 0;
            }
            catch (Exception ex)
            {
                // Wrap the exception in a new exception with additional context
                throw new ApplicationException("Error occurred while performing division operation.", ex);
            }
        }
    }

    #endregion

    #region custom exception

    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string message) : base(message)
        {
        }
    }

    public class BankAccount
    {
        private decimal balance;

        public BankAccount(decimal initialBalance)
        {
            balance = initialBalance;
        }

        public void Withdraw(decimal amount)
        {
            if (amount > balance)
            {
                throw new InsufficientFundsException("Insufficient funds to withdraw " + amount.ToString("C"));
            }

            balance -= amount;
            Console.WriteLine("Withdrawal of " + amount.ToString("C") + " successful.");
        }

        public decimal GetBalance()
        {
            return balance;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount(1000);

            try
            {
                account.Withdraw(1500);
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.WriteLine("Current balance: " + account.GetBalance().ToString("C"));
        }
    }

    #endregion

    #region filtre when
    namespace Client
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    throw new LeveledException(Level.L2);
                }
                catch (LeveledException ex) when (ex.Level == Level.L3)
                {
                    ;
                }
            }
        }


        public class LeveledException : Exception
        {

            public Level Level { get; set; }
            public LeveledException()
            {

            }
            public LeveledException(Level level)
            {
                Level = level;
            }

        }

        public enum Level
        {
            L3, L2, L1
        }
    }

    #endregion

}
