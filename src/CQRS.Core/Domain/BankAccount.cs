using System;
using CQRS.Core.Domain.Exceptions;
using CQRS.Core.Events;

namespace CQRS.Core.Domain
{
    public class BankAccount
    {
        public Guid BankAccountId { get; private set; }
        public bool IsLocked { get; private set; }
        public decimal Balance { get; private set; }

        public BankAccount(Guid bankAccountId, decimal balance, bool isLocked)
        {
            BankAccountId = bankAccountId;
            Balance = balance;
            IsLocked = isLocked;
        }

        public void PostNewTransaction(Transaction transaction)
        {
            if (IsLocked) throw new AccountLockedException(this.BankAccountId);

            var remainingBalance = Balance + transaction.Amount;
            if (remainingBalance <= -100)
            {
                DomainEvents.Raise(new AccountLockedEvent {BankAccountId = this.BankAccountId});
            }
            else if (remainingBalance < 0)
            {
                DomainEvents.Raise(new AccountOverdrawnEvent { BankAccountId = this.BankAccountId }); 
            }

            DomainEvents.Raise(new TransationPostedEvent
                                   {
                                       Amount = transaction.Amount,
                                       BankAccountId = this.BankAccountId,
                                       Description =  transaction.Description,
                                       TransactionDate = transaction.TransactionDate
                                   });
        }
    }
}