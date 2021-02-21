using System;
using System.Collections.Generic;
using lab5.Accounts;

namespace lab5
{
    public class Bank
    {
        public string Id { get; }
        private List<Client> Clients { get; }
        private List<Account> Accounts { get; }

        public int DebitAccountPercent { get; set; }
        public int CreditAccountLimit { get; set; }
        public double CreditAccountCommission { get; set; }
        public int DepositAccountPercent1 { get; set; }
        public int DepositAccountPercent2 { get; set; }
        public int DepositAccountPercent3 { get; set; }
        public double QuestionableAccountTransferLimit { get; set; }

        public Bank(int debitAccountPercent, int creditAccountLimit, double creditAccountCommission, int depositAccountPercent1, int depositAccountPercent2, int depositAccountPercent3, double suspiciousAccountTransferLimit)
        {
            Id = Guid.NewGuid().ToString();
            Clients = new List<Client>();
            Accounts = new List<Account>();

            DebitAccountPercent = debitAccountPercent;
            CreditAccountLimit = creditAccountLimit;
            CreditAccountCommission = creditAccountCommission;
            DepositAccountPercent1 = depositAccountPercent1;
            DepositAccountPercent2 = depositAccountPercent2;
            DepositAccountPercent3 = depositAccountPercent3;
            QuestionableAccountTransferLimit = suspiciousAccountTransferLimit;
        }

        private bool FindClient(string id)
        {
            foreach (var client in Clients)
                if (client.Id == id)
                    return true;
            return false;
        }

        public void AddClient(Client client)
        {
            if (!FindClient(client.Id))
                Clients.Add(client);
        }

        public DebitAccount AddDebitAccount(Client client)
        {
            if (!FindClient(client.Id))
                Clients.Add(client);

            var account = new DebitAccount(client.Id, QuestionableAccountTransferLimit, DebitAccountPercent);

            if (!client.Verified)
                account.Questionable = true;
            
            client.AddAccount(account);
            Accounts.Add(account);
            return account;
        }

        public DepositAccount AddDepositAccount(Client client, double initialDeposit, DateTime EndDate)
        {
            if (!FindClient(client.Id))
                Clients.Add(client);

            int depositAccountPercent;
            if (initialDeposit > 100000)
                depositAccountPercent = DepositAccountPercent1;
            else if (initialDeposit > 50000)
                depositAccountPercent = DepositAccountPercent2;
            else
                depositAccountPercent = DepositAccountPercent3;

            var account = new DepositAccount(client.Id, QuestionableAccountTransferLimit, initialDeposit, EndDate, depositAccountPercent);
            if (!client.Verified)
                account.Questionable = true;
            client.AddAccount(account);
            Accounts.Add(account);
            return account;
        }

        public CreditAccount AddCreditAccount(Client client)
        {
            if (!FindClient(client.Id))
                Clients.Add(client);

            var account = new CreditAccount(client.Id, QuestionableAccountTransferLimit, CreditAccountLimit, CreditAccountCommission);
            if (!client.Verified)
                account.Questionable = true;
            client.AddAccount(account);
            Accounts.Add(account);
            return account;
        }

        public List<Account> GetAccountsOnDate(DateTime date)
        {
            var ret = Accounts;
            var currentDate = DateTime.Now;

            while (currentDate < date)
            {
                foreach (var account in ret)
                {
                    account.CalcPercentage();
                    if (currentDate.Day == 1)
                    {
                        account.DeductCommission();
                        account.AddPercentage();
                    }
                }

                currentDate = currentDate.AddDays(1);
            }

            return ret;
        }

        public void UndoOperation(Account account, string operationId)
        {
            var operation = account.FindOperation(operationId);
            operation.Undo(account);
        }
    }
}