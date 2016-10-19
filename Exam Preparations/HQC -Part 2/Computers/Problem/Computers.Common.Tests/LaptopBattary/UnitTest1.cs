using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Computers.Common.Models.Components;

namespace Computers.Common.Tests.LaptopBattary
{
    [TestFixture]
    public class Charge_ShouldDo
    {

        [Test]
        public void ChargeBattary_WhenValidPossitiveIntegerIsPassed()
        {
            var battary = new LaptopBattery();
            battary.Charge(10);
            var actual = battary.Percentage;
            var expected = 60;
            NUnit.Framework.Assert.AreEqual(expected, actual);
        }
    }
}
