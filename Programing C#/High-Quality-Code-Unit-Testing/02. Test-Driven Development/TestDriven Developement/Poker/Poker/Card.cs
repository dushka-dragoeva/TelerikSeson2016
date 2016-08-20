using System;

namespace Poker
{
    public class Card : ICard
    {
        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public CardFace Face { get; private set; }

        public CardSuit Suit { get; private set; }

        public override string ToString()
        {
            char suit = new char();
            string face = string.Empty;
            switch (this.Suit)
            {
                case CardSuit.Spades:
                    suit = '♠';
                    break;
                case CardSuit.Hearts:
                    suit = '♥';
                    break;
                case CardSuit.Diamonds:
                    suit = '♦';
                    break;
                case CardSuit.Clubs:
                    suit = '♣';
                    break;
            }

            switch (this.Face)
            {
                case CardFace.Ace:
                    face = "A";
                    break;
                case CardFace.King:
                    face = "K";
                    break;
                case CardFace.Queen:
                    face = "Q";
                    break;
                case CardFace.Jack:
                    face = "J";
                    break;
                default:
                    face = ((int)this.Face).ToString();
                    break;
            }

            return string.Format("{0}{1}", face, suit);
        }
    }
}