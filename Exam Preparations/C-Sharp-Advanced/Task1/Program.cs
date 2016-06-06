using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger firstNumber = ConvertToNumber(Console.ReadLine());
            var sign = Console.ReadLine();
            BigInteger secondNumber = ConvertToNumber(Console.ReadLine());

            BigInteger result = 0;
            if (sign == "-")
            {
                result = firstNumber - secondNumber;
            }
            else
            {
                result = firstNumber + secondNumber;
            }

            Console.WriteLine(EncodeNumber(result));
        }

        private static BigInteger ConvertToNumber(string strNum)
        {
            strNum = strNum
               .Replace("cad", "0")
               .Replace("xoz", "1")
               .Replace("nop", "2")
               .Replace("cyk", "3")
               .Replace("min", "4")
               .Replace("mar", "5")
               .Replace("kon", "6")
               .Replace("iva", "7")
               .Replace("ogi", "8")
               .Replace("yan", "9");

            return BigInteger.Parse(strNum);
        }

        private static string EncodeNumber(BigInteger num)
        {
            var encoded = num.ToString()
                .Replace("0", "cad")
               .Replace("1", "xoz")
               .Replace("2", "nop")
               .Replace("3", "cyk")
               .Replace("4", "min")
               .Replace("5", "mar")
               .Replace("6", "kon")
               .Replace("7", "iva")
               .Replace("8","ogi")
               .Replace("9" ,"yan");

            return encoded;
        }
    }
}
