using System.Collections.Generic;

namespace SupportBank
{
    public class Account 
    { 
        private string Name {get; set;}

        public List<Transaction> AccountTransactions {get; set;}

        public decimal AccountBalance {get; set;}

        public Account(string name)
        {
            Name = name;
            AccountTransactions = new List<Transaction>();
            AccountBalance = 0;
        }
    }
}