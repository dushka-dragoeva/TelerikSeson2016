using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PrintADeck
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        int cardSign = 0;
        int length = 0;

        bool isNumber = int.TryParse(input, out cardSign);

        if (isNumber)
        {
            length = cardSign;
        }
        else
        {
            char cardFace = input.ToCharArray()[0];
            switch (cardFace)
            {
                case 'J':
                    length = 11;
                    break;
                case 'D':
                    length = 12;
                    break;
                case 'K':
                    length = 13;
                    break;
                case 'A':
                    length = 14;
                    break;
            }
        }
        string output = "{0} of spades, {0} of clubs, {0} of hearts, {0} of diamonds";

        if (length <= 10)
        {
            for (int i = 2; i <= length; i++)
            {
                Console.WriteLine(output, i);
            }
        }

        else
        {
            for (int i = 2; i <= 10; i++)
            {
                Console.WriteLine(output, i);
            }

          
        }
    }
}

