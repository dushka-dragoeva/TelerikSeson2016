using System;

public class SquareRoot
{
    public static void Main()
    {
        var input = Console.ReadLine();
        try
        {
            double number = double.Parse(input);
            if (number >= 0)
            {
                double result = Math.Sqrt(number);
                Console.WriteLine("{0:F3}", result);
            }
            else
            {
                throw new ArgumentOutOfRangeException("number", "Number must be positive!");
            }
        }
        catch
        {
            Console.WriteLine("Invalid number");
        }
        finally
        {
            Console.WriteLine("Good bye");
        }
    }
}
