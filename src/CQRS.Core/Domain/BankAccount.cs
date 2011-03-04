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

            ApplyChange(new TransationPostedEvent
            {
                Amount = transaction.Amount,
                BankAccountId = id,
                Description = transaction.Description,
                TransactionDate = transaction.TransactionDate
            });

            if (balance <= -100) // if account is overdrawn by over 100 dollars, lock it
            {
                isLocked = true;
                ApplyChange(new AccountLockedEvent { BankAccountId = id, Balance = balance, TransactionAmount = transaction.Amount });
            }

            if (balance < 0)
            {
                ApplyChange(new AccountOverdrawnEvent { BankAccountId = id, Balance = balance, TransactionAmount = transaction.Amount }); 
            }
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