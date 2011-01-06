using System.Collections.Generic;
using CQRS.Core.DataAccess;

namespace CQRS.Web.Models
{
    public class TransactionsIndexViewModel
    {
        public BankAccountEntity Account { get; set; }
        public IEnumerable<TransactionEntity> Transactions { get; set; }
    }
}