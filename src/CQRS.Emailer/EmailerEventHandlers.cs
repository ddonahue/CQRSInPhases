using System.Linq;
using CQRS.Emailer.DataAccess;
using CQRS.Emailer.Infrastructure;
using Messages.Events;
using NServiceBus;

namespace CQRS.Emailer
{
    public class EmailerEventHandlers : IHandleMessages<AccountLockedEvent>, IHandleMessages<AccountOverdrawnEvent>
    {
        private readonly IEmailSender emailSender;

        public EmailerEventHandlers()
        {
            emailSender = new EmailSender();
        }

        public void Handle(AccountLockedEvent @event)
        {
            using (var dataContext = new CQRSDataContext())
            {
                var emailAddress = dataContext.BankAccounts.First(x => x.BankAccountId == @event.BankAccountId).EmailAddress;
                emailSender.SendAccountLockedEmail(emailAddress, @event);
            }
        }

        public void Handle(AccountOverdrawnEvent @event)
        {
            using (var dataContext = new CQRSDataContext())
            {
                var emailAddress = dataContext.BankAccounts.First(x => x.BankAccountId == @event.BankAccountId).EmailAddress;
                emailSender.SendNegativeBalanceEmail(emailAddress, @event);
            }
        }
    }
}
