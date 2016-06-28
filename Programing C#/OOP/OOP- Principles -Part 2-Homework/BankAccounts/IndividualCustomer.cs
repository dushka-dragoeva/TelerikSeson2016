namespace BankAccounts
{
    public class IndividualCustomer : Customer
    {
        public IndividualCustomer(string name)
            : this(name, string.Empty, string.Empty, string.Empty)
        {
        }

        public IndividualCustomer(string name, string address)
            : this(name, address, string.Empty, string.Empty)
        {
        }

        public IndividualCustomer(string name, string address, string email)
            : this(name, address, email, string.Empty)
        {
        }

        public IndividualCustomer(string name, string address, string email, string phoneNumber)
            : base(name, address, email, phoneNumber)
        {
            this.CustomerType = CustomerType.Individual;
        }
    }
}
