using System;

class Decoding
{
    static void Main(string[] args)
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
                res = (int)text[i] * saltNum + 1000;
            }
            else
            {
                res = text[i] - saltNum;
            }

            if (i % 2 == 0)
            {
                ///o	If the character is on even position in the original
                ///text - divide the encoded value by 100 and round the 
                ///precision to 2 decimal digits right of the decimal point
                res = Math.Round(res / 100,2);
                Console.WriteLine("{0:F2}", res);
            }
            else
            {
                /// Else if the character is on odd position in the original text - multiply by 100
                res *= 100;
                Console.WriteLine(res);
            }

            
        }
    }
}
