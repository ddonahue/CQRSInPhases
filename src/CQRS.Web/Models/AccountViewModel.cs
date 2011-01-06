using System;

namespace CQRS.Web.Models
{
    public class AccountViewModel
    {
        public Guid BankAccountId { get; set; }
        public string AccountNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}