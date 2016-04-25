using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextHighestPowerOf2
{
    class NextHighestPowerOf2
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            number--;
            number |= number >> 1;
            number |= number >> 2;
            number |= number >> 4;
            number |= number >> 8;
            number |= number >> 16;
            number++;

            Console.WriteLine(number);
        }
    }
}
