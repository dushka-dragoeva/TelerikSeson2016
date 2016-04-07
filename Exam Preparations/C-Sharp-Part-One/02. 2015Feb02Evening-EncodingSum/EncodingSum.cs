using System;

public class EncodingSum
{
    public static void Main()
    {
        int numberM = int.Parse(Console.ReadLine());
        string text = Console.ReadLine().ToUpper();

        long result = 0;

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == '@')
            {
                break;
            }
            else if (char.IsDigit(text[i]))
            {
                result *= (int)text[i] - (int)'0';
            }
            else if (char.IsLetter(text[i]))
            {
                result += (int)text[i] - (int)'A';
            }
            else
            {
                result = result % numberM;
            }
        }

        Console.WriteLine(result);
    }
}