using System;

namespace CQRS.Core.Commands
{
    public class PostTransactionCommand : ICommand
    {
        public Guid BankAccountId { get; private set; }
        public decimal Amount { get; private set; }
        public string Description { get; private set; }
        public DateTime TransactionDate  { get; private set; }

        public PostTransactionCommand(Guid bankAccountId, decimal amount, string description, DateTime transactionDate)
        {
            BankAccountId = bankAccountId;
            Amount = amount;
            Description = description;
            TransactionDate = transactionDate;
        }
    }
}