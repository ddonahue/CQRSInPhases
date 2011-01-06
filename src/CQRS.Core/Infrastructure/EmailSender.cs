using CQRS.Core.DataAccess;

namespace CQRS.Core.Infrastructure
{
    public class EmailSender : IEmailSender
    {
        public void SendAccountLockedEmail(string emailAddress)
        {
            // send some email about account being locked.
        }

        public void SendNegativeBalanceEmail(string emailAddress)
        {
            // send some email about account being overdrawn.
        }
    }
}