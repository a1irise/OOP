using System;

namespace lab5.Accounts
{
    public class DepositAccount : Account
    {
        public DateTime Date { get; }

        public DepositAccount(string ownerId, double limit, double initialDeposit, DateTime date, int percent)
            : base(ownerId, limit)
        {
            Amount = initialDeposit;
            Date = date;
            Percent = percent / 365;
            Limit = 0;
            Commission = 0;
        }
    }
}