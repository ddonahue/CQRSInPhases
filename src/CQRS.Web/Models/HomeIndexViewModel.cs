using System.Collections.Generic;
using CQRS.Core.DataAccess;

namespace CQRS.Web.Models
{
    public class HomeIndexViewModel
    {
        public IEnumerable<BankAccountEntity> BankAccounts { get; set; }
    }
}