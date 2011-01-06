using System;

namespace CQRS.Core.Domain.Exceptions
{
    public class AccountLockedException : ApplicationException
    {
        public AccountLockedException(Guid bankAccountId) : base(string.Format("Account Locked: {0}", bankAccountId))
        {
            BankAccountId = bankAccountId;
        }

        public Guid BankAccountId { get; private set; }
    }
}