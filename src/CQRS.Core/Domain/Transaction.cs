using System;

namespace CQRS.Core.Domain
{
    public class Transaction
    {
        public decimal Amount { get; private set; }
        public string Description { get; set; }
        public DateTime TransactionDate { get; set; }

       public Transaction(decimal amount, string description, DateTime transactionDate)
       {
           Amount = amount;
           Description = description;
           TransactionDate = transactionDate;
       }
    }
}