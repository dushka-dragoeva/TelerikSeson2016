using System;
using System.Globalization;
using System.Threading;

public class Money
{
    public const int SheetOfPapersInRealm = 400;

    public static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        int numberOfStudents = int.Parse(Console.ReadLine());
        int numberOfsheetPerStudent = int.Parse(Console.ReadLine());
        decimal priceOfRealmPaper = decimal.Parse(Console.ReadLine());

        decimal moneySaved = numberOfStudents * numberOfsheetPerStudent * (priceOfRealmPaper / SheetOfPapersInRealm);

        Console.WriteLine("{0:F3}", moneySaved);
    }
}