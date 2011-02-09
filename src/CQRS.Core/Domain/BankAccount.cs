using System;
using CQRS.Core.Domain.Exceptions;
using Messages.Events;

namespace CQRS.Core.Domain
{
    public class BankAccount : AggregateRoot
    {
        private bool isLocked;
        private Guid id;
        private decimal balance;

        public override Guid Id
        {
            get { return id; }
        }

        public BankAccount()
        {
        }

        public BankAccount(Guid id, string accountNumber, string emailAddress)
        {
            ApplyChange(new AccountCreatedEvent { BankAccountId = id, AccountNumber = accountNumber, EmailAddress = emailAddress, Version = 0 });
        }

        public void PostNewTransaction(Transaction transaction)
        {
            if (isLocked) throw new AccountLockedException(id);

            var remainingBalance = balance + transaction.Amount;
            if (remainingBalance <= -100)
            {
                ApplyChange(new AccountLockedEvent {BankAccountId = id, Balance = remainingBalance, TransactionAmount = transaction.Amount});
            }
            else if (remainingBalance < 0)
            {
                ApplyChange(new AccountOverdrawnEvent { BankAccountId = id, Balance = remainingBalance, TransactionAmount = transaction.Amount }); 
            }

            ApplyChange(new TransationPostedEvent
                                   {
                                       Amount = transaction.Amount,
                                       BankAccountId = id,
                                       Description =  transaction.Description,
                                       TransactionDate = transaction.TransactionDate
                                   });
        }

        private void Apply(AccountCreatedEvent e)
        {
            id = e.BankAccountId;
            isLocked = false;
        }

        private void Apply(AccountLockedEvent e)
        {
            isLocked = true;
        }

        private void Apply(TransationPostedEvent e)
        {
            balance += e.Amount;
        }
    }
}