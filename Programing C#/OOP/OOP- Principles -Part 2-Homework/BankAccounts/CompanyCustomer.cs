namespace BankAccounts
{
    public class CompanyCustomer : Customer
    {
        private string contactPersonName;

        public CompanyCustomer(string name)
            : this(name, string.Empty, string.Empty, string.Empty)
        {
        }

        public CompanyCustomer(string name, string address)
            : this(name, address, string.Empty, string.Empty)
        {
        }

        public CompanyCustomer(string name, string address, string email)
            : this(name, address, email, string.Empty)
        {
        }

        public CompanyCustomer(string name, string address, string email, string phoneNumber)
            : base(name, address, email, phoneNumber)
        {
            this.ContactPersonName = contactPersonName;
            this.CustomerType = CustomerType.Company;
        }

        public string ContactPersonName
        {
            get
            {
                return this.contactPersonName;
            }

            set
            {
                this.contactPersonName = value;
            }
        }
    }
}
