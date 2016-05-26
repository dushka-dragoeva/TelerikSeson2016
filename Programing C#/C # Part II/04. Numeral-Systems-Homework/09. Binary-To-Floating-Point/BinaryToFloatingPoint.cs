using System;
using System.Globalization;
using System.Threading;

public class PrintBinaryFloatingPoint
{
    public static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        float number = float.Parse(Console.ReadLine());

        string binary = ConvertFloatingPointToBynary(number);

        Console.WriteLine("Binary: {0}", binary);
        Console.WriteLine("Sign: {0}", binary[0]);
        Console.WriteLine("Exponent: {0}", binary.Substring(1, 8));
        Console.WriteLine("Mantissa: {0}", binary.Substring(9, binary.Length - 9));
    }

    private static string ConvertFloatingPointToBynary(float number)
    {
        char sign = number < 0 ? '1' : '0';

        if (number == 0)
        {
            return Convert.ToString(0, 2).PadLeft(32, '0');
        }
        else if (number < 0)
        {
            number = number * (-1);
        }

        int temp = BitConverter.ToInt32(BitConverter.GetBytes(number), 0);
        return sign + Convert.ToString(temp, 2);
    }
}
