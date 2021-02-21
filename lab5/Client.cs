using System;
using System.Collections.Generic;
using lab5.Accounts;

namespace lab5
{
    public class Client
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Address { get; private set; }
        public uint Passport { get; private set; }

        public string Id { get; }
        public List<Account> Accounts { get; }
        public bool Verified { get; protected set; }

        public Client(string firstName, string lastName, string address = "", uint passport = 0)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Passport = passport;

            Id = Guid.NewGuid().ToString();
            Accounts = new List<Account>();
            if (address != "" && passport != 0)
                Verified = true;
        }

        public void Verify(string address, uint passport)
        {
            if (Verified)
                return;

            Address = address;
            Passport = passport;
            Verified = true;
            foreach (var account in Accounts)
                account.Questionable = false;
        }

        public void AddAccount(Account account)
        {
            Accounts.Add(account);
        }
    }
}