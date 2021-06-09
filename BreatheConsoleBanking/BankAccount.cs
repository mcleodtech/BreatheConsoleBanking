using System;
using System.Collections.Generic;
using System.Text;

namespace BreatheConsoleBanking
{
    class BankAccount
    {
        //CTL + G to jump to a line number
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }
        private static int accountNumberSeed = 1234567890;

        public List<Transaction> allTransactions = new List<Transaction>();

        public BankAccount(string name, decimal initialBalance)
        {
            //A constructor can be thought of like a form, "this is what
            //a bank account should look like
            Owner = name;

            MakeDeposit(initialBalance, DateTime.Now, "Initial Balance");

            Number = accountNumberSeed.ToString();
            accountNumberSeed++;
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawl(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of Withdrawl must be positive ");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawl");
                //The throw will stop the function if the criteria are metS
            }
            var withdrawl = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawl);

        }

        public string GetAccountHistory()
        {
            //Use a string builder to make complex strings
            var report = new StringBuilder();

            report.AppendLine("Date\t\tAmount\tNote");
            foreach (var item in allTransactions)
            {
                //Making rows with the \t "tab" character
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{item.Notes}");

            }
            return report.ToString();
        }
    }
}
