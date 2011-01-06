namespace CQRS.Core.Infrastructure
{
    public interface IEmailSender
    {
        void SendAccountLockedEmail(string emailAddress);
        void SendNegativeBalanceEmail(string emailAddress);
    }
}