using System;
using System.Collections.Generic;
using System.Linq;

namespace PrintFirstFiftyMembers
{
    /*09. We are given the following sequence:

S1 = N;
S2 = S1 + 1;
S3 = 2*S1 + 1;
S4 = S1 + 2;
S5 = S2 + 1;
S6 = 2*S2 + 1;
S7 = S2 + 2;
...
Using the Queue<T> class write a program to print its first 50 members for given N.
Example: N=2 → 2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...*/
    public class Program
    {
        public static void Main()
        {
            var firstMembers = FindFirstFiftyMembers(2, 50);

            Console.WriteLine(firstMembers.Count);
            Console.WriteLine(string.Join(", ", firstMembers));
        }

        private static List<int> FindFirstFiftyMembers(int number, int length)
        {
            var members = new Queue<int>();
            var result = new List<int>();
            result.Add(number);
            var currentMember = 0;

            while (true)
            {
                currentMember = number + 1;
                members.Enqueue(currentMember);
                currentMember = 2 * number + 1;
                members.Enqueue(currentMember);
                currentMember = number + 2;
                members.Enqueue(currentMember);
                number = members.Dequeue();
                result.Add(number);

                if ((members.Count + result.Count) >= length)
                {
                    result.AddRange(members);
                    result = result.Take(50).ToList();

                    //var membersToAdd = length - result.Count;

                    //for (int i = 0; i < membersToAdd; i++)
                    //{
                    //    number = members.Dequeue();

                    //    result.Add(number);
                    //}
                   
                    break;
                }
            }

            return result;
        }
    }
}
