using System;

namespace Messages.Commands
{
    public class CreateAccountCommand : ICommand
    {
        public Guid BankAccountId { get; private set; }
        public string AccountNumber { get; private set; }
        public string EmailAddress { get; private set; }

        public CreateAccountCommand(Guid bankAccountId, string accountNumber, string emailAddress)
        {
            BankAccountId = bankAccountId;
            AccountNumber = accountNumber;
            EmailAddress = emailAddress;
        }
    }
}