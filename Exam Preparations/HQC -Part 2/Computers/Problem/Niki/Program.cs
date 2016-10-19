using System;

using System.Collections.Generic;
using Computers.Common.Contracts;
using Computers.Common.Models.Components;
using Computers.Common.Models.Configurations;

namespace Computers.UI.Consolen.Models.Components
{
    internal class Computers
    {
        private static readonly int[] DiscCapacity = new int[] { 500, 1000, 2000 };

        private static PersonalComputor pc;
        private static Laptop laptop;
        private static Server server;

        public static int[] DiscCapacity1
        {
            get
            {
                return DiscCapacity;
            }
        }

        public static void Main()
        {
            var manufacturer = Console.ReadLine();
            if (manufacturer == "HP")
            {
                pc = new PersonalComputor(new Cpu32(4), new Ram(2), new IHardDriver[] { new HardDriver(500) }, new ColorVideoCard());
                var raid = new List<IHardDriver>
                    {
                        new RaidArrays(new List<HardDriver> { new HardDriver(1000), new HardDriver(1000) })
                    };
                server = new Server(new Cpu32(2), new Ram(2), raid, new MonochromeVideoCard());
                laptop = new Laptop(new Cpu64(4), new Ram(4), new HardDriver[] { new HardDriver(500) }, new ColorVideoCard(), new LaptopBattery());
            }
            else if (manufacturer == "Dell")
            {
                pc = new PersonalComputor(new Cpu64(4), new Ram(8), new HardDriver[] { new HardDriver(500) }, new ColorVideoCard());
                var raid = new List<IHardDriver>
                    {
                        new RaidArrays(new List<HardDriver> { new HardDriver(2000), new HardDriver(2000) })
                    };
                server = new Server(new Cpu64(4), new Ram(64), new HardDriver[] { new HardDriver(1000) }, new MonochromeVideoCard());
                laptop = new Laptop(new Cpu32(4), new Ram(8), new HardDriver[] { new HardDriver(1000) }, new ColorVideoCard(), new LaptopBattery());
            }
            else if (manufacturer == "Lenovo")
            {
                pc = new PersonalComputor(new Cpu64(2), new Ram(4), new HardDriver[] { new HardDriver(2000) }, new MonochromeVideoCard());
                var raid = new List<IHardDriver>
                    {
                        new RaidArrays(new List<HardDriver> { new HardDriver(500), new HardDriver(500) })
                    };
                server = new Server(new Cpu128(2), new Ram(8), new HardDriver[] { new HardDriver(1000) }, new MonochromeVideoCard());
                laptop = new Laptop(new Cpu64(2), new Ram(16), new HardDriver[] { new HardDriver(1000) }, new ColorVideoCard(), new LaptopBattery());
            }
            else
            {
                throw new ArgumentException("Invalid manufacturer!");
            }

            var commandLine = Console.ReadLine();
            var isExit = false;
            while (!isExit)
            {
                var commands = commandLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (commands.Length != 2)
                {
                    throw new ArgumentException("Invalid command!");
                }

                var command = commands[0];
                var value = int.Parse(commands[1]);

                if (command == "Charge")
                {
                    laptop.ChargeBattery(value);
                }
                else if (command == "Process")
                {
                    server.Process(value);
                }
                else if (command == "Play")
                {
                    pc.Play(value);
                }
                else
                {
                    Console.WriteLine("Invalid command!");
                }

                commandLine = Console.ReadLine();
                isExit = commandLine == "Exit";
            }
        }
    }
}