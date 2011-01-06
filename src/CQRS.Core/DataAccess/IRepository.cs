using System;

namespace CQRS.Core.DataAccess
{
    public interface IRepository<T>
    {
        T LoadById(Guid id);
        void CreateNewEntity(T entity);
        void SaveChanges();
    }
}