using System;
using System.Collections.Generic;

namespace _10.ShortestSequence
{
    /*We are given numbers N and M and the following operations:

N = N+1
N = N+2
N = N*2

Write a program that finds the shortest sequence of operations from the list above that starts from N and 
finishes in M.

Example: N = 5, M = 16
Sequence: 5 → 7 → 8 → 16*/

    public class Program
    {
        static void Main()
        {
            var shortestSequence = FindShortestSequenceOfOperations(5, 11);

            Console.WriteLine(string.Join("-> ", shortestSequence));
        }

        private static Stack<int> FindShortestSequenceOfOperations(int startNumber, int endNumber)
        {
            var operationsOrder = new Stack<int>();
        
            var currentMember = endNumber;
        
            operationsOrder.Push(currentMember);

            while (startNumber * 2 <= currentMember)
            {
                if (currentMember % 2 == 1)
                {
                    currentMember = currentMember - 1;
                    operationsOrder.Push(currentMember);
                }

                currentMember = currentMember / 2;
                operationsOrder.Push(currentMember);
            }

            if ((currentMember - startNumber) % 2 == 1)
            {
                currentMember = currentMember - 1;
                operationsOrder.Push(currentMember);
            }

            while (startNumber < currentMember)
            {
                currentMember = currentMember - 2;
                operationsOrder.Push(currentMember);
            }

            return operationsOrder;
        }
    }
}
