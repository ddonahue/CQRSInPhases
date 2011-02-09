using System;
using Messages.Events;

namespace CQRS.Emailer.Infrastructure
{
    public class EmailSender : IEmailSender
    {
        public void SendAccountLockedEmail(string emailAddress, AccountLockedEvent @event)
        {
            Console.WriteLine("TO: " + emailAddress);
            Console.WriteLine("BODY:");
            Console.Write("Your last transaction of {0} has caused your account to be overdrawn.  Your current balance is {1}.", @event.TransactionAmount.ToString("C"), @event.TransactionAmount.ToString("C"));
        }

        public void SendNegativeBalanceEmail(string emailAddress, AccountOverdrawnEvent @event)
        {
            Console.WriteLine("TO: " + emailAddress);
            Console.WriteLine("BODY:");
            Console.Write("Your last transaction of {0} has caused your account to be overdrawn.  Your current balance is {1}.", @event.TransactionAmount.ToString("C"), @event.Balance.ToString("C"));
        }
    }
}