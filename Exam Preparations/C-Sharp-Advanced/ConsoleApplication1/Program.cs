using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        ulong[] field = Console.ReadLine().Split(' ').Select(ulong.Parse).ToArray();

        var commands = new List<string>();
        long nextIndex = 0;
        ulong sum = 0;
        var delta = 1;

        double counter = 0;
        var input = Console.ReadLine();
        do
        {
            var currComand = input.Split(' ').ToArray();
            int times = int.Parse(currComand[0]);
            var dir = currComand[1];
            long steps = long.Parse(currComand[2]);

            if (dir == "right")
            {
                delta = 1;
            }
            else
            {
                delta = -1;
            }

            for (int j = 0; j < times; j++)
            {
                nextIndex = nextIndex + ((delta * steps) % field.Length);
                nextIndex = (nextIndex + field.Length) % field.Length;

                sum += field[nextIndex];

            }
                commands.Add(input);
            counter++;
            input = Console.ReadLine();
        }
        while (input != "stop");


        double avg = sum / counter;
        Console.WriteLine("{0:F1}", avg);
    }

}


