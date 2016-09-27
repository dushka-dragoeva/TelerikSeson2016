using System;
using WalkInMatrix.Core.Models;

namespace WalkInMatrix.ConsoleApplication
{
    public class Startup
    {
        private const string EnterAPositiveNumber = "Enter a positive number between 1 and 100 inclusive";
        private const string InvalidNumberErrorMessage = "You haven't entered a correct positive number";

        private const int MinValue = 1;
        private const int MaxValue = 100;

        public static void Main(string[] args)
        {

            int size = ReadInput();
            SquareMatrix matrix = null;

            do
            {
                try
                {
                    matrix = new SquareMatrix(size);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    size = ReadInput();
                }
            }
            while (matrix == null);

            matrix.FillRotatingWalk();
            Console.WriteLine(matrix);
        }

        private static int ReadInput()
        {
            Console.WriteLine(EnterAPositiveNumber);
            string input = Console.ReadLine();
            int number = 0;

            while (!int.TryParse(input, out number) || MinValue > number || number > MaxValue)
            {
                Console.WriteLine(InvalidNumberErrorMessage);
                input = Console.ReadLine();
            }

            return number;
        }
    }
}

