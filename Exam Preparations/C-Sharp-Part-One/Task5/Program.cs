using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            long b =long.Parse(Console.ReadLine());
            long f = long.Parse(Console.ReadLine());
            long m = 123123123123;
            long d = 317;
            double result = 0;


            if (b % 2 == 0)
            {
                result = ((double)f / b)*m;
            }
            else
            {
                result= ((double)f / b) /d;
            }

            Console.WriteLine("{0:f4}", result);

        }
    }
}
