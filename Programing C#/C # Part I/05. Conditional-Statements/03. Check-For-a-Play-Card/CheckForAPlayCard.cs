/*Classical play cards use the following signs to designate the card face: 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K and A. 
 * Write a program that enters a string and prints "yes CONTENT_OF_STRING" if it is a valid card sign or 
 * "no CONTENT_OF_STRING" otherwise.*/

using System;

public class CheckForAPlayCard
{
    public static void Main(string[] args)
    {
        string input = Console.ReadLine();
        bool isCardFace = false;

        if (input.CompareTo("10") == 0)
        {
            isCardFace = true;
        }
        else if (input.Length == 1)
        {
            int cardFaceNumber;
            bool result = int.TryParse(input, out cardFaceNumber);

            if (2 <= cardFaceNumber && cardFaceNumber <= 9)
            {
                isCardFace = true;
            }
            else
            {
                char cardFace = input.ToCharArray()[0];
                if (cardFace == 'J' || cardFace == 'Q' || cardFace == 'K' || cardFace == 'A')
                {
                    isCardFace = true;
                }
            }
        }

        var output = isCardFace ? string.Format("yes {0}", input) : string.Format("no {0}", input);
        Console.WriteLine(output);
    }
}
