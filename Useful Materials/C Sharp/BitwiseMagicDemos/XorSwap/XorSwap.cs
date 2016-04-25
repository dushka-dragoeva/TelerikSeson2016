using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XorSwap
{
    class XorSwap
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            Console.WriteLine(a + " " + b);

            a ^= b;
            b ^= a;
            a ^= b;

            Console.WriteLine(a + " " + b);
        }
    }
}
