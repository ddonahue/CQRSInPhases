using System;
using System.Linq;
using System.Web.Mvc;
using CQRS.Web.DataAccess;
using CQRS.Web.Models;
using Messages.Commands;

namespace CQRS.Web.Controllers
{
    public class TransactionsController : Controller
    {
        public ActionResult Index(Guid id)
        {
            using (var dataContext = new CQRSDataContext())
            {
                var account = dataContext.BankAccounts.Single(x => x.BankAccountId == id);

                var model = new TransactionsIndexViewModel
                                {
                                    Account = account,
                                    Transactions = account.Transactions.OrderBy(x => x.TransactionDate).ToList()
                                };

                return View(model);
            }
        }

        public ActionResult Add(Guid bankAccountId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(TransactionViewModel model)
        {
            var command = new PostTransactionCommand(model.BankAccountId, model.Amount, model.Description,
                                                         model.TransactionDate);
            MvcApplication.Bus.Send(command);
            return RedirectToAction("Index", new { id = model.BankAccountId });
        }

        public ActionResult Edit(int id)
        {
            using (var dataContext = new CQRSDataContext())
            {
                var transaction = dataContext.Transactions.Single(x => x.TransactionId == id);
                var model = new TransactionViewModel
                                {
                                    BankAccountId = transaction.BankAccountId,
                                    Amount = transaction.Amount,
                                    Description = transaction.Description,
                                    TransactionDate = transaction.TransactionDate,
                                    TransactionId = transaction.TransactionId
                                };
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Edit(TransactionViewModel model)
        {
            using (var dataContext = new CQRSDataContext())
            {
                var transaction = dataContext.Transactions.Single(x => x.TransactionId == model.TransactionId);
                transaction.Amount = model.Amount;
                transaction.Description = model.Description;
                transaction.TransactionDate = model.TransactionDate;
                dataContext.SubmitChanges();
            }

            return RedirectToAction("Index", new { id = model.BankAccountId });
        }
    }
}
