namespace lab5.Accounts
{
    public class DebitAccount : Account
    {
        public DebitAccount(string ownerId, double limit, int percent)
            : base(ownerId, limit)
        {
            Amount = 0;
            Percent = percent / 365;
            Limit = 0;
            Commission = 0;
        }
    }
}