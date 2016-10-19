using System.Collections.Generic;
using Computers.Common.Contracts;

namespace Computers.Common.Models.Components
{
    public class HardDriver : IHardDriver
    {
        private readonly Dictionary<int, string> data = new Dictionary<int, string>();

        public HardDriver(int capacity)
        {
            this.Capacity = capacity;
        }

        public int Capacity { get; private set; }

        public void SaveData(int addr, string newData)
        {
            this.data[addr] = newData;
        }

        public string LoadData(int address)
        {
            return this.data[address];
        }
    }
}