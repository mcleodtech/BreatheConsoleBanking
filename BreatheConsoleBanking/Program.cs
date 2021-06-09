using System;

namespace BreatheConsoleBanking
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Robert", 1000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance}.");

            account.MakeWithdrawl(294, DateTime.Now, "Desk");
            Console.WriteLine($"You purchased a {""} for {294} on {DateTime.Now}, your current balance is {account.Balance}");

            account.MakeWithdrawl(593, DateTime.Now, "Window Repair");

            Console.WriteLine(account.GetAccountHistory());



            //Test for a negative balance
            try
            {
                account.MakeWithdrawl(150, DateTime.Now, "Attempt to overdraw");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception caught trying to overdraw");
                Console.WriteLine(e.ToString());
            }


            //Test that the initial balance must be positive:
            try
            {
                var invalidAccount = new BankAccount("invalid", -55);

            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught creating account with negative balance");
                Console.WriteLine(e.ToString());
            }

        }


    }
}
