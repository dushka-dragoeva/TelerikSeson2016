using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Decimal_To_Hexadecimal
{
    class DecimalToHexadecimal
    {
        static void Main(string[] args)
        {
            var num = long.Parse(Console.ReadLine());
            var result = ConvertDecimalToAtherNumericSystem(num,16);
            Console.WriteLine(result);
        }

        private static string ConvertDecimalToAtherNumericSystem(long number, int systemBase )
        {
            StringBuilder hexNumber = new StringBuilder();
            while (number > 0)
            {
                var digit = number % systemBase;
                if (digit < 10)
                {
                    hexNumber.Insert(0, digit);
                }
                else
                {
                    digit = 'A' + digit % 10;
                    char hexValue = (char)digit;
                    hexNumber.Insert(0, hexValue);
                }
                number = number / systemBase;
            }

            return hexNumber.ToString();
        }
    }
}
