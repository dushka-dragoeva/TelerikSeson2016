/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int pages = int.Parse(Console.ReadLine());
            int d = 0;

            int pagesLeght = pages.ToString().Length;
            switch (pagesLeght)
            {
                case 1: d = pages; break;
                case 2: d = (pages - 9) * 2 + 9; break;
                case 3: d = (pages - 99) * 3 + 90 * 2 + 9; break;
                case 4: d = (pages - 999) * 4 + 900 * 3 + 90 * 2 + 9; ; break;
                case 5: d = (pages - 9999) * 5 + 9000 * 4 + 900 * 3 + 90 * 2 + 9; ; break;
                case 6: d = (pages - 99999) * 6 + 90000 * 5 + 9000 * 4 + 900 * 3 + 90 * 2 + 9; break;

            }

            Console.WriteLine(d);
        }
    }
}*/

using System;

namespace RefactorCShartFundamentsExam.NumberOfDigits
{
    public class NumberOfDigits
    {
       public static void Main()
        {
            int bookPages = int.Parse(Console.ReadLine());
            int numberOfDigitsInBook = CalculateNumberOfAllDigitsInBook(bookPages);

            Console.WriteLine(numberOfDigitsInBook);
        }

        private static int CalculateNumberOfAllDigitsInBook(int bookPages)
        {
            var numberOfAllDigitsInBook = 0;
            var numberOfDigitsInLastPage = bookPages.ToString().Length;

            if (numberOfDigitsInLastPage == 1)
            {
                numberOfAllDigitsInBook = bookPages;
            }
            else
            {
                int currentNumberOfDigitsPerPage = numberOfDigitsInLastPage - 1;
                var subtrahend = int.Parse(new string('9', currentNumberOfDigitsPerPage));
                numberOfAllDigitsInBook = (bookPages - subtrahend) * numberOfDigitsInLastPage;

                while (currentNumberOfDigitsPerPage >= 0)
                {
                    double power = currentNumberOfDigitsPerPage - 1;
                    numberOfAllDigitsInBook += 9 * (int)Math.Pow(10.0, power) * currentNumberOfDigitsPerPage;
                    currentNumberOfDigitsPerPage--;
                }
            }

            return numberOfAllDigitsInBook;
        }
    }
}