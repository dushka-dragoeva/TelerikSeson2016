using System;
using System.Collections.Generic;
using System.Linq;
using Computers.Common.Contracts;

namespace Computers.Common.Models.Components
{
    public class RaidArrays : IHardDriver
    {
        private const string NoHardDriveInTheRaid = "No hard drive in the RAID array!";

        private IEnumerable<HardDriver> hardDrivers;

        public RaidArrays()
        {
            this.hardDrivers = new List<HardDriver>();
        }

        public RaidArrays(IEnumerable<HardDriver> hardDrivers)
            : this()
        {
            this.hardDrivers = hardDrivers;
        }

        public int Capacity
        {
            get
            {
                if (!this.hardDrivers.Any())
                {
                    return 0;
                }

                return this.hardDrivers.First().Capacity;
            }
        }

        public void SaveData(int addr, string newData)
        {
            foreach (var hardDrive in this.hardDrivers)
            {
                hardDrive.SaveData(addr, newData);
            }
        }

        public string LoadData(int address)
        {
            if (!this.hardDrivers.Any())
            {
                throw new OutOfMemoryException(NoHardDriveInTheRaid);
            }

            return this.hardDrivers.First().LoadData(address);
        }
    }
}
