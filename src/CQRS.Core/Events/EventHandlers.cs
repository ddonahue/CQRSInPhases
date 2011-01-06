using CQRS.Core.DataAccess;
using CQRS.Core.Infrastructure;

namespace CQRS.Core.Events
{
    public class EventHandlers
    {
        private readonly IRepository<BankAccountEntity> bankAccountRepository;
        private readonly IRepository<TransactionEntity> transactionRepository;
        private readonly IEmailSender emailSender;

        public EventHandlers()
        {
            bankAccountRepository = new BankAccountRepository();
            transactionRepository = new TransactionRepository();
            emailSender = new EmailSender();
        }

        public void Handle(AccountLockedEvent @event)
        {
            var bankAccount = bankAccountRepository.LoadById(@event.BankAccountId);
            bankAccount.Locked = true;
            bankAccountRepository.SaveChanges();

            emailSender.SendAccountLockedEmail(bankAccount.EmailAddress);
        }

        public void Handle(AccountOverdrawnEvent @event)
        {
            var bankAccount = bankAccountRepository.LoadById(@event.BankAccountId);
            emailSender.SendNegativeBalanceEmail(bankAccount.EmailAddress);
        }

        public void Handle(TransationPostedEvent @event)
        {
            var transaction = new TransactionEntity
                                  {
                                      BankAccountId = @event.BankAccountId,
                                      Amount = @event.Amount,
                                      Description = @event.Description,
                                      TransactionDate = @event.TransactionDate
                                  };

            transactionRepository.CreateNewEntity(transaction);
            transactionRepository.SaveChanges();
        }
    }
}