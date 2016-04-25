using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneUniqueAmongDuplicates
{
    class OneUniqueAmongDuplicates
    {
        static void Main(string[] args)
        {
            int allXored = 0;
            string inputLine = Console.ReadLine();
            while(inputLine != "end")
            {
                allXored ^= int.Parse(inputLine);

                inputLine = Console.ReadLine();
            }

            Console.WriteLine(allXored);
        }
    }
}
