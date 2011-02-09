using System.Collections.Generic;
using CQRS.Web.DataAccess;

namespace CQRS.Web.Models
{
    public class HomeIndexViewModel
    {
        public IEnumerable<BankAccount> BankAccounts { get; set; }
    }
}