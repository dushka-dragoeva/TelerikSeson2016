namespace BankAccounts
{
    public class LoanAccount : Account
    {
        private const int NoInterestIndiviualMonths = 3;
        private const int NoInterestCompanyMonths = 2;

        public LoanAccount(Customer customer, decimal balance, decimal interestPerMonth)
            : base(customer, balance, interestPerMonth)
        {
            this.AccountType = AccountType.Deposit;
        }

        public override void Deposit(decimal sum)
        {
            this.Balance += sum;
        }

        public override decimal InterestCalculaion(int months)
        {
            if (this.Customer.CustomerType == CustomerType.Company)
            {
                if (months <= NoInterestCompanyMonths)
                {
                    return 0;
                }

                return this.InterestPerMonth * (months - NoInterestCompanyMonths);
            }
            else if (this.Customer.CustomerType == CustomerType.Individual)
            {
                if (months <= NoInterestIndiviualMonths)
                {
                    return 0;
                }

                return this.InterestPerMonth * (months - NoInterestIndiviualMonths);
            }

            return 0;
        }
    }
}
