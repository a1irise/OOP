using System;
using System.Collections.Generic;
using lab5.Operations;

namespace lab5.Accounts
{
    public abstract class Account
    {
        public string Id { get; }
        public string OwnerId { get; }
        public List<Operation> Operations { get; }

        public double Amount { get; protected set; }
        public int Percent { get; protected set; }
        public double Limit { get; protected set; }
        public double Commission { get; protected set; }
        public double QuestionableAccountTransferLimit { get; protected set; }
        public bool Questionable { get; set; }

        protected Account(string ownerId, double limit)
        {
            Id = Guid.NewGuid().ToString();
            OwnerId = ownerId;
            Operations = new List<Operation>();
            QuestionableAccountTransferLimit = limit;
        }

        public void Deposit(double amount)
        {
            Amount += amount;
            Operations.Add(new DepositOperation(Id, amount));
        }

        public void Withdraw(double amount)
        {
            if (Amount - amount < Limit)
                throw new InsufficientFundsException();

            if (Questionable && amount > QuestionableAccountTransferLimit)
                throw new ExceedsQuestionableAccountTransferLimitException();

            Amount -= amount;
            Operations.Add(new WithdrawOperation(Id, amount));
        }

        public void Transfer(Account recipient, double amount)
        {
            if (Amount - amount < Limit)
                throw new InsufficientFundsException();

            if (Questionable && amount > QuestionableAccountTransferLimit)
                throw new ExceedsQuestionableAccountTransferLimitException();

            Amount -= amount;
            recipient.Deposit(amount);
            Operations.Add(new TransferOperation(Id, recipient, amount));
        }

        public void UndoOperation(string id)
        {
            var operation = FindOperation(id);
            if (operation != null && !operation.Canceled)
                operation.Undo(this);
        }

        public Operation FindOperation(string id)
        {
            foreach (var operation in Operations)
                if (operation.Id == id)
                    return operation;

            return null;
        }

        private double _percentage;

        public void CalcPercentage()
        {
            _percentage += Amount * Percent / 100;
        }

        public void AddPercentage()
        {
            Amount += _percentage;
            _percentage = 0;
        }

        public void DeductCommission()
        {
            if (Amount < 0)
                Amount -= Commission;
        }
    }
}