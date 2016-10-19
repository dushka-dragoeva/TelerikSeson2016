using System;
using Computers.Common.Contracts;

namespace Computers.Common.Models.Components
{
    public class Motherboard : IMotherboard
    {
        public Motherboard(ICpu cpu, IRam ram, IVideoCard videoCard)
        {
            cpu.Motherboard = this;
            this.Cpu = cpu;

            ram.Motherboard = this;
            this.Ram = ram;

            videoCard.Motherboard = this;
            this.VideoCard = videoCard;
        }

        public ICpu Cpu { get; private set; }

        public IRam Ram { get; private set; }

        public IVideoCard VideoCard { get; private set; }

        public void DrawOnVideoCard(string data)
        {
            this.VideoCard.Draw(data);
        }

        public int LoadRamValue()
        {
            return this.Ram.LoadValue();
        }

        public void SaveRamValue(int value)
        {
            this.Ram.SaveValue(value);
        }
    }
}
