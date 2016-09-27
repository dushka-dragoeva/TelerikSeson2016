using IntergalacticTravel.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticTravel.Tests.UnitsTests
{
    [TestFixture]
    class Pay_Should
    {

        [Test]
        public void ThrowNullReferenceException_WhenThePassedObjectIsNull()
        {
            var unit = new Unit(5, "Gosho");

            Assert.Throws<NullReferenceException>(() => unit.Pay(null));
        }

        [Test]
        public void DecreaseOwnersAmountOfResourcesByAmountOfCost()
        {
            var unit = new Unit(5, "Gosho");
            unit.Resources.BronzeCoins = 10;
            var cost = new Mock<IResources>();
            cost.SetupGet(x => x.BronzeCoins).Returns(10);
            cost.SetupGet(x => x.GoldCoins).Returns(0);
            cost.SetupGet(x => x.SilverCoins).Returns(0);

            unit.Pay(cost.Object);

            Assert.True(unit.Resources.BronzeCoins == 0);
        }

        [Test]
        public void ReturnResourceObjectWithTheAmountOfResourcesInTheCost()
        {
            var unit = new Unit(5, "Gosho");
            unit.Resources.BronzeCoins = 10;
            var cost = new Mock<IResources>();

            cost.SetupGet(x => x.BronzeCoins).Returns(10);
            cost.SetupGet(x => x.GoldCoins).Returns(0);
            cost.SetupGet(x => x.SilverCoins).Returns(0);

          var returnedResouce = unit.Pay(cost.Object);

            Assert.True(returnedResouce.BronzeCoins == 10 &&
                        returnedResouce.GoldCoins == 0 &&
                        returnedResouce.SilverCoins == 0);
        }

    }
}
