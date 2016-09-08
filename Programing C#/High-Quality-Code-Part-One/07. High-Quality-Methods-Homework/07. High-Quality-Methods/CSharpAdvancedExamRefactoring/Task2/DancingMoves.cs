/*using System;
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
        var input = Console.ReadLine();
        do
        {
            commands.Add(input);
            input = Console.ReadLine();


        }
        while (input != "stop");

        long nextIndex = 0;
        ulong sum = 0;
        ulong currSum = 0;
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

              //  nextIndex = nextIndex + (delta * steps) % field.Length;
                nextIndex = (nextIndex + field.Length) % field.Length;

             //   Console.WriteLine();
                sum += field[nextIndex];
            }

            // Console.WriteLine(currSum);
            //  sum += currSum;
            // currSum = 0;

            // Times Direction Step
        }

        double avg = sum / (double)commands.Count;
        Console.WriteLine("{0:F1}", avg);
    }

}

*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpAdvancedExamRefactoring.Task2
{
    internal class DancingMoves
    {
        static void Main(string[] args)
        {
            ulong[] field = Console.ReadLine()
                .Split(' ')
                .Select(ulong.Parse)
                .ToArray();

            var commands = new List<string>();

            var input = Console.ReadLine();
            do
            {
                commands.Add(input);
                input = Console.ReadLine();
            }
            while (input != "stop");

          
            // var delta = 1;

            for (int i = 0; i < commands.Count; i++)
            {
             

               

                //if (dir == "right")
                //{
                //    delta = 1;
                //}
                //else
                //{
                //    delta = -1;
                //}

              
            }

            double avg = sum / (double)commands.Count;
            Console.WriteLine("{0:F1}", avg);
        }

        private static void ExecuteComand(string command)
        {
            var curruntComand = command.Split(' ').ToArray();
            int times = int.Parse(curruntComand[0]);
            var dir = curruntComand[1];
            long steps = long.Parse(curruntComand[2]);

            var delta = new Dictionary<string, int>(){
                    { "right", 1 },
                    {"left", -1 }
                };

            long nextIndex = 0;

            ulong sum = 0;

            for (int j = 0; j < times; j++)
            {
                nextIndex = nextIndex + ((delta[dir] * steps) % field.Length);
                nextIndex = (nextIndex + field.Length) % field.Length;

                sum += field[nextIndex];
            }
        }
    }
}
