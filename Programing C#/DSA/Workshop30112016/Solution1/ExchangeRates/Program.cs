using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace ExchangeRates
{
    class Program
    {
        static void Main(string[] args)
        {

            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var money = decimal.Parse(Console.ReadLine());
            var days = int.Parse(Console.ReadLine());
            var exchangeRateFirstToSecond = new decimal[days];
            var exchangeRateSecondToFirst = new decimal[days];

            for (int i = 0; i < days; i++)
            {
                var exchangeRates = Console.ReadLine()
                .Split(' ')
                .Select(x => decimal.Parse(x))
                .ToArray();
                exchangeRateFirstToSecond[i] = exchangeRates[0];
                exchangeRateSecondToFirst[i] = exchangeRates[1];
            }

            decimal amountFirstCurrency = money;
            decimal amountSecondCurrency = money * exchangeRateFirstToSecond[0];
            for (int i = 1; i < days; i++)
            {
                var currentAmountFirst = amountSecondCurrency * exchangeRateSecondToFirst[i];
                var currentAmountSecond = amountFirstCurrency * exchangeRateFirstToSecond[i];

                if(amountFirstCurrency<currentAmountFirst) 
                {
                    amountFirstCurrency = currentAmountFirst;
                }

                if(amountSecondCurrency<currentAmountSecond)
                 {
                    amountSecondCurrency = currentAmountSecond;
                }
            }

            Console.WriteLine("{0:0.00}", amountFirstCurrency);
        }
    }
}
