namespace IntergalacticTravel.Tests.ResourcesFactoryTests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class GetResources_Should
    {
        [TestCase("create resources gold(20) silver(30) bronze(40)", 20, 30, 40)]
        [TestCase("create resources gold(20) bronze(40) silver(30)", 20, 30, 40)]
        [TestCase("create resources silver(30) bronze(40) gold(20)", 20, 30, 40)]
        [TestCase("create resources bronze(40) gold(20) silver(30)", 20, 30, 40)]
        [TestCase("create resources silver(30) gold(20) bronze(40)", 20, 30, 40)]
        [TestCase("create resources bronze(40) silver(30) gold(20)", 20, 30, 40)]
        public void ReturnNewResourcesWithCorrectlysetUpProperties_WhenValidInputStringIsPassed_ButTheOrderOfTheParametersIsDifferent(
            string command,
            int goldCoins,
            int silverCoins,
            int bronzeCoins)
        {
            // Arrange
            var factory = new ResourcesFactory();

            // Act
            var resources = factory.GetResources(command);

            // Assert
            Assert.IsTrue(resources.GoldCoins == goldCoins &&
                    resources.SilverCoins == silverCoins &&
                    resources.BronzeCoins == bronzeCoins);
        }

        [TestCase("create resources x y z")]
        [TestCase("absolutelyRandomStringThatMustNotBeAValidCommand")]
        public void ThrowInvalidOperationException_WhenInvalidInputStringIsPassed(string command)
        {
            // Arrange
            var factory = new ResourcesFactory();
            var commandMessageSubstring = "command";

            //Act and Assert
            var exception = Assert.Throws<InvalidOperationException>(() => factory.GetResources(command));
            StringAssert.Contains(commandMessageSubstring, exception.Message);
        }

        [TestCase("create resources silver(10) gold(97853252356623523532) bronze(20")]
        [TestCase("create resources silver(555555555555555555555555555555555) gold(97853252356623523532999999999) bronze(20)")]
        [TestCase("create resources silver(10) gold(20) bronze(4444444444444444444444444444444444444)")]
        public void ThrowOverflowException_WhenAnyValueIsMoreThanIntMaxValue(string command)
        {
            // Arrange
            var factory = new ResourcesFactory();

            //Act and Assert
            Assert.Throws<OverflowException>(() => factory.GetResources(command));
        }
    }
}
