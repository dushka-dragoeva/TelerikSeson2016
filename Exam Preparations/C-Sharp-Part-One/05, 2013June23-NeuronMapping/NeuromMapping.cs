using System;

public class NeuronMapping
{
    public static void Main()
    {
        while (true)
        {
            long currentLine = long.Parse(Console.ReadLine());
            if (currentLine == -1)
            {
                break;
            }

            if (currentLine == 0)
            {
                Console.WriteLine(0);
                continue;
            }

            int mostLeftIndex = -1;
            int mostRightIndex = -1;

            for (int p = 0; p < 32; p++)
            {
                // find the most right 1
                long mask = 1 << p;
                long numberAndMask = currentLine & mask;
                long bitNumber = numberAndMask >> p;

                if (bitNumber == 1)
                {
                    if (mostRightIndex == -1)
                    {
                        mostRightIndex = p;
                    }

                    // find the most left 1
                    mostLeftIndex = p;
                }
            }

            long result = 0;

            for (int p = mostRightIndex; p <= mostLeftIndex; p++)
            {
                // if original number p-->0=> result 1
                long mask = 1 << p;
                long numberAndMask = currentLine & mask;
                long bitNumber = numberAndMask >> p;

                if (bitNumber == 0)
                {
                    result = result | mask;
                }
            }

            Console.WriteLine(result);
        }
    }
}