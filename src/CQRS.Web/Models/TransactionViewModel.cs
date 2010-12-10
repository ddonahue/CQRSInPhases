using System;

namespace CQRS.Web.Models
{
    public class TransactionViewModel
    {
        public Guid BankAccountId { get; set; }
        public int TransactionId { get; set; }

        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}