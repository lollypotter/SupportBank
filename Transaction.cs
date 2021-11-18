using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SupportBank
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        
        public string From { get; set; }  
        
        public string To { get; set; }
        
        public string Narrative { get; set; }

        public decimal Amount { get; set; }
        
        private Transaction(DateTime transactionDate, string from, string to, string narrative, decimal amount)
        {
            Date = transactionDate;
            From = from;
            To = to;
            Narrative = narrative;
            Amount = amount;
        }
        
        public static List<Transaction> ProcessTransaction(string file)
        {
            var transactions = new List<Transaction>();
            var csvFile = File.ReadAllLines(file).Skip(1);
      
            foreach (string line in csvFile)
            {
                string[] transactionelements = line.Split(',');
                Transaction newTransaction =
                    new Transaction(DateTime.Parse(transactionelements[0]),
                        transactionelements[1],
                        transactionelements[2],
                        transactionelements[3],
                        Decimal.Parse(transactionelements[4]));
                transactions.Add (newTransaction);
            }
            return transactions;
        }
    }
}