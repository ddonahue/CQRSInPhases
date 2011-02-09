using System.Collections.Generic;
using CQRS.Web.DataAccess;

namespace CQRS.Web.Models
{
    public class TransactionsIndexViewModel
    {
        public BankAccount Account { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}