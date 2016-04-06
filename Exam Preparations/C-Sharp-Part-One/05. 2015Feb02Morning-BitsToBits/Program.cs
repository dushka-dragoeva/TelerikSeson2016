using System;

public class Printing
{
    public static void Main(string[] args)
    {
        int length = int.Parse(Console.ReadLine());

        int maxSequenceOfZeroes = 0;
        int currentSequenceOfZeroes = 0;
        int maxSequenceOfOnes = 0;
        int currentSequenceOfOnes = 0;
        char lastBit = 'a';

        for (int i = 0; i < length; i++)
        {
            int number = int.Parse(Console.ReadLine());

            var binaryNumber = string.Format("{0}", Convert.ToString(number, 2)).PadLeft(30, '0');

            foreach (var symbol in binaryNumber)
            {
                if (symbol == '0')
                {
                    if (lastBit == '0')
                    {
                        currentSequenceOfZeroes++;
                    }
                    else
                    {
                        currentSequenceOfZeroes = 1;
                    }

                    maxSequenceOfZeroes = Math.Max(maxSequenceOfZeroes, currentSequenceOfZeroes);
                }

                if (symbol == '1')
                {
                    if (lastBit == '1')
                    {
                        currentSequenceOfOnes++;
                    }
                    else
                    {
                        currentSequenceOfOnes = 1;
                    }

                    maxSequenceOfOnes = Math.Max(maxSequenceOfOnes, currentSequenceOfOnes);
                }

                lastBit = symbol;
            }
        }

        Console.WriteLine(maxSequenceOfZeroes);
        Console.WriteLine(maxSequenceOfOnes);
    }
}