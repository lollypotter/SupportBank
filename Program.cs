using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SupportBank
{
    class Program
    {
        static void Main()
        {
            var transactions = Transaction.ProcessTransaction("C:/Work/Training/Test/Test/Transactions2014.csv");
            var bank2014 = Bank.CreateAccounts(transactions);
            GiveUserChoice(bank2014);
        }

        private static void PrintList(List<Transaction> listToPrint)
        {
            foreach (var item in listToPrint)
            {
                Console
                    .WriteLine(
                        $"Date: {item.Date.ToString("d").PadRight(10)} From: {item.From.PadRight(10)} To:{item.To.PadRight(10)} Narrative: {item.Narrative.PadRight(10)} Amount: £{item.Amount}");
            }
        }

        private static void GiveUserChoice( Dictionary<string, Account> bank2014)
        {
            Console.WriteLine(
                "Please choose one of the following:\n 1. List All Accounts\n 2. List Transactions for a specific Account");
            var choice = Console.ReadLine();
            Invoker invoker = new Invoker();
            ICommand command = invoker.GetCommand(choice, bank2014);
            command.ExecuteChoice(bank2014);
        }
    }
}