using System;

public class SequenceOfBits

{
    public static void Main()
    {
        int lengthOgNumbers = int.Parse(Console.ReadLine());

        int maxSequenceOfZeros = 0;
        int currentSequenceOfZeros = 0;
        int maxSequenceOfOnes = 0;
        int currentSequenceOfOnes = 0;
        char lastBit = '?';

        for (int i = 0; i < lengthOgNumbers; i++)
        {
            int currentNumber = int.Parse(Console.ReadLine());
            string binaryNumber = Convert.ToString(currentNumber, 2).PadLeft(30, '0');

            foreach (var bit in binaryNumber)
            {
                if (bit == '0')
                {
                    if (lastBit == '0')
                    {
                        currentSequenceOfZeros++;
                    }
                    else
                    {
                        currentSequenceOfZeros = 1;
                    }

                    lastBit = bit;
                    maxSequenceOfZeros = Math.Max(maxSequenceOfZeros, currentSequenceOfZeros);
                }
                else
                {
                    if (lastBit == '1')
                    {
                        currentSequenceOfOnes++;
                    }
                    else
                    {
                        currentSequenceOfOnes = 1;
                    }

                    lastBit = bit;
                    maxSequenceOfOnes = Math.Max(maxSequenceOfOnes, currentSequenceOfOnes);
                }
            }
        }

        Console.WriteLine(maxSequenceOfOnes);
        Console.WriteLine(maxSequenceOfZeros);
    }
}
