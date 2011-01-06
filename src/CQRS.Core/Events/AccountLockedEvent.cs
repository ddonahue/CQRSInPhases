using System;

namespace CQRS.Core.Events
{
    public class AccountLockedEvent : IDomainEvent
    {
        public Guid BankAccountId { get; set; }
    }
}