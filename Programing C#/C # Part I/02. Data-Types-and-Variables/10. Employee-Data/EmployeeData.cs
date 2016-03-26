/* Problem 10.Employee Data A marketing company wants to keep record of its employees.
   Each record would have the following characteristics:
   First name
   Last name
   Age(0...100)
   Gender(m or f)
   Personal ID number(e.g. 8306112507)
   Unique employee number(27560000…27569999)
   Declare the variables needed to keep the information for a single employee using 
   appropriate primitive data types. Use descriptive names. Print the data at the console.*/
using System;

public class EmployeeData
{
    public static void Main()
    {
        string firstName = "Ruska";
        string lastName = "Ivanova";
        byte age = 44;
        char gender = 'f';
        ulong personalID = 7007076666;
        uint employeeNumber = 27561598;
        string outputFormat = "First name:\t\t{0} \nLast name:\t\t{1} \nAge:\t\t\t{2} \nGender:\t\t\t{3} \nPersonal ID number:\t{4} \nUnique employee number:\t{5}";
        Console.WriteLine(
            outputFormat,
            firstName,
            lastName,
            age,
            gender,
            personalID,
            employeeNumber);
    }
}
