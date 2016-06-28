namespace BankAccounts
{
   using System;
    using BankAccounts.Interface;

    public class DepositAccount : Account, IWithdraw
    {
        private const string WithdrawBalanceExceptionMsg = "The account doesn't have enough money.";

        public DepositAccount(Customer customer, decimal balance, decimal interestPerMonth)
            : base(customer, balance, interestPerMonth)
        {
            this.AccountType = AccountType.Deposit;
        }

        public void Withdraw(decimal sum)
        {
            if (sum > this.Balance)
            {
                throw new ArgumentException(WithdrawBalanceExceptionMsg + " Balance: " + this.Balance);
            }

            this.Balance -= sum;
        }

        public override void Deposit(decimal sum)
        {
            this.Balance += sum;
        }

        public override decimal InterestCalculaion(int months)
        {
            if (this.Balance > 0 && this.Balance < 1000)
            {
                return 0;
            }

            return this.InterestPerMonth * months;
        }
    }
}
