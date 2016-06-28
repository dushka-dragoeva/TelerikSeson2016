namespace BankAccounts
{
    using System;
    using System.Text;
    using BankAccounts.Interface;

    public abstract class Account : ICalculalionOfInterest, IDeposit
    {
        private const string NegativeRateExceptionMsg = "Montly interest rate cannot be negative.";

        private Customer customer;
        private decimal balance;
        private decimal interestPerMonth;

        protected Account(Customer customer, decimal balance, decimal interestPerMonth)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestPerMonth = interestPerMonth;
        }

        public Customer Customer
        {
            get
            {
                return this.customer;
            }

            private set
            {
                this.customer = value;
            }
        }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }

            protected set
            {
                this.balance = value;
            }
        }

        public decimal InterestPerMonth
        {
            get
            {
                return this.interestPerMonth;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(NegativeRateExceptionMsg);
                }

                this.interestPerMonth = value;
            }
        }

        public AccountType AccountType { get; protected set; }

        public abstract decimal InterestCalculaion(int months);

        public abstract void Deposit(decimal sum);

        public override string ToString()
        {
            var text = new StringBuilder();

            text.AppendLine("Account: " + this.AccountType)
                .AppendLine("Balance: " + this.Balance)
                .AppendLine("Interest per month: " + this.InterestPerMonth)
                .AppendLine("Customer:" + Customer.ToString());

            return text.ToString();
        }
    }
}
