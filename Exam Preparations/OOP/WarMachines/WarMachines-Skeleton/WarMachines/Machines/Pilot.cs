namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Interfaces;
    using Common;

    public class Pilot : IPilot
    {
        private string name;
        private ICollection<IMachine> machines; // IList

        public Pilot(string name)
        {
            this.Name = name;
            this.machines = new List<IMachine>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name", "");
                }
                this.name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            if (machine == null)
            {
                throw new ArgumentNullException("Machine ", "No machine");
            }

            this.machines.Add(machine);
        }

        public string Report()
        {

            var sb = new StringBuilder();


            var sortedMachines = this.machines
                       .OrderBy(m => m.HealthPoints)
                       .ThenBy(m => m.Name);

            var noMachinesMAybe =
                machines.Count > 0 ?
                this.machines.Count.ToString() :
                "no";

            var pluralMachinesMayBe =
                this.machines.Count == 1 ?
                "machine" :
                "machines";

            sb.AppendFormat("{0} - {1} {2}", this.Name, noMachinesMAybe, pluralMachinesMayBe);
            sb.AppendLine();
            foreach (var machine in sortedMachines)
            {
                sb.AppendLine(machine.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
