namespace IntergalacticTravel.Tests.UnitsFactoryTests
{
    using NUnit.Framework;
    using Exceptions;

    [TestFixture]
    public class GetUnit_Should
    {
        [Test]
        public void RreturnNewProcyonUnit_WhenValidCorrespondingCommandIsPassed()
        {
            // Arrange
            var command = "create unit Procyon Gosho 1";
            var factory = new UnitsFactory();
            var expected = "Procyon";

            // Act
            var unit = factory.GetUnit(command);

            // Assert

            Assert.AreEqual(expected, unit.GetType().Name);
        }

        [Test]
        public void RreturnNewLuytenUnit_WhenValidCorrespondingCommandIsPassed()
        {
            // Arrange
            var command = "create unit Luyten Pesho 2";
            var factory = new UnitsFactory();
            var expected = "Luyten";

            // Act
            var unit = factory.GetUnit(command);

            // Assert

            Assert.AreEqual(expected, unit.GetType().Name);
        }

        [Test]
        public void RreturnNewLacailleUnit_WhenValidCorrespondingCommandIsPassed()
        {
            // Arrange
            var command = "create unit Lacaille Tosho 3";
            var factory = new UnitsFactory();
            var expected = "Lacaille";

            // Act
            var unit = factory.GetUnit(command);

            // Assert

            Assert.AreEqual(expected, unit.GetType().Name);
        }

        [TestCase ("create unit Lacaille Tosho ")]
        [TestCase("create unit Lacaille    3")]
        [TestCase("   unit Lacaille Tosho 3")]
        [TestCase("create unit  Tosho 3")]
        [TestCase("create")]

        public void ThrowInvalidUnitCreationCommandException_WhenInwalidCommandIsPassed(string command)
        {
            // Arrange
            var factory = new UnitsFactory();

            //Act and Assert

            Assert.Throws<InvalidUnitCreationCommandException>(()=> factory.GetUnit(command));
        }

    }
}
