/*A bank account has a holder name (first name, middle name and last name), available
amount of money (balance), bank name, IBAN, 3 credit card numbers associated with the 
account. Declare the variables needed to keep the information for a single bank account 
using the appropriate data types and descriptive names.*/
using System;

public class BankAccountData
{
    public static void Main()
    {
        string firstName = "Ruska";
        string middleName = "Georgieva";
        string lastName = "Ivanova";
        decimal balance = 777777.75M;
        string bankName = "First Investment Bank";
        string iban = "BG25FIBS56981231874560";
        ulong creditCardOne = 7896456215987412;
        ulong creditCartdTow = 7896456215988520;
        ulong creditCadThree = 7896456215983570;
        string outputFormat = "First name:\t\t{0} \nMiddle name:\t\t{1} \nLast name:\t\t{2} \nBalance:\t\t{3}             \nBank Name:\t\t{4}\nIBAN:\t\t\t{5} \nCredit Card Number #1:\t{6}\nCredit Card Number #2:\t{7}\nCredit Card Number #3:\t{8}";
        Console.WriteLine(
                    outputFormat,
                    firstName,
                    middleName,
                    lastName,
                    balance,
                    bankName,
                    iban,
                    creditCardOne,
                    creditCartdTow,
                    creditCadThree);
    }
}
