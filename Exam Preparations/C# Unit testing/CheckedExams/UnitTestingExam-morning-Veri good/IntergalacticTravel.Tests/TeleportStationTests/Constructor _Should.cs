using IntergalacticTravel.Contracts;
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
    class Constructor__Should
    {
        [Test]
        public void SetAllFields_WhenTeleportStationIsCreatedWithValidParameters()
        {
            var owner = new Mock<IBusinessOwner>();
            var galacticMap = new List<IPath>();
            var location = new Mock<ILocation>();

            var teleportStation = new MockedTeleportStation(owner.Object, galacticMap, location.Object);

            Assert.AreSame(owner.Object, teleportStation.Owner);
            Assert.AreSame(location.Object, teleportStation.Location);
            Assert.AreSame(galacticMap, teleportStation.GalacticMap);

        }
    }


    public class MockedTeleportStation : TeleportStation
    {
        public MockedTeleportStation
            (IBusinessOwner owner, IEnumerable<IPath> galacticMap, ILocation location)
            : base(owner, galacticMap, location)
        {
        }

        public IBusinessOwner Owner
        {
            get
            {
                return base.owner;
            }
        }

        public IEnumerable<IPath> GalacticMap
        {
            get
            {
                return base.galacticMap;
            }
        }

        public ILocation Location
        {
            get
            {
                return base.location;
            }
        }

        public IResources Resources
        {
            get
            {
              return  base.resources;
            }
        }


    }
}
