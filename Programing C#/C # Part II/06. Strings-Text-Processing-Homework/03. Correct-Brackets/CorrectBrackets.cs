using System;

public class CorrectBrackets
{
    public static void Main(string[] args)
    {
        var expression = Console.ReadLine();
        var counter = 0;

        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '(')
            {
                ++counter;
            }
            else if (expression[i] == ')')
            {
                --counter;
            }
        }

        var result = counter == 0 ? "Correct" : "Incorrect";
        Console.WriteLine(result);
    }
}