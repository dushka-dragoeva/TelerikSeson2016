using System;

class NumberOfPages
{
    static void Main()
    {
        int pages = int.Parse(Console.ReadLine());
        int digitsInBook = 0;

        int pagesLeght = pages.ToString().Length;
        switch (pagesLeght)
        {
            case 1:
                digitsInBook = pages;
                break;
            case 2:
                digitsInBook = (pages - 9) * 2 + 9;
                break;
            case 3:
                digitsInBook = (pages - 99) * 3 + 90 * 2 + 9;
                break;
            case 4:
                digitsInBook = (pages - 999) * 4 + 900 * 3 + 90 * 2 + 9; ;
                break;
            case 5:
                digitsInBook = (pages - 9999) * 5 + 9000 * 4 + 900 * 3 + 90 * 2 + 9; ;
                break;
            case 6:
                digitsInBook = (pages - 99999) * 6 + 90000 * 5 + 9000 * 4 + 900 * 3 + 90 * 2 + 9;
                break;
        }

        Console.WriteLine(digitsInBook);
    }
}