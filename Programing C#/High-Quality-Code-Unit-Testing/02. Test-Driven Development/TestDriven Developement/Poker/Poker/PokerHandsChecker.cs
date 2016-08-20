using System;

namespace Poker
{
    using System.Collections.Generic;
    using System.Linq;

    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            if (hand?.Cards.Count != 5)
            {
                return false;
            }

            for (int i = 0; i < 5; i++)
            {
                if (hand.ToString().IndexOf(hand.Cards[i].ToString()) != hand.ToString().LastIndexOf(hand.Cards[i].ToString()))
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            if (this.MaxNumberOfSameCards(hand) != 1)
            {
                return false;
            }

            CardSuit firstCardSuit = hand.Cards[0].Suit;

            for (int i = 1; i < hand.Cards.Count; i++)
            {
                if (hand.Cards[i].Suit != firstCardSuit)
                {
                    return false;
                }
            }

            var cards = hand.Cards.ToList();
            cards.Sort((x, y) => (int)x.Face - (int)y.Face);

            if ((int)cards[0].Face == 2 && (int)cards[1].Face == 3 && (int)cards[2].Face == 4 && (int)cards[3].Face == 5 && (int)cards[4].Face == 14)
            {
                return true;
            }

            for (int i = 1; i < cards.Count; i++)
            {
                if ((int)cards[i].Face != (int)cards[i - 1].Face + 1)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            if (this.MaxNumberOfSameCards(hand) == 4)
            {
                return true;
            }

            return false;
        }

        public bool IsFullHouse(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            if (MaxNumberOfSameCards(hand) != 3)
            {
                return false;
            }

            return this.DeterminePairTwoPairOrFullHouseIfPairInTheHand(hand) == "full house";
        }

        public bool IsFlush(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            CardSuit firstCardSuit = hand.Cards[0].Suit;

            for (int i = 1; i < hand.Cards.Count; i++)
            {
                if (hand.Cards[i].Suit != firstCardSuit)
                {
                    return false;
                }
            }

            if (this.IsStraightFlush(hand))
            {
                return false;
            }

            return true;
        }

        public bool IsStraight(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            if (this.MaxNumberOfSameCards(hand) != 1)
            {
                return false;
            }

            if (this.IsFlush(hand))
            {
                return false;
            }

            if (this.IsStraightFlush(hand))
            {
                return false;
            }

            var cards = hand.Cards.ToList();
            cards.Sort((x, y) => (int)x.Face - (int)y.Face);

            if ((int)cards[0].Face == 2 && (int)cards[1].Face == 3 && (int)cards[2].Face == 4 && (int)cards[3].Face == 5 && (int)cards[4].Face == 14)
            {
                return true;
            }

            for (int i = 1; i < cards.Count; i++)
            {
                if ((int)cards[i].Face != (int)cards[i - 1].Face + 1)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            if (MaxNumberOfSameCards(hand) != 3)
            {
                return false;
            }

            List<ICard> remainingCards = new List<ICard>();
            for (int i = 0; i < hand.Cards.Count; i++)
            {
                ICard currentCard = hand.Cards[i];
                int numberOfSameCards = hand.Cards.Where(x => x.Face == currentCard.Face).Count();
                if (numberOfSameCards == 3)
                {
                    remainingCards = hand.Cards.Where(x => x.Face != currentCard.Face).ToList();
                    break;
                }
            }

            return remainingCards[0].Face != remainingCards[1].Face;
        }

        public bool IsTwoPair(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            if (MaxNumberOfSameCards(hand) != 2)
            {
                return false;
            }

            return this.DeterminePairTwoPairOrFullHouseIfPairInTheHand(hand) == "two pair";
        }

        public bool IsOnePair(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            if (MaxNumberOfSameCards(hand) != 2)
            {
                return false;
            }

            return this.DeterminePairTwoPairOrFullHouseIfPairInTheHand(hand) == "pair";
        }

        public bool IsHighCard(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            if (this.IsFlush(hand))
            {
                return false;
            }

            if (this.IsStraight(hand) || this.IsStraightFlush(hand))
            {
                return false;
            }

            if (this.MaxNumberOfSameCards(hand) == 1)
            {
                return true;
            }

            return false;
        }

        /// <exception cref="ArgumentException">Both hands should be valid in order to be compared</exception>
        /// <exception cref="ApplicationException">MaxNumberOfSameCards cannot be different than 1, 2, 3 or 4</exception>
        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            if (!this.IsValidHand(firstHand) || !this.IsValidHand(secondHand))
            {
                throw new ArgumentException("Both hands should be valid in order to be compared");
            }

            bool[] firstHandType =
                {
                    this.IsHighCard(firstHand), this.IsOnePair(firstHand), this.IsTwoPair(firstHand),
                    this.IsThreeOfAKind(firstHand), this.IsStraight(firstHand), this.IsFlush(firstHand),
                    this.IsFullHouse(firstHand), this.IsFourOfAKind(firstHand),
                    this.IsStraightFlush(firstHand)
                };

            bool[] secondHandType =
                {
                    this.IsHighCard(secondHand), this.IsOnePair(secondHand), this.IsTwoPair(secondHand),
                    this.IsThreeOfAKind(secondHand), this.IsStraight(secondHand), this.IsFlush(secondHand),
                    this.IsFullHouse(secondHand), this.IsFourOfAKind(secondHand),
                    this.IsStraightFlush(secondHand)
                };

            int firstHandStrengthIndex = Array.IndexOf(firstHandType, true);
            int secondHandStrengthIndex = Array.IndexOf(secondHandType, true);

            if (firstHandStrengthIndex != secondHandStrengthIndex)
            {
                return firstHandStrengthIndex > secondHandStrengthIndex ? 1 : -1;
            }

            // Straight or straight flush
            if (firstHandStrengthIndex == 4 || firstHandStrengthIndex == 8)
            {
                List<ICard> firstCards = firstHand.Cards.ToList();
                firstCards.Sort((x, y) => (int)x.Face - (int)y.Face);

                List<ICard> secondCards = secondHand.Cards.ToList();
                secondCards.Sort((x, y) => (int)x.Face - (int)y.Face);

                if ((int)firstCards[0].Face == 2 && (int)firstCards[firstCards.Count - 1].Face == 14)
                {
                    return ((int)secondCards[0].Face == 2 && (int)secondCards[secondCards.Count - 1].Face == 14)
                               ? 0
                               : -1;
                }

                if ((int)secondCards[0].Face == 2 && (int)secondCards[secondCards.Count - 1].Face == 14)
                {
                    return ((int)firstCards[0].Face == 2 && (int)firstCards[firstCards.Count - 1].Face == 14)
                               ? 0
                               : 1;
                }

                return this.CompareFaceStrength(firstCards[firstCards.Count - 1], secondCards[firstCards.Count - 1]);
            }

            if (firstHandStrengthIndex == 0 || firstHandStrengthIndex == 1 || firstHandStrengthIndex == 3
                || firstHandStrengthIndex == 5 || firstHandStrengthIndex == 7)
            {
                switch (this.MaxNumberOfSameCards(firstHand))
                {
                    // High card or flush
                    case 1:
                        return this.CompareHighCards(firstHand.Cards, secondHand.Cards);
                    // One pair
                    case 2:
                        return this.CompareHandsWithSameCards(firstHand.Cards, secondHand.Cards, 2);
                    // Three of a kind
                    case 3:
                        return this.CompareHandsWithSameCards(firstHand.Cards, secondHand.Cards, 3);
                    // Four of a kind
                    case 4:
                        return this.CompareHandsWithSameCards(firstHand.Cards, secondHand.Cards, 4);
                }
            }

            List<ICard> sortedFirstCards = firstHand.Cards.ToList();
            sortedFirstCards.Sort((x, y) => (int)x.Face - (int)y.Face);

            List<ICard> sortedSecondCards = secondHand.Cards.ToList();
            sortedSecondCards.Sort((x, y) => (int)x.Face - (int)y.Face);

            // Full House
            if (this.MaxNumberOfSameCards(firstHand) == 3)
            {
                var cardTypeOfTheFirstThreeOfAKind = sortedFirstCards[2];
                var cardTypeOfTheSecondThreeOfAKind = sortedSecondCards[2];
                if (cardTypeOfTheFirstThreeOfAKind.Face != cardTypeOfTheSecondThreeOfAKind.Face)
                {
                    return this.CompareFaceStrength(cardTypeOfTheFirstThreeOfAKind, cardTypeOfTheSecondThreeOfAKind);
                }

                ICard cardTypeOfTheFirstPair = null;
                if (sortedFirstCards[2].Face == sortedFirstCards[1].Face)
                {
                    cardTypeOfTheFirstPair = sortedFirstCards[3];
                }
                else
                {
                    cardTypeOfTheFirstPair = sortedFirstCards[1];
                }

                ICard cardTypeOfTheSecondPair = null;
                if (sortedSecondCards[2].Face == sortedSecondCards[1].Face)
                {
                    cardTypeOfTheSecondPair = sortedSecondCards[3];
                }
                else
                {
                    cardTypeOfTheSecondPair = sortedSecondCards[1];
                }

                if (cardTypeOfTheFirstPair.Face != cardTypeOfTheSecondPair.Face)
                {
                    return this.CompareFaceStrength(cardTypeOfTheFirstPair, cardTypeOfTheSecondPair);
                }

                return 0;
            }

            // Two pair

            ICard theFirstPairOfTheFirstHandType = sortedFirstCards[1];
            ICard theSecondPairOfTheFirstHandType = sortedFirstCards[3];
            ICard theFirstPairOfTheSecondHandType = sortedSecondCards[1];
            ICard theSecondPairOfTheSecondHandType = sortedSecondCards[3];

            if (theSecondPairOfTheFirstHandType.Face != theSecondPairOfTheSecondHandType.Face)
            {
                return this.CompareFaceStrength(theSecondPairOfTheFirstHandType, theSecondPairOfTheSecondHandType);
            }

            if (theFirstPairOfTheFirstHandType.Face != theFirstPairOfTheSecondHandType.Face)
            {
                return this.CompareFaceStrength(theFirstPairOfTheFirstHandType, theFirstPairOfTheSecondHandType);
            }

            ICard theRemainingCardInTheFirstHand =
                sortedFirstCards.Where(
                    x => x.Face != theFirstPairOfTheFirstHandType.Face && x.Face != theSecondPairOfTheFirstHandType.Face)
                    .First();
            ICard theRemainingCardInTheSecondHand =
                sortedSecondCards.Where(
                    x => x.Face != theFirstPairOfTheSecondHandType.Face && x.Face != theSecondPairOfTheSecondHandType.Face)
                    .First();

            return this.CompareFaceStrength(theRemainingCardInTheFirstHand, theRemainingCardInTheSecondHand);
        }

        private int MaxNumberOfSameCards(IHand hand)
        {
            int result = 1;

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                ICard typeOfCardToCheck = hand.Cards[i];
                int numberOfSuchCardsInTheHand = hand.Cards.Where(x => x.Face == typeOfCardToCheck.Face).Count();
                if (numberOfSuchCardsInTheHand > result)
                {
                    result = numberOfSuchCardsInTheHand;
                }
            }

            return result;
        }

        private string DeterminePairTwoPairOrFullHouseIfPairInTheHand(IHand hand)
        {
            List<ICard> theOtherCards = new List<ICard>();
            for (int i = 0; i < hand.Cards.Count; i++)
            {
                ICard typeOfCardToCheck = hand.Cards[i];
                int numberOfSuchCardsInTheHand = hand.Cards.Where(x => x.Face == typeOfCardToCheck.Face).Count();
                if (numberOfSuchCardsInTheHand == 2)
                {
                    theOtherCards = hand.Cards.Where(x => x.Face != typeOfCardToCheck.Face).ToList();
                    break;
                }
            }

            int maxNumberOfSameCards = 1;

            for (int i = 0; i < theOtherCards.Count; i++)
            {
                ICard typeOfCardToCheck = theOtherCards[i];
                int numberOfSuchCardsInTheOtherCards = theOtherCards.Where(x => x.Face == typeOfCardToCheck.Face).Count();

                if (numberOfSuchCardsInTheOtherCards > maxNumberOfSameCards)
                {
                    maxNumberOfSameCards = numberOfSuchCardsInTheOtherCards;
                }
            }

            return maxNumberOfSameCards == 1 ? "pair" : maxNumberOfSameCards == 2 ? "two pair" : "full house";
        }

        private int CompareFaceStrength(ICard firstCard, ICard secondCard)
        {
            return (int)firstCard.Face > (int)secondCard.Face ? 1 : (int)firstCard.Face == (int)secondCard.Face ? 0 : -1;
        }

        private int CompareHighCards(IList<ICard> firstCards, IList<ICard> secondCards)
        {
            List<ICard> sortedFirstCards = firstCards.ToList();
            sortedFirstCards.Sort((x, y) => (int)x.Face - (int)y.Face);

            List<ICard> sortedSecondCards = secondCards.ToList();
            sortedSecondCards.Sort((x, y) => (int)x.Face - (int)y.Face);

            for (int i = firstCards.Count - 1; i >= 0; i--)
            {
                if ((int)sortedFirstCards[i].Face != (int)sortedSecondCards[i].Face)
                {
                    return CompareFaceStrength(sortedFirstCards[i], sortedSecondCards[i]);
                }
            }

            return 0;
        }

        private int CompareHandsWithSameCards(IList<ICard> firstCards, IList<ICard> secondCards, int numberOfSameCards)
        {
            List<ICard> theOtherFirstcards = new List<ICard>();
            List<ICard> theOtherSecondcards = new List<ICard>();
            ICard typeOfTheSameCardsInFirstHand = null;
            ICard typeOfTheSameCardsInSecondHand = null;

            for (int i = 0; i < firstCards.Count; i++)
            {
                ICard typeOfCardToCheck = firstCards[i];
                int numberOfSuchCardsInTheHand = firstCards.Where(x => x.Face == typeOfCardToCheck.Face).Count();
                if (numberOfSuchCardsInTheHand == numberOfSameCards)
                {
                    typeOfTheSameCardsInFirstHand = typeOfCardToCheck;
                    theOtherFirstcards = firstCards.Where(x => x.Face != typeOfCardToCheck.Face).ToList();
                    break;
                }
            }

            for (int i = 0; i < secondCards.Count; i++)
            {
                ICard typeOfCardToCheck = secondCards[i];
                int numberOfSuchCardsInTheHand = secondCards.Where(x => x.Face == typeOfCardToCheck.Face).Count();
                if (numberOfSuchCardsInTheHand == numberOfSameCards)
                {
                    typeOfTheSameCardsInSecondHand = typeOfCardToCheck;
                    theOtherSecondcards = secondCards.Where(x => x.Face != typeOfCardToCheck.Face).ToList();
                    break;
                }
            }

            if (typeOfTheSameCardsInFirstHand.Face != typeOfTheSameCardsInSecondHand.Face)
            {
                return CompareFaceStrength(typeOfTheSameCardsInFirstHand, typeOfTheSameCardsInSecondHand);
            }

            return this.CompareHighCards(theOtherFirstcards, theOtherSecondcards);
        }
    }
}