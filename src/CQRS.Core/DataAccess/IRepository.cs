using System;
using CQRS.Core.Domain;

namespace CQRS.Core.DataAccess
{
    public interface IRepository<T> where T : AggregateRoot
    {
        T LoadById(Guid aggregateId);
        void Save(AggregateRoot aggregateRoot);
    }
}