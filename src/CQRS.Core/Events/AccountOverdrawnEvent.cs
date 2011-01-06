using System;

namespace CQRS.Core.Events
{
    public class AccountOverdrawnEvent : IDomainEvent
    {
        public Guid BankAccountId { get; set; }
    }
}