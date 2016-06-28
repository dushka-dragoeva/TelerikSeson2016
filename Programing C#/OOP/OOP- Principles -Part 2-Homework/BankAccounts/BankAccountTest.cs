/*A bank holds different types of accounts for its customers: deposit accounts, loan accounts and mortgage accounts. 
 Customers could be individuals or companies.
All accounts have customer, balance and interest rate (monthly based).
Deposit accounts are allowed to deposit and with draw money.
Loan and mortgage accounts can only deposit money.
All accounts can calculate their interest amount for a given period (in months). 
 In the common case its is calculated as follows: number_of_months * interest_rate.
Loan accounts have no interest for the first 3 months if are held by individuals and for the first 2 months if are held by a company.
Deposit accounts have no interest if their balance is positive and less than 1000.
Mortgage accounts have ½ interest for the first 12 months for companies and no interest for the first 6 months for individuals.
Your task is to write a program to model the bank system by classes and interfaces.
You should identify the classes, interfaces, base classes and abstract actions and implement the calculation of the interest 
functionality through overridden methods.*/

namespace BankAccounts
{
    using System;

    public static class BankAccountTest
    {
        public static void Run()
        {
            Bank bank = LoadAccounts();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("02. Test Bank");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(bank);
        }

        private static Bank LoadAccounts()
        {
            Bank bank = new Bank("Bank DSK");

            bank.AddAccount(new MortgageAccount(new IndividualCustomer("Pesho Peshev"), 50000.0m, 25));
            bank.AddAccount(new DepositAccount(new CompanyCustomer("Sparco"), 7500.0m, 12));
            bank.AddAccount(new LoanAccount(new CompanyCustomer("'Northen Star"), 175000.0m, 22));
            bank.AddAccount(new MortgageAccount(new IndividualCustomer("Ivan Ivanov"), 30500.0m, 50));
            bank.AddAccount(new DepositAccount(new CompanyCustomer("McCompany"), 12450.0m, 13));
            bank.AddAccount(new LoanAccount(new IndividualCustomer("Desi Veleva"), 129.0m, 2));

            return bank;
        }
    }
}
