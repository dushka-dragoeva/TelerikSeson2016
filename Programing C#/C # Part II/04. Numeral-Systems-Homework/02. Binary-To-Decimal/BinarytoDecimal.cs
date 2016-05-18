using System;

public class BinarytoDecimal
{
    public static void Main(string[] args)
    {
        var input = Console.ReadLine();
        Console.WriteLine(ConvertToDecimal(input));
    }

    private static long ConvertToDecimal(string binary)
    {
        long decimalNumber = 0;
        for (int i = 0; i < binary.Length; i++)
        {
            long temp = binary[i] - '0';
            int power = binary.Length - i - 1;
            long powerOfTwo = temp << power;
            decimalNumber += powerOfTwo * (binary[i] - '0');
        }

        return decimalNumber;
    }
}