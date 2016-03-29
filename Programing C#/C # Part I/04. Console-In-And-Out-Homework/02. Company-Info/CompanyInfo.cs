/*Description
A company has name, address, phone number, fax number, web site and manager. The manager has first name, last name, age and a phone number.
Write a program that reads the information about a company and its manager and prints it back on the consol
Print the information the same way as shown in the sample test. Make sure that you print "(no fax)" if an empty line is 
passed as fax number.*/
using System;

public class CompanyInfo
{
    public static void Main()
    {
        string companyName = Console.ReadLine();
        string companyAddress = Console.ReadLine();
        string phonenNumber = Console.ReadLine();
        string faxNAumber = Console.ReadLine();
        string website = Console.ReadLine();
        string managerFirstName = Console.ReadLine();
        string managerLastName = Console.ReadLine();
        string managerAge = Console.ReadLine();
        string managerPhone = Console.ReadLine();

        if (faxNAumber.CompareTo(string.Empty) == 0)
        {
            faxNAumber = "(no fax)";
        }

        string outptFormat = "{0}\nAddress: {1}\nTel. {2} \nFax: {3} \nWeb site: {4}\nManager: {5} {6} (age: {7}, tel. {8})";

        Console.WriteLine(
            outptFormat, 
            companyName, 
            companyAddress, 
            phonenNumber, 
            faxNAumber, 
            website,
            managerFirstName,
            managerLastName,
            managerAge,
            managerPhone);
    }
}
