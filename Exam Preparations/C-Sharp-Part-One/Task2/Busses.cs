using System;

class Busses
{
    static void Main(string[] args)
    {
        long numberOfBus = long.Parse(Console.ReadLine());
        long counter = 1;
        double minSpeed = double.Parse(Console.ReadLine());

        for (long i = 0; i < numberOfBus - 1; i++)
        {
            double speed = double.Parse(Console.ReadLine());

            if (speed <= minSpeed)
            {
                counter++;
                minSpeed = speed;
            }
        }

        Console.WriteLine(counter);
    }
}