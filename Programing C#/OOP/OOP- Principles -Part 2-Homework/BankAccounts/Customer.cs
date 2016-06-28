namespace BankAccounts
{
    using System.Collections.Generic;

    using Utilities.Validators;

    public abstract class Customer
    {
        private CustomerType customerType;
        private string name;
        private string address;
        private string email;
        private string phoneNumber;
        private ICollection<Account> accounts;

        protected Customer(string name, string address, string email, string phoneNumber)
        {
            this.Name = name;
            this.Address = address;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
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
                this.name = value.ValidateRange(2, 50);
            }
        }

        public CustomerType CustomerType
        {
            get
            {
                return this.customerType;
            }

            protected set
            {
                this.customerType = value;
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

        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                this.email = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }

            set
            {
                this.phoneNumber = value;
            }
        }

        public ICollection<Account> Accounts
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

        public override string ToString()
        {
            return this.Name + " - " + this.CustomerType;
        }
    }
}
