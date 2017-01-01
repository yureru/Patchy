using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    class Program
    {
        static void Main(string[] args)
        {

            var Account = new BankAccount("Dennis", "Ritchie", 11.3M);
            Account.PrintCurrentFunds();

            var amountToDeposit = 321.50M;
            Console.WriteLine("Depositing $" + amountToDeposit);
            Account.Deposit(amountToDeposit);
            Account.PrintCurrentFunds();

            var amountToWithdraw = 80.23M;
            Console.WriteLine("Witdrawing $" + amountToWithdraw);
            Account.WithDraw(amountToWithdraw);
            Account.PrintCurrentFunds();

            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
