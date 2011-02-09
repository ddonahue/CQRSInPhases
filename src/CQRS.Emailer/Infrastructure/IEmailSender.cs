using Messages.Events;

namespace CQRS.Emailer.Infrastructure
{
    public interface IEmailSender
    {
        void SendAccountLockedEmail(string emailAddress, AccountLockedEvent @event);
        void SendNegativeBalanceEmail(string emailAddress, AccountOverdrawnEvent @event);
    }
}