using System.Collections.Generic;
using System;
using System.Linq;

namespace SupportBank
{
    public class Invoker
    {
        ICommand _cmd = null;

        public ICommand GetCommand(string choice, Dictionary<string, Account> accountsDictionary)
        {
            switch (choice)
            {
                case "1":
                    _cmd = new ListAllCommand();
                    break;
                case "2":
                    _cmd = new ListAccountCommand();
                    break;
                default:
                    break;
            }

            return _cmd;
        }
    }

    public interface ICommand
    {
        string Choice { get; }
        void ExecuteChoice(Dictionary<string, Account> accountsDictionary);
    }

    public class ListAccountCommand : ICommand
    {
        public void ExecuteChoice(Dictionary<string, Account> accountsDictionary)
        {

            Console.WriteLine("Please choose from one of the following accounts:");
            Bank.GetAccountNames(accountsDictionary);
            var choice = Console.ReadLine();

            if (choice != null && accountsDictionary.ContainsKey(choice))
            {
                var value = accountsDictionary[choice];
                foreach (var transaction in value.AccountTransactions)
                {
                    if (transaction.From == choice)
                    {
                        Console.WriteLine($"{choice} is owed £{transaction.Amount} from {transaction.To}");
                    }
                    else
                    {
                        Console.WriteLine($"{choice} owes £{transaction.Amount} to {transaction.To}");
                    }
                }
            }
            else
            {
                Console.WriteLine("No Account Found");
            }
        }

        public string Choice
        {
            get { return "2"; }
        }
    }

    public class ListAllCommand : ICommand
    {
        public void ExecuteChoice(Dictionary<string, Account> accountsDictionary)
        {
            foreach (var indAccount in accountsDictionary)
            {
                Console.WriteLine("{0} {1} £{2}", indAccount.Key,
                    (indAccount.Value.AccountBalance < 0 ? "owes" : "is owed"),
                    Math.Abs(indAccount.Value.AccountBalance));
            }
        }

        public string Choice
        {
            get { return "1"; }
        }
    }
}