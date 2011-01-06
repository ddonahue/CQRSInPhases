using System;
using System.Linq;

namespace CQRS.Core.DataAccess
{
    public class BankAccountRepository : IRepository<BankAccountEntity>
    {
        private readonly CQRSDataContext dataContext;

        public BankAccountRepository()
        {
            dataContext = new CQRSDataContext();
        }

        public BankAccountEntity LoadById(Guid id)
        {
            return dataContext.BankAccountEntities.Single(x => x.BankAccountId == id);
        }

        public void CreateNewEntity(BankAccountEntity entity)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            dataContext.SubmitChanges();
        }
    }
}