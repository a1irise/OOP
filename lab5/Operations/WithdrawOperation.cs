using lab5.Accounts;

namespace lab5.Operations
{
    public class WithdrawOperation : Operation
    {
        public double Amount { get; }

        public WithdrawOperation(string ownerId, double amount)
            : base(ownerId)
        {
            Amount = amount;
        }

        public override void Undo(Account account)
        {
            account.Deposit(Amount);
            Canceled = true;
        }
    }
}