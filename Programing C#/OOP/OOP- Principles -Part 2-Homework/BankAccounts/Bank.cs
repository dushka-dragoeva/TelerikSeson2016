namespace BankAccounts
{
    using System.Collections.Generic;
    using System.Text;
    using Utilities.Validators;

    internal class Bank
    {
        private string name;
        private string address;
        private ICollection<Account> accounts;

        public Bank(string name)
            : this(name, string.Empty)
        {
        }

        public Bank(string name, string address)
        {
            this.Name = name;
            this.Address = address;
            this.Accounts = new HashSet<Account>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                this.name = value.ValidateRange(2, 30);
            }
        }

        public string Address
        {
            get
            {
                return this.address;
            }

            set
            {
                this.address = value;
            }
        }

        public virtual ICollection<Account> Accounts
        {
            get
            {
                return this.accounts.ValidateIsNotNullOrEmpty<Account>();
            }

            private set
            {
                this.accounts = value.ValidateIsNotNullOrEmpty<Account>();
            }
        }

        public void AddAccount(Account account)
        {
            this.Accounts.Add(account);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(this.Name);
            sb.AppendLine();

            foreach (var account in this.Accounts)
            {
                sb.AppendLine(account.ToString());
            }

            return sb.ToString();
        }
    }
}
