using System.Collections.Generic;
using Computers.Common.Contracts;
using Computers.Common.Models.Components;

namespace Computers.Common.Models.Configurations
{
    public class Laptop : Computer
    {
        private readonly ILaptopBattery battery;

        public Laptop(ICpu cpu, IRam ram, IEnumerable<IHardDriver> driver, IVideoCard videoCard, ILaptopBattery battery) :
            base(cpu, ram, driver, videoCard)
        {
            this.battery = battery;
        }

        public void ChargeBattery(int percentage)
        {
            this.battery.Charge(percentage);

            Motherboard.DrawOnVideoCard($"Battery status: {this.battery.Percentage}%");
        }
    }
}
