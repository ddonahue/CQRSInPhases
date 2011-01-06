using System;

namespace CQRS.Core.Events
{
    public class TransationPostedEvent : IDomainEvent
    {
        public Guid BankAccountId { get; set; }

        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}