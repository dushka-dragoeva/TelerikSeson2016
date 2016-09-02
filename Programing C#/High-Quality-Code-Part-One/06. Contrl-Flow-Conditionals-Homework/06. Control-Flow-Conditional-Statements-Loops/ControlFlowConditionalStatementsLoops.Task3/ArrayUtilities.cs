using System;

namespace ControlFlowConditionalStatementsLoops.Task3
{
    public class ArrayUtilities
    {
        public void FindGivenValueInArray(int[] array, int expectedValue)
        {
            for (int i = 0; i < 100; i++)
            {
                bool isDivisibleByTen = i % 10 == 0;

                if (isDivisibleByTen && array[i] == expectedValue)
                {
                    Console.WriteLine("Value Found");
                    break;
                }
                else
                {
                    Console.WriteLine(array[i]);
                }
            }
        }
    }
}