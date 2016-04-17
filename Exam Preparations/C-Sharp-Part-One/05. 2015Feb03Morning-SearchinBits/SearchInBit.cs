using System;

class SearchInbit
{
    static void Main(string[] args)
    {
        int numberS = int.Parse(Console.ReadLine());
        int length = int.Parse(Console.ReadLine());
        int counter = 0;
        int mask = 15;
        int numberSandMask = numberS & mask;
        int currentNumberAndMask = 1;

        for (int i = 0; i < length; i++)
        {
            int currentNumber = int.Parse(Console.ReadLine());

            for (int j = 0; j < ((30-4)+1); j++)
            {
                currentNumberAndMask = currentNumber & (mask << j);
                
                if (currentNumberAndMask == numberSandMask<<j)
                {
                    counter++;
                }
            }
        }

        Console.WriteLine(counter);
    }
}
