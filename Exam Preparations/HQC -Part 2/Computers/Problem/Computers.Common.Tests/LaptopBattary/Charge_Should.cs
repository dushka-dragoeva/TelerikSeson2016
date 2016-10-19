

using NUnit.Framework;

using Computers.Common.Models.Components;


/*•	Battery – can charge itself and has information about percentage power left. 
 * Currently there is only one type of battery in the system – laptop battery. 
 * It is created with 50% power left initially. It can charge itself with certain
 *  amount but never above 100 and below 0.*/

namespace Computers.Common.Tests.LaptopBattary
{
    [TestFixture]
    public class Charge_Should
    {

        [TestCase(-50, 0)]
        [TestCase(51, 100)]
        [TestCase(-10, 40)]
        public void ChargeBattary_WhenValidPossitiveIntegerIsPassed(int chargePercentage, int expected)
        {
            var battary = new LaptopBattery();
            battary.Charge(chargePercentage);
            var actual = battary.Percentage;
            Assert.AreEqual(expected, actual);
        }
    }
}

