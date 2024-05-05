/*
 Cet exemple montre comment le pattern Facade
simplifie l'utilisation d'un sous-système complexe en fournissant une interface unifiée aux clients
 */

using System;

namespace Client
{
    public class Program
    {
        public static void Main()
        {
            BankFacade bank = new BankFacade();
            // Withdrawal
            bank.Withdraw(12345, 200.0m);
            // Deposit
            bank.Deposit(12345, 300.0m);
        }
    }


    // Subsystem components
    class AccountVerification
    {
        public bool VerifyAccount(int accountId)
        {
            Console.WriteLine("Verifying account...");
            // Simulated account verification process
            return true;
        }
    }

    public class BalanceChecker
    {
        public decimal CheckBalance(int accountId)
        {
            Console.WriteLine("Checking balance...");
            // Simulated balance checking process
            return 500.0m;
        }
    }

    public class TransactionProcessor
    {
        public void ProcessTransaction(int accountId, decimal amount)
        {
            Console.WriteLine("Processing transaction...");
            // Simulated transaction processing
            Console.WriteLine("Transaction processed successfully.");
        }
    }

    // Facade
    public class BankFacade
    {
        private AccountVerification accountVerification;
        private BalanceChecker balanceChecker;
        private TransactionProcessor transactionProcessor;

        public BankFacade()
        {
            accountVerification = new AccountVerification();
            balanceChecker = new BalanceChecker();
            transactionProcessor = new TransactionProcessor();
        }

        public void Withdraw(int accountId, decimal amount)
        {
            if (accountVerification.VerifyAccount(accountId))
            {
                decimal balance = balanceChecker.CheckBalance(accountId);
                if (balance >= amount)
                {
                    transactionProcessor.ProcessTransaction(accountId, -amount);
                    Console.WriteLine($"Withdrawal of {amount} successful.");
                }
                else
                {
                    Console.WriteLine("Insufficient funds.");
                }
            }
            else
            {
                Console.WriteLine("Account verification failed.");
            }
        }

        public void Deposit(int accountId, decimal amount)
        {
            if (accountVerification.VerifyAccount(accountId))
            {
                transactionProcessor.ProcessTransaction(accountId, amount);
                Console.WriteLine($"Deposit of {amount} successful.");
            }
            else
            {
                Console.WriteLine("Account verification failed.");
            }
        }
    }
}