using System;

class Program
{
    public const int SheetOfPapersInRealm = 500;

    static void Main(string[] args)
    {
        int NumberOfStudents = int.Parse(Console.ReadLine());
        int NumberOfsheets = int.Parse(Console.ReadLine());
        decimal PriceOfRealmPaper = decimal.Parse(Console.ReadLine());

        decimal moneySaved = NumberOfStudents * NumberOfsheets * (PriceOfRealmPaper / SheetOfPapersInRealm);
        Console.WriteLine("{0:F2}", moneySaved);
    }
}
