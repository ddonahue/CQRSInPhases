using System;

namespace Messages.Events
{
    public class AccountLockedEvent : IDomainEvent
    {
        public Guid BankAccountId { get; set; }
        public decimal TransactionAmount { get; set; }
        public decimal Balance { get; set; }

        public int Version { get; set; }
    }
}