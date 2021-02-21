using lab5.Accounts;

namespace lab5.Operations
{
    public class DepositOperation : Operation
    {
        public double Amount { get; }

        public DepositOperation(string ownerId, double amount)
            : base(ownerId)
        {
            Amount = amount;
        }

        public override void Undo(Account account)
        {
            account.Withdraw(Amount);
            Canceled = true;
        }
    }
}