using System.Linq;
using CQRS.Core.DataAccess;

namespace CQRS.Core.Commands
{
    public class CommandHandlers
    {
        private readonly IRepository<BankAccountEntity> repository;

        public CommandHandlers()
        {
            repository = new BankAccountRepository();
        }

        public void Handle(PostTransactionCommand command)
        {
            var bankAccountEntity = repository.LoadById(command.BankAccountId);
            var bankAccount = MapEntityToDomainObject(bankAccountEntity);

            var transaction = new Domain.Transaction(command.Amount, command.Description, command.TransactionDate);
            bankAccount.PostNewTransaction(transaction);
        }

        private static Domain.BankAccount MapEntityToDomainObject(BankAccountEntity bankAccountEntity)
        {
            var balance = bankAccountEntity.TransactionEntities.Sum(x => x.Amount);
            var bankAccount = new Domain.BankAccount(bankAccountEntity.BankAccountId, balance, bankAccountEntity.Locked);
            return bankAccount;
        }
    }
}