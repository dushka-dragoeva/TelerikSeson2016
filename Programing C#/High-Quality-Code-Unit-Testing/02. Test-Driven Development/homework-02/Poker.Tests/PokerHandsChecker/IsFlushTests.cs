﻿namespace Poker.Tests.PokerHandsChecker
{
    using NUnit.Framework;

    using Poker;
    using Poker.Tests.Data;
    using Poker.Tests.Fakes;

    [TestFixture]
    public class IsFlushTests
    {
        [Test]
        [TestCaseSource(typeof(PokerHandsCheckerTestsData), PokerHandsCheckerTestsData.IsFlushAllSuitsCasesEnumerable)]
        public bool IsFlush_HandHasFiveCardsOfTheSameSuit_ShouldReturnTrue(IHand hand)
        {
            var pokerHandChecker = new PokerHandsChecker();

            var actualResult = pokerHandChecker.IsFlush(hand);

            return actualResult;
        }

        [Test]
        public void IsFlush_HandHasAtLeastOneCardOfADifferentSuitComparedToTheRest_ShouldReturnFalse()
        {
            var flushHand = new HandTypePresetsFakeHand(HandType.IsHighCard);
            var pokerHandsChecker = new PokerHandsChecker();

            var actualResult = pokerHandsChecker.IsFlush(flushHand);

            Assert.IsFalse(actualResult);
        }

        [Test]
        public void IsFlush_HandHasFiveCardsOfTheSameSuitWhichAreSequential_ShouldReturnFalse()
        {
            var flushHand = new HandTypePresetsFakeHand(HandType.IsStraightFlush);
            var pokerHandsChecker = new PokerHandsChecker();

            var actualResult = pokerHandsChecker.IsFlush(flushHand);

            Assert.IsFalse(actualResult);
        }

        [Test]
        public void IsFlush_HandHasFiveCardsOfTheSameSuitWhichAreNotSequential_ShouldReturnTrue()
        {
            // Assert
            var flushHand = new HandTypePresetsFakeHand(HandType.IsFlush);
            var pokerHandsChekcer = new PokerHandsChecker();

            // Act
            var actualResult = pokerHandsChekcer.IsFlush(flushHand);

            // Assert
            Assert.IsTrue(actualResult);
        }
    }
}
