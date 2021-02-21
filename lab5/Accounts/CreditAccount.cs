namespace lab5.Accounts
{
    public class CreditAccount : Account
    {
        public CreditAccount(string ownerId, double limit, double creditLimit, double commission)
            : base(ownerId, limit)
        {
            Amount = 0;
            Percent = 0;
            Limit = creditLimit;
            Commission = commission;
        }
    }
}