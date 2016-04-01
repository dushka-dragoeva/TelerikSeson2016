/*Write a program that reads a card sign(as a char) from the console and generates and prints all possible
cards from a standard deck of 52 cards up to the card with the given sign(without the jokers). The cards 
should be printed using the classical notation (like 5 of spades, A of hearts, 9 of clubs; and K of diamonds).
The card faces should start from 2 to A.
Print each card face in its four possible suits: clubs, diamonds, hearts and spades.*/
using System;

public class PrintADeck
{
    public static void Main()
    {
        string cardFace = Console.ReadLine();
        int length = 0;

        switch (cardFace)
        {
            case "J":
                length = 11;
                break;
            case "D":
                length = 12;
                break;
            case "K":
                length = 13;
                break;
            case "A":
                length = 14;
                break;
            default:
                length = int.Parse(cardFace);
                break;
        }

        for (int i = 2; i <= length; i++)
        {
            cardFace = string.Empty;
            switch (i)
            {
                case 11:
                    cardFace = "J";
                    break;
                case 12:
                    cardFace = "Q";
                    break;
                case 13:
                    cardFace = "K";
                    break;
                case 14:
                    cardFace = "A";
                    break;
                default:
                    cardFace = string.Empty + i;
                    break;
            }

            string output = "{0} of spades, {0} of clubs, {0} of hearts, {0} of diamonds";
            Console.WriteLine(output, cardFace);
        }
    }
}