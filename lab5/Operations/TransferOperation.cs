using lab5.Accounts;

namespace lab5.Operations
{
    public class TransferOperation : Operation
    {
        public double Amount { get; }
        public Account Recipient { get; }

        public TransferOperation(string ownerId, Account recipient, double amount)
            : base(ownerId)
        {
            Amount = amount;
            Recipient = recipient;
        }

        public override void Undo(Account account)
        {
            Recipient.Transfer(account, Amount);
            Canceled = true;
        }
    }
}