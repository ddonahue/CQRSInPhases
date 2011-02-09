using System;

namespace Messages.Events
{
    public class AccountCreatedEvent : IDomainEvent
    {
        public Guid BankAccountId { get; set; }
        public string AccountNumber { get; set; }
        public string EmailAddress { get; set; }

        public int Version { get; set; }
    }
}