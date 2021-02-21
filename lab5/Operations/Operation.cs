using System;
using lab5.Accounts;

namespace lab5.Operations
{
    public abstract class Operation
    {
        public string Id { get; }
        public string OwnerId { get; }
        public bool Canceled { get; protected set; }

        protected Operation(string ownerId)
        {
            Id = Guid.NewGuid().ToString();
            OwnerId = ownerId;
        }

        public abstract void Undo(Account account);
    }
}