/*Write a program that applies bonus score to given score in the range [1…9] by the following rules:
If the score is between 1 and 3, the program multiplies it by 10.
If the score is between 4 and 6, the program multiplies it by 100.
If the score is between 7 and 9, the program multiplies it by 1000.
If the score is less than 0 or more than 9, the program prints "invalid score".*/

using System;

public class BonusScore
{
    public static void Main()
    {
        int score = int.Parse(Console.ReadLine());
        if (1 <= score && score <= 9)
        {
            if (1 <= score && score <= 3)
            {
                score *= 10;
            }
            else if (4 <= score && score <= 6)
            {
                score *= 100;
            }
            else
            {
                score *= 1000;
            }

            Console.WriteLine(score);
        }
        else
        {
            Console.WriteLine("invalid score");
        }
    }
}
