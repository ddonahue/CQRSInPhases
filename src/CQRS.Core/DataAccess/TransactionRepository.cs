using System;

namespace CQRS.Core.DataAccess
{
    public class TransactionRepository : IRepository<TransactionEntity>
    {
        private readonly CQRSDataContext dataContext;

        public TransactionRepository()
        {
            dataContext = new CQRSDataContext();
        }

        public TransactionEntity LoadById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void CreateNewEntity(TransactionEntity transaction)
        {
            dataContext.TransactionEntities.InsertOnSubmit(transaction);
        }

        public void SaveChanges()
        {
            dataContext.SubmitChanges();
        }
    }
}