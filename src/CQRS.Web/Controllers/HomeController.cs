using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CQRS.Core.DataAccess;
using CQRS.Web.Models;

namespace CQRS.Web.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<BankAccountEntity> bankAccounts;
            using (var dataContext = new CQRSDataContext())
            {
                bankAccounts = dataContext.BankAccountEntities.ToList();
            }

            var model = new HomeIndexViewModel {BankAccounts = bankAccounts};

            return View(model);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(AccountViewModel model)
        {
            var account = new BankAccountEntity
                              {
                                  BankAccountId = Guid.NewGuid(),
                                  AccountNumber = model.AccountNumber,
                                  EmailAddress =  model.EmailAddress
                              };

            using (var dataContext = new CQRSDataContext())
            {
                dataContext.BankAccountEntities.InsertOnSubmit(account);
                dataContext.SubmitChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid id)
        {
            var model = new AccountViewModel();
            using (var dataContext = new CQRSDataContext())
            {
                var account = dataContext.BankAccountEntities.Single(x => x.BankAccountId == id);

                model.BankAccountId = account.BankAccountId;
                model.AccountNumber = account.AccountNumber;
                model.EmailAddress = account.EmailAddress;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(AccountViewModel model)
        {
            using (var dataContext = new CQRSDataContext())
            {
                var account = dataContext.BankAccountEntities.Single(x => x.BankAccountId == model.BankAccountId);
                account.AccountNumber = model.AccountNumber;
                account.EmailAddress = model.EmailAddress;
                dataContext.SubmitChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
