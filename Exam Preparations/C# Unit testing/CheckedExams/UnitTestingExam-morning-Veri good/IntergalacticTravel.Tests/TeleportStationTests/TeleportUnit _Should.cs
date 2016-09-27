using IntergalacticTravel.Contracts;
using IntergalacticTravel.Exceptions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticTravel.Tests.TeleportStationTests
{
    [TestFixture]
    class TeleportUnit__Should
    {

        private static ICollection<IUnit> units = new List<IUnit>()
        {
            new Unit(5, "Gosho")
        };

        

        [Test]
        public void ThrowArgumentNullExceptionWithMessageContainingUnitToTeleport_WhenUnitToTeleportIsNull()
        {
            var owner = new Mock<IBusinessOwner>();
            var galacticMap = new List<IPath>();
            var location = new Mock<ILocation>();
            var teleportStation = new TeleportStation(owner.Object, galacticMap, location.Object);
            var expectedMessage = "unitToTeleport";

            var exc = Assert.Throws<ArgumentNullException>
                (() => teleportStation.TeleportUnit(null, location.Object));

            StringAssert.Contains(expectedMessage, exc.Message);
        }

        [Test]
        public void ThrowArgumentNullExceptionWithMessageContainingUnitToTeleport_WhenLocationIsNull()
        {
            var owner = new Mock<IBusinessOwner>();
            var galacticMap = new List<IPath>();
            var location = new Mock<ILocation>();
            var teleportStation = new TeleportStation(owner.Object, galacticMap, location.Object);
            var expectedMessage = "destination";
            var unit = new Mock<IUnit>();

            var exc = Assert.Throws<ArgumentNullException>
                (() => teleportStation.TeleportUnit(unit.Object, null));

            StringAssert.Contains(expectedMessage, exc.Message);
        }

        [Test]
        public void ThrowTeleportOutOfRangeExceptionWithProperMessage_WhenUnitTriesToTeleportFromDistantLocation()
        {
            var owner = new Mock<IBusinessOwner>();
            var galacticMap = new List<IPath>();
            var location = new Mock<ILocation>();
            location.SetupGet(x=> x.Planet.Name).Returns("Gosho");
            location.SetupGet(x => x.Planet.Galaxy.Name).Returns("Gosho");

            var teleportStation = new TeleportStation
                (owner.Object, galacticMap, location.Object);
            var expectedMessage = "unitToTeleport.CurrentLocation";
            var unit = new Mock<IUnit>();
            unit.SetupGet(x => x.CurrentLocation.Planet.Name).Returns("Pesho");
            unit.SetupGet(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("Gosho");

            var exc = Assert.Throws<TeleportOutOfRangeException>
                (() => teleportStation.TeleportUnit(unit.Object, location.Object));

            StringAssert.Contains(expectedMessage, exc.Message);

        }

        [Test]
        public void ThrowInvalidTeleportationLocationExceptionWithProperMessage_WhenTryingToTeleportToTakenLocation()
        {
            var owner = new Mock<IBusinessOwner>();
            var galacticMap = new List<IPath>();
            var location = new Mock<ILocation>();
            location.SetupGet(x => x.Planet.Name).Returns("Gosho");
            location.SetupGet(x => x.Planet.Galaxy.Name).Returns("Gosho");
            location.SetupGet(x => x.Coordinates.Latitude).Returns(1);
            location.SetupGet(x => x.Coordinates.Longtitude).Returns(1);

            var teleportStation = new TeleportStation
                (owner.Object, galacticMap, location.Object);
            var expectedMessage = "units will overlap";

            var unit = new Mock<IUnit>();
            unit.SetupGet(x => x.CurrentLocation.Planet.Name).Returns("Gosho");
            unit.SetupGet(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("Gosho");

            var unitInPath = new Mock<IUnit>();
            unitInPath.SetupGet(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("Gosho");
            unitInPath.SetupGet(x => x.CurrentLocation.Planet.Name).Returns("Gosho");
            unitInPath.SetupGet(x => x.CurrentLocation.Coordinates.Latitude).Returns(1);
            unitInPath.SetupGet(x => x.CurrentLocation.Coordinates.Longtitude).Returns(1);

            var UnitsInPath = new List<IUnit>() { unitInPath.Object };
            var path = new Mock<IPath>();
            path.SetupGet(x => x.TargetLocation.Planet.Galaxy.Name).Returns("Gosho");
            path.SetupGet(x => x.TargetLocation.Planet.Name).Returns("Gosho");
            path.SetupGet(x => x.TargetLocation.Planet.Units).Returns(UnitsInPath);
            galacticMap.Add(path.Object);

            var exc = Assert.Throws<InvalidTeleportationLocationException>
                (() => teleportStation.TeleportUnit(unit.Object, location.Object));

            StringAssert.Contains(expectedMessage, exc.Message);

            //Sorry for the long test but i couldn't figure out how to do it otherwise

        }


        [Test]
        public void ThrowLocationNotFoundExceptionWithProperMessage_WhenTryingToTravelToNonExistingGalaxy()
        {
            var owner = new Mock<IBusinessOwner>();
            var galacticMap = new List<IPath>();
            var location = new Mock<ILocation>();
            location.SetupGet(x => x.Planet.Name).Returns("Gosho");
            location.SetupGet(x => x.Planet.Galaxy.Name).Returns("Gosho");

            var teleportStation = new TeleportStation
                (owner.Object, galacticMap, location.Object);
            var expectedMessage = "Galaxy";
            var unit = new Mock<IUnit>();
            unit.SetupGet(x => x.CurrentLocation.Planet.Name).Returns("Gosho");
            unit.SetupGet(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("Gosho");

            var path = new Mock<IPath>();
            path.SetupGet(x => x.TargetLocation.Planet.Galaxy.Name).Returns("Pesho");
            galacticMap.Add(path.Object);

            var exc = Assert.Throws<LocationNotFoundException>
                (() => teleportStation.TeleportUnit(unit.Object, location.Object));

            StringAssert.Contains(expectedMessage, exc.Message);
        }

        [Test]
        public void ThrowLocationNotFoundExceptionWithProperMessage_WhenTryingToTravelToNonExistingPlanet()
        {
            var owner = new Mock<IBusinessOwner>();
            var galacticMap = new List<IPath>();
            var location = new Mock<ILocation>();
            location.SetupGet(x => x.Planet.Name).Returns("Gosho");
            location.SetupGet(x => x.Planet.Galaxy.Name).Returns("Gosho");

            var teleportStation = new TeleportStation
                (owner.Object, galacticMap, location.Object);
            var expectedMessage = "Planet";
            var unit = new Mock<IUnit>();
            unit.SetupGet(x => x.CurrentLocation.Planet.Name).Returns("Gosho");
            unit.SetupGet(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("Gosho");

            var path = new Mock<IPath>();
            path.SetupGet(x => x.TargetLocation.Planet.Galaxy.Name).Returns("Gosho");
            path.SetupGet(x => x.TargetLocation.Planet.Name).Returns("Pesho");
            galacticMap.Add(path.Object);

            var exc = Assert.Throws<LocationNotFoundException>
                (() => teleportStation.TeleportUnit(unit.Object, location.Object));

            StringAssert.Contains(expectedMessage, exc.Message);
        }

        [Test]
        public void ThrowInsufficientResourcesExceptionWithProperMessage_WhenUnitCannotPayTeleportation()
        {
            var owner = new Mock<IBusinessOwner>();
            var galacticMap = new List<IPath>();
            var location = new Mock<ILocation>();
            location.SetupGet(x => x.Planet.Name).Returns("Gosho");
            location.SetupGet(x => x.Planet.Galaxy.Name).Returns("Gosho");
            location.SetupGet(x => x.Coordinates.Latitude).Returns(1);
            location.SetupGet(x => x.Coordinates.Longtitude).Returns(1);

            var teleportStation = new TeleportStation
                (owner.Object, galacticMap, location.Object);
            var expectedMessage = "FREE LUNCH";

            var unit = new Mock<IUnit>();
            unit.SetupGet(x => x.CurrentLocation.Planet.Name).Returns("Gosho");
            unit.SetupGet(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("Gosho");
            unit.SetupGet(x => x.Resources.GoldCoins).Returns(2);
            unit.SetupGet(x => x.Resources.BronzeCoins).Returns(2);
            unit.SetupGet(x => x.Resources.SilverCoins).Returns(2);


            var unitInPath = new Mock<IUnit>();
            unitInPath.SetupGet(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("Gosho");
            unitInPath.SetupGet(x => x.CurrentLocation.Planet.Name).Returns("Gosho");
            unitInPath.SetupGet(x => x.CurrentLocation.Coordinates.Latitude).Returns(1);
            unitInPath.SetupGet(x => x.CurrentLocation.Coordinates.Longtitude).Returns(2);

            var cost = new Mock<IResources>();
            cost.SetupGet(x => x.BronzeCoins).Returns(5);
            cost.SetupGet(x => x.GoldCoins).Returns(5);
            cost.SetupGet(x => x.SilverCoins).Returns(5);

            var UnitsInPath = new List<IUnit>() { unitInPath.Object };
            var path = new Mock<IPath>();
            path.SetupGet(x => x.TargetLocation.Planet.Galaxy.Name).Returns("Gosho");
            path.SetupGet(x => x.TargetLocation.Planet.Name).Returns("Gosho");
            path.SetupGet(x => x.TargetLocation.Planet.Units).Returns(UnitsInPath);
            path.SetupGet(x => x.Cost).Returns(cost.Object);
            galacticMap.Add(path.Object);

            var exc = Assert.Throws<InsufficientResourcesException>
                (() => teleportStation.TeleportUnit(unit.Object, location.Object));

            StringAssert.Contains(expectedMessage, exc.Message);
            // It got worse...

        }

        [Test]
        public void RequirePaymentFromUnit_WhenAllValidationsPass()
        {
            var owner = new Mock<IBusinessOwner>();
            var galacticMap = new List<IPath>();
            var location = new Mock<ILocation>();
            location.SetupGet(x => x.Planet.Name).Returns("Gosho");
            location.SetupGet(x => x.Planet.Galaxy.Name).Returns("Gosho");
            location.SetupGet(x => x.Coordinates.Latitude).Returns(1);
            location.SetupGet(x => x.Coordinates.Longtitude).Returns(1);
            var cost = new Mock<IResources>();
            cost.SetupGet(x => x.BronzeCoins).Returns(1);
            cost.SetupGet(x => x.GoldCoins).Returns(1);
            cost.SetupGet(x => x.SilverCoins).Returns(1);

            var teleportStation = new TeleportStation
                (owner.Object, galacticMap, location.Object);

            var unitInPath = new Mock<IUnit>();
            unitInPath.SetupGet(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("Gosho");
            unitInPath.SetupGet(x => x.CurrentLocation.Planet.Name).Returns("Gosho");
            unitInPath.SetupGet(x => x.CurrentLocation.Coordinates.Latitude).Returns(1);
            unitInPath.SetupGet(x => x.CurrentLocation.Coordinates.Longtitude).Returns(2);

            var UnitsInPath = new List<IUnit>() { unitInPath.Object };

            var unit = new Mock<IUnit>();
            unit.SetupGet(x => x.CurrentLocation.Planet.Name).Returns("Gosho");
            unit.SetupGet(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("Gosho");
            unit.SetupGet(x => x.Resources.GoldCoins).Returns(12);
            unit.SetupGet(x => x.Resources.BronzeCoins).Returns(12);
            unit.SetupGet(x => x.Resources.SilverCoins).Returns(12);
            unit.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);
            unit.Setup(x => x.Pay(It.IsAny<IResources>())).Returns(cost.Object);
            unit.Setup(x => x.CurrentLocation).Returns(location.Object);
            unit.Setup(x => x.PreviousLocation).Returns(location.Object);
            unit.Setup(x => x.CurrentLocation.Planet.Units).Returns(UnitsInPath);

         
            var path = new Mock<IPath>();
            path.SetupGet(x => x.TargetLocation.Planet.Galaxy.Name).Returns("Gosho");
            path.SetupGet(x => x.TargetLocation.Planet.Name).Returns("Gosho");
            path.SetupGet(x => x.TargetLocation.Planet.Units).Returns(UnitsInPath);
            path.SetupGet(x => x.Cost).Returns(cost.Object);
            galacticMap.Add(path.Object);

             teleportStation.TeleportUnit(unit.Object, location.Object);

            unit.Verify(x => x.Pay(It.IsAny<IResources>()), Times.Once);

        }

        [Test]
        public void ObtainPayment_WhenUnitIsReadyForTeleportation()
        {
            var owner = new Mock<IBusinessOwner>();
            var galacticMap = new List<IPath>();
            var location = new Mock<ILocation>();
            location.SetupGet(x => x.Planet.Name).Returns("Gosho");
            location.SetupGet(x => x.Planet.Galaxy.Name).Returns("Gosho");
            location.SetupGet(x => x.Coordinates.Latitude).Returns(1);
            location.SetupGet(x => x.Coordinates.Longtitude).Returns(1);
            var cost = new Mock<IResources>();
            cost.SetupGet(x => x.BronzeCoins).Returns(1);
            cost.SetupGet(x => x.GoldCoins).Returns(1);
            cost.SetupGet(x => x.SilverCoins).Returns(1);

            var teleportStation = new MockedTeleportStation
                (owner.Object, galacticMap, location.Object);

            var unitInPath = new Mock<IUnit>();
            unitInPath.SetupGet(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("Gosho");
            unitInPath.SetupGet(x => x.CurrentLocation.Planet.Name).Returns("Gosho");
            unitInPath.SetupGet(x => x.CurrentLocation.Coordinates.Latitude).Returns(1);
            unitInPath.SetupGet(x => x.CurrentLocation.Coordinates.Longtitude).Returns(2);

            var UnitsInPath = new List<IUnit>() { unitInPath.Object };

            var unit = new Mock<IUnit>();
            unit.SetupGet(x => x.CurrentLocation.Planet.Name).Returns("Gosho");
            unit.SetupGet(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("Gosho");
            unit.SetupGet(x => x.Resources.GoldCoins).Returns(12);
            unit.SetupGet(x => x.Resources.BronzeCoins).Returns(12);
            unit.SetupGet(x => x.Resources.SilverCoins).Returns(12);
            unit.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);
            unit.Setup(x => x.Pay(It.IsAny<IResources>())).Returns(cost.Object);
            unit.Setup(x => x.CurrentLocation).Returns(location.Object);
            unit.Setup(x => x.PreviousLocation).Returns(location.Object);
            unit.Setup(x => x.CurrentLocation.Planet.Units).Returns(UnitsInPath);


            var path = new Mock<IPath>();
            path.SetupGet(x => x.TargetLocation.Planet.Galaxy.Name).Returns("Gosho");
            path.SetupGet(x => x.TargetLocation.Planet.Name).Returns("Gosho");
            path.SetupGet(x => x.TargetLocation.Planet.Units).Returns(UnitsInPath);
            path.SetupGet(x => x.Cost).Returns(cost.Object);
            galacticMap.Add(path.Object);

            teleportStation.TeleportUnit(unit.Object, location.Object);

            Assert.True(teleportStation.Resources.BronzeCoins == 1 &&
                        teleportStation.Resources.GoldCoins == 1 &&
                        teleportStation.Resources.SilverCoins == 1 );
        }







    }
}
