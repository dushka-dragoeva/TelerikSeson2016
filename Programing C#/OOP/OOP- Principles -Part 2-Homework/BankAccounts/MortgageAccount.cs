namespace BankAccounts
{
    public class MortgageAccount : Account
    {
        private const int DifferentInterestIndividualMonths = 6;
        private const int DifferentInterestCompanyMonths = 12;

        public MortgageAccount(Customer customer, decimal balance, decimal interestPerMonth)
            : base(customer, balance, interestPerMonth)
        {
            this.AccountType = AccountType.Mortgage;
        }

        public override void Deposit(decimal sum)
        {
            this.Balance += sum;
        }

        public override decimal InterestCalculaion(int months)
        {
            if (this.Customer.CustomerType == CustomerType.Company)
            {
                if (months <= DifferentInterestCompanyMonths)
                {
                    return (this.InterestPerMonth * months) / 2;
                }

                return (this.InterestPerMonth * (months - DifferentInterestCompanyMonths))
                    + (DifferentInterestCompanyMonths * this.InterestPerMonth / 2);
            }
            else if (this.Customer.CustomerType == CustomerType.Individual)
            {
                if (months <= DifferentInterestIndividualMonths)
                {
                    return 0;
                }

                return this.InterestPerMonth * (months - DifferentInterestIndividualMonths);
            }

            return 0;
        }
    }
}
