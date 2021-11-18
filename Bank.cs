using System;
using System.Collections.Generic;

namespace SupportBank
{
    class Bank
    {
        public Dictionary<string, Account> BankAccounts { get; set; }

        public static Dictionary<string, Account> CreateAccounts(List<Transaction> transactions)
        {
            var accountsDictionary = new Dictionary<string, Account>();
            
            foreach (var transaction in transactions)
            {
                if (accountsDictionary.ContainsKey(transaction.From))
                {
                    accountsDictionary[transaction.From].AccountTransactions.Add(transaction);
                    accountsDictionary[transaction.From].AccountBalance =
                        (accountsDictionary[transaction.From].AccountBalance - transaction.Amount);
                    if (accountsDictionary.ContainsKey(transaction.To))
                    {
                        accountsDictionary[transaction.To].AccountTransactions.Add(transaction);
                        accountsDictionary[transaction.To].AccountBalance =
                            (accountsDictionary[transaction.To].AccountBalance + transaction.Amount);

                    }
                    else
                    {
                        var newAccount = new Account(transaction.To);
                        accountsDictionary.Add(transaction.To, newAccount);
                        accountsDictionary[transaction.To].AccountTransactions.Add(transaction);
                        accountsDictionary[transaction.To].AccountBalance =
                            (accountsDictionary[transaction.To].AccountBalance + transaction.Amount);
                    }
                }
                else
                {
                    var newAccount2 = new Account(transaction.From);
                    accountsDictionary.Add(transaction.From, newAccount2);
                    accountsDictionary[transaction.From].AccountTransactions.Add(transaction);
                    accountsDictionary[transaction.From].AccountBalance =
                        (accountsDictionary[transaction.From].AccountBalance - transaction.Amount);

                    if (accountsDictionary.ContainsKey(transaction.To))
                    {
                        accountsDictionary[transaction.To].AccountTransactions.Add(transaction);
                        accountsDictionary[transaction.To].AccountBalance =
                            (accountsDictionary[transaction.To].AccountBalance + transaction.Amount);
                    }
                    else
                    {
                        var newAccount3 = new Account(transaction.To);
                        accountsDictionary.Add(transaction.To, newAccount3);
                        accountsDictionary[transaction.To].AccountTransactions.Add(transaction);
                        accountsDictionary[transaction.To].AccountBalance =
                            (accountsDictionary[transaction.To].AccountBalance + transaction.Amount);
                    }
                }
            }
            return accountsDictionary;
        }

        public static void GetAccountNames(Dictionary<string, Account> bankAccount)
        {
            foreach (var name in bankAccount)
            {
                Console.WriteLine(name.Key);
            }
        }
    }
}