using System;

namespace lab5
{
    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException()
            : base($"Not enough funds to complete operation.")
        { }
    }

    public class ExceedsQuestionableAccountTransferLimitException : Exception
    {
        public ExceedsQuestionableAccountTransferLimitException()
            : base($"Please verify your account to complete operation.")
        { }
    }
}