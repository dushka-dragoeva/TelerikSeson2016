using IntergalacticTravel.Exceptions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticTravel.Tests.UnitsFactoryTests
{
    [TestFixture]
    class GetUnit_Should
    {
        
        [TestCase("create unit Procyon Gosho 1", typeof( Procyon))]
        [TestCase("create unit Luyten Pesho 2", typeof(Luyten))]
        [TestCase("create unit Lacaille Tosho 3", typeof(Lacaille))]
       
        public void ReturnCorrectUnitType_WhenValidCommandIsPassed( string command, Type type)
        {
            var factory = new UnitsFactory();
           
            var unit = factory.GetUnit(command);

            Assert.IsInstanceOf(type, unit);
        }

       [TestCase("Invalid Command")]
       [TestCase("create unit Gosho Tosho 3")]
        public void ThrowInvalidUnitCreationCommandException_WhenTheCommandIsNotValid(string command)
        {
            var factory = new UnitsFactory();

            Assert.Throws<InvalidUnitCreationCommandException>
                (() => factory.GetUnit(command));
        }
    }
}
