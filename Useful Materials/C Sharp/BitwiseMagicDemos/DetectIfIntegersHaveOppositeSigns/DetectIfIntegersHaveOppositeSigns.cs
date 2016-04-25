using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetectIfIntegersHaveOppositeSigns
{
    class DetectIfIntegersHaveOppositeSigns
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            Console.WriteLine((a ^ b) < 0);
        }
    }
}
