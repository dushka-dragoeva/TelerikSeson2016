using System;

namespace OddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var length = int.Parse(Console.ReadLine());

           // var numbers = new long[length];
            var dublicate = 0L;
            for (int i = 0; i < length; i++)
            {
               var number= long.Parse(Console.ReadLine());
                dublicate = dublicate ^ number;
            }

            Console.WriteLine(dublicate);
        }
    }
}
