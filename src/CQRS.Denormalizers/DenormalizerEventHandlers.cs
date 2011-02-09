using System.Linq;
using CQRS.Denormalizers.DataAccess;
using Messages.Events;
using NServiceBus;

namespace CQRS.Denormalizers
{
    public class DenormalizerEventHandlers : IHandleMessages<AccountCreatedEvent>, IHandleMessages<TransationPostedEvent>, IHandleMessages<AccountLockedEvent>
    {
        public void Handle(AccountCreatedEvent @event)
        {
            var bankAccount = new BankAccount
                                  {
                                      BankAccountId = @event.BankAccountId,
                                      AccountNumber = @event.AccountNumber,
                                      Balance = 0,
                                      EmailAddress = @event.EmailAddress,
                                      Locked = false
                                  };

            using (var dataContext = new CQRSDataContext())
            {
                dataContext.BankAccounts.InsertOnSubmit(bankAccount);
                dataContext.SubmitChanges();
            }
        }

        public void Handle(TransationPostedEvent @event)
        {
            var transaction = new Transaction
                                  {
                                      BankAccountId = @event.BankAccountId,
                                      Amount = @event.Amount,
                                      Description = @event.Description,
                                      TransactionDate = @event.TransactionDate
                                  };

            using (var dataContext = new CQRSDataContext())
            {
                dataContext.Transactions.InsertOnSubmit(transaction);

                var bankAccount = dataContext.BankAccounts.First(x => x.BankAccountId == @event.BankAccountId);
                bankAccount.Balance += @event.Amount;

                dataContext.SubmitChanges();
            }
        }

        public void Handle(AccountLockedEvent @event)
        {
            using (var dataContext = new CQRSDataContext())
            {
                var bankAccount = dataContext.BankAccounts.First(x => x.BankAccountId == @event.BankAccountId);
                bankAccount.Locked = true;
                dataContext.SubmitChanges();
            }
        }
    }
}
