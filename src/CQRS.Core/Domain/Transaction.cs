using System;

namespace CQRS.Core.Domain
{
    public class Transaction
    {
        public decimal Amount { get; private set; }
        public string Description { get; private set; }
        public DateTime TransactionDate { get; private set; }

       public Transaction(decimal amount, string description, DateTime transactionDate)
       {
           Amount = amount;
           Description = description;
           TransactionDate = transactionDate;
       }
    }
}