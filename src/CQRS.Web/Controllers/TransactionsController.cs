using System;
using System.Linq;
using System.Web.Mvc;
using CQRS.Core.DataAccess;
using CQRS.Web.Models;

namespace CQRS.Web.Controllers
{
    public class TransactionsController : Controller
    {
        public ActionResult Index(Guid id)
        {
            var model = new TransactionsIndexViewModel();
            using (var dataContext = new CQRSDataContext())
            {
                var account = dataContext.BankAccounts.Single(x => x.BankAccountId == id);

                model.Account = account;
                model.Transactions = account.Transactions.OrderBy(x => x.TransactionDate).ToList();
            }

            return View(model);
        }

        public ActionResult Add(Guid bankAccountId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(TransactionViewModel model)
        {
            var transaction = new Transaction
            {
                BankAccountId = model.BankAccountId,
                Amount = model.Amount,
                Description = model.Description,
                TransactionDate = model.TransactionDate
            };

            using (var dataContext = new CQRSDataContext())
            {
                dataContext.Transactions.InsertOnSubmit(transaction);
                dataContext.SubmitChanges();
            }

            return RedirectToAction("Index", new { id = model.BankAccountId });
        }

        public ActionResult Edit(int id)
        {
            var model = new TransactionViewModel();
            using (var dataContext = new CQRSDataContext())
            {
                var transaction = dataContext.Transactions.Single(x => x.TransactionId == id);

                model.BankAccountId = transaction.BankAccountId;
                model.Amount = transaction.Amount;
                model.Description = transaction.Description;
                model.TransactionDate = transaction.TransactionDate;
                model.TransactionId = transaction.TransactionId;
            }

            return View(model);
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
