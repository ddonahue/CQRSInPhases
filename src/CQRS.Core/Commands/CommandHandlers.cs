using CQRS.Core.DataAccess;
using CQRS.Core.Domain;
using CQRS.Core.Domain.Exceptions;
using Messages.Commands;
using NServiceBus;

namespace CQRS.Core.Commands
{
    public class CommandHandlers : IHandleMessages<CreateAccountCommand>, IHandleMessages<PostTransactionCommand>
    {
        public IBus Bus { get; set; }

        public void Handle(CreateAccountCommand command)
        {
            var repository = new Repository<BankAccount>();
            var bankAccount = new BankAccount(command.BankAccountId, command.AccountNumber, command.EmailAddress);
            repository.Save(bankAccount);

            PublishEvents(bankAccount);
        }

        public void Handle(PostTransactionCommand command)
        {
            var repository = new Repository<BankAccount>();
            var bankAccount = repository.LoadById(command.BankAccountId);
            try
            {
                var transaction = new Transaction(command.Amount, command.Description, command.TransactionDate);
                bankAccount.PostNewTransaction(transaction);
            }
            catch(AccountLockedException)
            {
                // send an email here to let the customer know that their account is locked and therefore this transaction cannot be processed
                // in reality, this should be VERY rare since we can validate on the read side whether or not the account is locked before we
                // attempt to post the transaction

                return;
            }

            repository.Save(bankAccount);

            PublishEvents(bankAccount);
        }

        private void PublishEvents(AggregateRoot aggregateRoot)
        {
            foreach (var @event in aggregateRoot.GetUncommittedChanges())
            {
                Bus.Publish(@event);
            }
            aggregateRoot.MarkChangesAsCommitted();
        }
    }
}