using System;

public class Decoding
{
    public static void Main(string[] args)
    {
        int saltNum = int.Parse(Console.ReadLine());
        string text = Console.ReadLine();
        double res = 0;

        for (int i = 0; i < text.Length - 1; i++)
        {
            if (char.IsDigit(text[i]))
            {
                res = text[i] + saltNum + 500;
            }
            else if (char.IsLetter(text[i]))
            {
                res = ((int)text[i] * saltNum) + 1000;
            }
            else
            {
                res = text[i] - saltNum;
            }

            if (i % 2 == 0)
            {
                res = Math.Round(res / 100, 2);
                Console.WriteLine("{0:F2}", res);
            }
            else
            {
                res *= 100;
                Console.WriteLine(res);
            }
        }
    }
}