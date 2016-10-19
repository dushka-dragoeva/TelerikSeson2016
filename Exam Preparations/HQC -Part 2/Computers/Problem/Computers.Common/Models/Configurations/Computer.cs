using System.Collections.Generic;
using Computers.Common.Contracts;
using Computers.Common.Models.Components;

namespace Computers.Common.Models.Configurations
{
    public abstract class Computer
    {
        public Computer(ICpu cpu, IRam ram, IEnumerable<IHardDriver> driver, IVideoCard videoCard)
        {
            this.Cpu = cpu;
            this.Ram = ram;
            this.Driver = driver; // to do
            this.VideoCard = videoCard;
            this.Motherboard = new Motherboard(this.Cpu, this.Ram, this.VideoCard);
        }

        protected IMotherboard Motherboard { get; set; }

        protected ICpu Cpu { get; set; }

        protected IRam Ram { get; set; }

        protected IEnumerable<IHardDriver> Driver { get; set; }

        protected IVideoCard VideoCard { get; set; }
    }
}
