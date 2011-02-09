using System;

namespace CQRS.Core.DataAccess
{
    public class ConcurrencyException : Exception
    {
        public ConcurrencyException(Guid id, int version)
        {
            throw new NotImplementedException();
        }
    }
}