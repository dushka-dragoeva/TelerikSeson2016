using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticTravel.Tests.ResourcesFactoryTests
{
    [TestFixture]
    class GetResources__Should
    {
        [TestCase("create resources gold(20) silver(30) bronze(40)")]
        [TestCase("create resources gold(20) bronze(40) silver(30)")]
        [TestCase("create resources silver(30) bronze(40) gold(20)")]
        [TestCase("create resources silver(30) gold(20) bronze(40)")]
        [TestCase("create resources bronze(40) gold(20) silver(30)")]
        [TestCase("create resources bronze(40) silver(30) gold(20)")]
        public void ReturnNewlyCreatedResourcesWithCorrectlySetProperties_WhenInputStringIsInTheCorrectFormat( string command)
        {
            var factory = new ResourcesFactory();           

            var resource = factory.GetResources(command);

            Assert.True( resource.BronzeCoins == 40 &&
                         resource.SilverCoins == 30 &&
                         resource.GoldCoins == 20 );
        }

        [TestCase("create resources x y z")]
        [TestCase("tansta resources a b")]
        [TestCase("absolutelyRandomStringThatMustNotBeAValidCommand")]
        public void ThrowInvalidOperationExceptionWithMessageContainingCommand_WhenInvalidCommandIsPassed(string command)
        {
            var factory = new ResourcesFactory();
            var expectedMessage = "command";

            var exc = Assert.Throws<InvalidOperationException>
                (() => factory.GetResources(command));

            StringAssert.Contains(expectedMessage, exc.Message);
        }

        [TestCase("create resources silver(10) gold(97853252356623523532) bronze(20)")]
        [TestCase("create resources silver(555555555555555555555555555555555) gold(97853252356623523532999999999) bronze(20)")]
        [TestCase("create resources silver(10) gold(20) bronze(4444444444444444444444444444444444444)")]
        public void ThrowOverflowException_WhenCommandIsInValidFormatButSomeOfTheResourcesHasLargerValueThanIntMaxValue(string command)
        {
            var factory = new ResourcesFactory();

            Assert.Throws<OverflowException>(() => factory.GetResources(command));

        }
    }
}
