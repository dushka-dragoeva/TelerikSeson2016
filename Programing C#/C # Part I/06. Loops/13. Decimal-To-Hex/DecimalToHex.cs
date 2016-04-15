using System;
using System.Text;

public class DecimalToHex
{
    public static void Main(string[] args)
    {
        long decimalNumber = long.Parse(Console.ReadLine());
        StringBuilder hexNumber = new StringBuilder();

        while (decimalNumber > 0)
        {
            long reminder = decimalNumber % 16;
            string hexValue = string.Empty;
            if (reminder >= 10)
            {
                // use ascii code for char choice - for example ascii code for 'A' is 65 => (int)'A'=65; 
                // ascii code for 'B' is 66 => (int)'B'= (int)A +1  --> 65 +11 % 10 = 65+ 1 =66 etc...
                int charAsciiCode = (int)'A' + ((int)reminder % 10);
                hexValue = ((char)charAsciiCode).ToString();
            }
            else
            {
                hexValue = reminder.ToString();
            }

            hexNumber = hexNumber.Insert(0, hexValue);
            decimalNumber = decimalNumber / 16;
        }

        Console.WriteLine(hexNumber.ToString());
    }
}