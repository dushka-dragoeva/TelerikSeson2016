using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticTravel.Tests.TeleportStationTests
{
    using NUnit.Framework;
    using Moq;
    using Exceptions;
    using Constants;
    using Contracts;
    using Mocks;
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void SetUpAllFields_whenValidParametersArePassed()
        {
            // Arrange
            var mockeOwner = new Mock<IBusinessOwner>();
            var mockedPath = new Mock<IPath>();
            var mockedGalacticMap = new List<IPath> { mockedPath.Object };
            var mockedLocation = new Mock<ILocation>();

            //Act
            var teleportStation = new MockedTeleportStation(mockeOwner.Object, mockedGalacticMap, mockedLocation.Object);
            var actualOwner = teleportStation.Owner;
            var actualMap = teleportStation.GlacticMap;
            var actualLocation = teleportStation.Location;

            // Assert
            Assert.AreEqual(mockeOwner.Object, actualOwner);
            Assert.AreEqual(mockedGalacticMap, actualMap);
            Assert.AreEqual(mockedLocation.Object, actualLocation);
        }
    }
}
