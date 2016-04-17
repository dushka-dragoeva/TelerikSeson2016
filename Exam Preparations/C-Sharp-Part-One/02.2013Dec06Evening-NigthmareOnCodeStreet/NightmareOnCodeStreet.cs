using System;

public class NightmareOnCodeStreet
{
    public static void Main()
    {
        string text = Console.ReadLine();
        int sum = 0;
        int counter = 0;
        int position = 0;

        foreach (char symbol in text)
        {
            if (position % 2 == 1 && char.IsDigit(symbol))
            {
                counter++;
                int digit = symbol - '0';
                sum += digit;
            }

            position++;
        }

        ////for (int i = 0; i < text.Length; i++)
        ////{
        ////    if (i % 2 == 1&& char.IsDigit(text[i]))
        ////    {
        ////        counter++;
        ////            int digit = (text[i] - '0');
        ////            sum += digit;
        ////    }
        ////}
        Console.WriteLine("{0} {1}", counter, sum);
    }
}
