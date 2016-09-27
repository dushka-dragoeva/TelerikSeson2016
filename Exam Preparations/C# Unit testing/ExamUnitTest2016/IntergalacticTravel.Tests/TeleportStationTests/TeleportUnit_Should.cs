using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticTravel.Tests.TeleportStationTests
{
    using NUnit.Framework;
    using Moq;
    using Contracts;
    using Mocks;
    using Exceptions;
    [TestFixture]
    public class TeleportUnit_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenIUnitUnitToTeleportIsNull_WithMassageCaontainigunitToTeleport()
        {
            // Arrange
            var messageExceptionSubstring = "unitToTeleport";
            var mockeOwner = new Mock<IBusinessOwner>();
            var mockedPath = new Mock<IPath>();
            var mockedGalacticMap = new List<IPath> { mockedPath.Object };
            var mockedLocation = new Mock<ILocation>();
            var teleportStation = new MockedTeleportStation(mockeOwner.Object, mockedGalacticMap, mockedLocation.Object);

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => teleportStation.TeleportUnit(null, It.IsAny<ILocation>()));
            StringAssert.Contains(messageExceptionSubstring, exception.Message);
        }

        [Test]
        public void ThrowArgumentNullException_WhenIUnitUnitToTeleportIsNull_WithMassageContainingDestination()
        {
            // Arrange
            var messageExceptionSubstring = "destination";
            var mockeOwner = new Mock<IBusinessOwner>();
            var mockedPath = new Mock<IPath>();
            var mockedGalacticMap = new List<IPath> { mockedPath.Object };
            var mockedLocation = new Mock<ILocation>();
            var teleportStation = new MockedTeleportStation(mockeOwner.Object, mockedGalacticMap, mockedLocation.Object);
            var mockedUnit = new Mock<IUnit>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => teleportStation.TeleportUnit(mockedUnit.Object, null));
            StringAssert.Contains(messageExceptionSubstring, exception.Message);
        }
        /*4.	TeleportUnit should throw TeleportOutOfRangeException, with a message that contains 
         * the string "unitToTeleport.CurrentLocation", when а unit is trying to use the 
         * TeleportStation from a distant location (another planet for example).*/


        [Test]
        public void ThrowTeleportOutOfRangeExceptionWithMassage_UnitToTeleportCurrentLocation_WhenIUnitUnitToTeleportIsOnOtherlocation()
        {
            // Arrange
            var messageExceptionSubstring = "unitToTeleport.CurrentLocation";
            var mockeOwner = new Mock<IBusinessOwner>();
            var mockedPath = new Mock<IPath>();
            var mockedGalacticMap = new List<IPath> { mockedPath.Object };
            var mockedLocation = new Mock<ILocation>();
            var teleportStation = new MockedTeleportStation(mockeOwner.Object, mockedGalacticMap, mockedLocation.Object);
            var mockedUnit = new Mock<IUnit>();
            var mockedPlanet = new Mock<IPlanet>();
            mockedUnit.SetupGet(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("Mars");
            mockedLocation.SetupGet(x => x.Planet.Galaxy.Name).Returns("Earth");

            // Act and Assert
            var exception = Assert.Throws<TeleportOutOfRangeException>(() => teleportStation.TeleportUnit(mockedUnit.Object, mockedLocation.Object));
            StringAssert.Contains(messageExceptionSubstring, exception.Message);
        }

        /*5.	TeleportUnit should throw InvalidTeleportationLocationException, 
         * with a message that contains the string "units will overlap" 
         * when trying to teleport a unit to a location which another unit has already taken.*/

        [Test]
        public void ThrowInvalidTeleportationLocationExceptionWithMassageUnitsWillOverlap_WhenLocationIsAlllreadyTaken()
        {
            // Arrange
            var messageExceptionSubstring = "units will overlap";
            var mockeOwner = new Mock<IBusinessOwner>();
            var mockedPath = new Mock<IPath>();
            var mockedGalacticMap = new List<IPath> { mockedPath.Object };
            var mockedLocation = new Mock<ILocation>();
            var teleportStation = new MockedTeleportStation(mockeOwner.Object, mockedGalacticMap, mockedLocation.Object);
            var mockedUnit = new Mock<IUnit>();
            var mockedPlanet = new Mock<IPlanet>();
            mockedUnit.SetupGet(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("Mars");
            mockedLocation.SetupGet(x => x.Planet.Galaxy.Name).Returns("Earth");

            // Act and Assert
            var exception = Assert.Throws<InvalidTeleportationLocationException>(() => teleportStation.TeleportUnit(mockedUnit.Object, mockedLocation.Object));
            StringAssert.Contains(messageExceptionSubstring, exception.Message);
        }

        /*6.	TeleportUnit should throw LocationNotFoundException, with a message 
         * that contains the string "Galaxy", when trying to teleport a unit to a Galaxy, 
         * which is not found in the locations list of the teleport station.*/



        [Test]
        public void ThrowLocationNotFoundExceptionWithMassageGalaxy_WhenCalaxyIsNotInListOFTheTeleportStation()
        {
            // Arrange
            var messageExceptionSubstring = "Galaxy";
            var mockeOwner = new Mock<IBusinessOwner>();
            var mockedPath = new Mock<IPath>();
             mockedPath.SetupGet(x => x.TargetLocation.Planet.Galaxy.Name).Returns("Milk");
             mockedPath.SetupGet(x => x.TargetLocation.Planet.Name).Returns("Mars");
            var mockedGalacticMap = new List<IPath> { mockedPath.Object };
            var mockedLocation = new Mock<ILocation>();
            var teleportStation = new MockedTeleportStation(mockeOwner.Object, mockedGalacticMap, mockedLocation.Object);
            var mockedUnit = new Mock<IUnit>();
            var mockedPlanet = new Mock<IPlanet>();
            mockedUnit.SetupGet(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("Meee");
            mockedUnit.SetupGet(x => x.CurrentLocation.Planet.Name).Returns("Mas");
            mockedLocation.SetupGet(x => x.Planet.Galaxy.Name).Returns("Meee");
           mockedLocation.SetupGet(x => x.Planet.Name).Returns("Mas");
            // Act and Assert

           // var firstLocation=

            var exception = Assert.Throws<LocationNotFoundException>(() => teleportStation.TeleportUnit(mockedUnit.Object, mockedLocation.Object));
             StringAssert.Contains(messageExceptionSubstring, exception.Message);
        }


    }
}
