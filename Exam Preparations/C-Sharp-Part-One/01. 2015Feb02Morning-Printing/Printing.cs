using System;

public class Program
{
    public const int SheetOfPapersInRealm = 500;

    public static void Main(string[] args)
    {
        int numberOfStudents = int.Parse(Console.ReadLine());
        int numberOfsheets = int.Parse(Console.ReadLine());
        decimal priceOfRealmPaper = decimal.Parse(Console.ReadLine());

        decimal moneySaved = numberOfStudents * numberOfsheets * (priceOfRealmPaper / SheetOfPapersInRealm);
        Console.WriteLine("{0:F2}", moneySaved);
    }
}
