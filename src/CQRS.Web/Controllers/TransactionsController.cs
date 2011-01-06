using System;
using System.Linq;
using System.Web.Mvc;
using CQRS.Core.Commands;
using CQRS.Core.DataAccess;
using CQRS.Web.Models;

namespace CQRS.Web.Controllers
{
    public class TransactionsController : Controller
    {
        public CommandBus bus;

        public TransactionsController()
        {
            bus = ServiceLocator.CommandBus;
        }

        public ActionResult Index(Guid id)
        {
            using (var dataContext = new CQRSDataContext())
            {
                var account = dataContext.BankAccountEntities.Single(x => x.BankAccountId == id);

                var model = new TransactionsIndexViewModel
                                {
                                    Account = account,
                                    Transactions = account.TransactionEntities.OrderBy(x => x.TransactionDate).ToList()
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
            bus.Send(command);
            return RedirectToAction("Index", new { id = model.BankAccountId });
            //using (var dataContext = new CQRSDataContext())
            //{
            //    var balance = dataContext.Transactions.Where(x => x.BankAccountId == model.BankAccountId).OrderBy(x => x.TransactionDate).Sum(x => x.Amount);
            //    var newBalance = balance + model.Amount;

            //    var emailSender = new EmailSender();
            //    if (newBalance < 100)
            //    {
            //        var bankAccount = dataContext.BankAccounts.Single(x => x.BankAccountId == model.BankAccountId);
            //        bankAccount.Locked = true;
            //        dataContext.SubmitChanges();
            //        emailSender.SendAccountLockedEmail(bankAccount);
            //        return redirect;
            //    }

            //    dataContext.Transactions.InsertOnSubmit(transaction);
            //    if (newBalance < 0)
            //    {
            //        var bankAccount = dataContext.BankAccounts.Single(x => x.BankAccountId == model.BankAccountId);
            //        emailSender.SendNegativeBalanceEmail(bankAccount);
            //    }

            //    dataContext.SubmitChanges();
            //}

            //return redirect;
        }

        public ActionResult Edit(int id)
        {
            using (var dataContext = new CQRSDataContext())
            {
                var transaction = dataContext.TransactionEntities.Single(x => x.TransactionId == id);
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
                var transaction = dataContext.TransactionEntities.Single(x => x.TransactionId == model.TransactionId);
                transaction.Amount = model.Amount;
                transaction.Description = model.Description;
                transaction.TransactionDate = model.TransactionDate;
                dataContext.SubmitChanges();
            }

            return RedirectToAction("Index", new { id = model.BankAccountId });
        }
    }
}
