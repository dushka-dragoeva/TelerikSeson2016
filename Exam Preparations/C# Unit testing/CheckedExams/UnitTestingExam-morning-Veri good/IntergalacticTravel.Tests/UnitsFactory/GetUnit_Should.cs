using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticTravel.Tests.UnitsFactory
{
    [TestFixture]
    public class GetUnit_Should
    {
        [Test]
        public void ReturnNewProcyon_WhenValidCorrespondingCommandIsPassed()
        {
            // Arrange
            var factory = new IntergalacticTravel.UnitsFactory();

            // Act
            var unit = factory.GetUnit("create unit Procyon Gosho 1");

            // Assert
            Assert.IsInstanceOf<Procyon>(unit);
        }
    }
}
