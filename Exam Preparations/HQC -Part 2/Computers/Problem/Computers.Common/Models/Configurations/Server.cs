using System.Collections.Generic;
using Computers.Common.Contracts;

namespace Computers.Common.Models.Configurations
{
    public class Server : Computer
    {
        public Server(ICpu cpu, IRam ram, IEnumerable<IHardDriver> driver, IVideoCard videoCard) :
            base(cpu, ram, driver, videoCard)
        {
        }

        public void Process(int data)
        {
            Motherboard.SaveRamValue(data);
            this.Cpu.SquareNumber();
        }
    }
}
