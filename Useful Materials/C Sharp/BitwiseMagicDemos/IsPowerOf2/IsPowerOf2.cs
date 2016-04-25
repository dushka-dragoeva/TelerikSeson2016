using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsPowerOf2
{
    class IsPowerOf2
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            bool isPowerOf2 = (number & (number - 1)) == 0;
            Console.WriteLine(isPowerOf2);
        }
    }
}
