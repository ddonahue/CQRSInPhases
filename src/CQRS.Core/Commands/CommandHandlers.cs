using CQRS.Core.DataAccess;
using CQRS.Core.Domain;
using Messages.Commands;
using NServiceBus;

namespace CQRS.Core.Commands
{
    public class CommandHandlers : IHandleMessages<CreateAccountCommand>, IHandleMessages<PostTransactionCommand>
    {
        // TODO:  Need to figure out how to build up an object using NServiceBus with constructor injection for the repository
        // instead of newing it up in each handler method.

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

            var transaction = new Transaction(command.Amount, command.Description, command.TransactionDate);
            bankAccount.PostNewTransaction(transaction);

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