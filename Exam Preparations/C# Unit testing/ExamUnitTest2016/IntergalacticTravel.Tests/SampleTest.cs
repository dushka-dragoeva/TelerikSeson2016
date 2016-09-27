
namespace IntergalacticTravel.Tests
{
    using System;

    using Moq;
    using NUnit.Framework;
    using Exceptions;
    using Contracts;
    using System.Collections.Generic;
    using TeleportStationTests.Mocks;
    [TestFixture]
    public class test
    {

        [Test]
        public void Pay_ShouldThrowNullReferenceException_IfTheObjectPassedIsNull()
        {
            var unit = new Unit(3, null);

            Assert.Throws<NullReferenceException>(() => unit.Pay(null));
        }

        [Test]
        public void Pay_ShouldDecreaseOwnersAmountOfResources_ByTheAmountOfCost()
        {
            var unit = new Unit(1234, "Gosho");
            var cost = new Resources(10, 20, 30);
            unit.Resources.BronzeCoins = 20;
            unit.Resources.SilverCoins = 30;
            unit.Resources.GoldCoins = 40;
            unit.Pay(cost);
            Assert.AreEqual(10, unit.Resources.BronzeCoins);
            Assert.AreEqual(10, unit.Resources.SilverCoins);
            Assert.AreEqual(10, unit.Resources.GoldCoins);
        }
    }
}

