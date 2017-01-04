using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Topologic Sorting
//like graf
// matrica na sysedstvo - kogato ima tejesti - byrza proverka za svarzanost
//spisak na sysedstvo - dadeno ni e , po princip e po udobno

    // BFS => quewe, DFS => stack
    // pti topologichno polzavame stack; priority queue(vrashta ili nai malkiq ili naj golemiq)

namespace OfficeSpace
{
    class Program
    {
        static int[] answers = new int[50];

        static void Main(string[] args)
        {

            // Console.WriteLine(-1);
            var n = int.Parse(Console.ReadLine());
            var minutes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var dependences = new List<int>[n];

            for (int i = 0; i < n; i++)
            {
                dependences[i] = Console.ReadLine().Split(' ')
                    .Select(x => int.Parse(x) - 1).ToList();
            }


            var nodes = new Queue<int>();
            // var answers = new int[n];

            // obhijdame grah v shirina koito se obhojda
            for (int i = 0; i < n; i++)
            {
                answers[i] = CalculateMinTimeRecursivly(i, minutes, dependences);
            }

            var final = answers.Take(n).Select(eachElement => eachElement).ToArray();
           // var newArray = array.Skip(3).Take(5).Select(eachElement => eachElement.Clone()).ToArray();
            Console.WriteLine(answers.Max());
        }

        static int CalculateMinTimeRecursivly(int taskId, int[] minutes, List<int>[] dependences)
        {

            //if (answers[taskId] == -1)
            //{
            //    return -1;
            //}

            if (answers[taskId] != 0)
            {
                return answers[taskId];
            }

            if (dependences[taskId].Count == 1 && dependences[taskId][0] == -1)
            {
                return minutes[taskId];
            }

            var maxDependancyTime = 0;
           // answers[taskId] = -1;
            foreach (var dependencyId in dependences[taskId])
            {
               
                var dependencyTime = CalculateMinTimeRecursivly(dependencyId, minutes, dependences);
                maxDependancyTime = Math.Max(dependencyTime, maxDependancyTime);
            }

            return minutes[taskId] + maxDependancyTime;
        }

        static int CalculateMinTimeTopologically( int taskId, int[] minutes, LinkedList<int> [] dependences)
        {
            return 0;
        }
    }
}
