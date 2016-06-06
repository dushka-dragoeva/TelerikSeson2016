using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        ulong[] field = Console.ReadLine().Split(' ').Select(ulong.Parse).ToArray();

        var commands = new List<string>();
      //  var counter = 0;
        var input = Console.ReadLine();
        do
        {
            commands.Add(input);
            input = Console.ReadLine();
        }
        while (input != "stop");

        long nextIndex = 0;
        ulong sum = 0;
        var delta = 1;

        for (int i = 0; i < commands.Count; i++)
        {
            var currComand = commands[i].Split(' ').ToArray();
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
                nextIndex = nextIndex +( (delta * steps)%field.Length);
                nextIndex = (nextIndex + field.Length) % field.Length;

             //   Console.WriteLine();
                sum += field[nextIndex];
            }
        }

        double avg = sum / (double)commands.Count;
        Console.WriteLine("{0:F1}", avg);
    }

}

