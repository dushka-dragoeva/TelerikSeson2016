/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            long nBus = long.Parse(Console.ReadLine());
            long counter = 1;
            long minSpeed = long.Parse(Console.ReadLine());

            for (long i = 0; i < nBus - 1; i++)
            {
                long speed = long.Parse(Console.ReadLine());
                if (speed <= minSpeed)
                {
                    counter++;
                    minSpeed = speed;
                }
            }

            Console.WriteLine(counter);
        }
    }
}*/

using System;

namespace Task2
{
    public class Busses
    {
        public static void Main()
        {
            long totalLinesToRead = long.Parse(Console.ReadLine());
            long previosBusSpeed = long.Parse(Console.ReadLine());
            long groupCounter = 1;

            for (long i = 0; i < totalLinesToRead - 1; i++)
            {
                long speed = long.Parse(Console.ReadLine());
                if (speed <= previosBusSpeed)
                {
                    groupCounter++;
                    previosBusSpeed = speed;
                }
            }

            Console.WriteLine(groupCounter);
        }
    }
}
