using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarMachines.Machines
{
    using Interfaces;

    public class Fighter : Machine, IMachine, IFighter
    {

        public Fighter(string name, double attackPoints, double defensePoints, bool stealthMode)
            : base(name, attackPoints, defensePoints, 200)
        {
            this.StealthMode = stealthMode;
        }

        public bool StealthMode { get; private set; }

        public void ToggleStealthMode()
        {
            this.StealthMode = !StealthMode;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            var defMode = this.StealthMode ? "ON" : "OFF";
            sb.Append(string.Format(" *Stealth: {0}", defMode));
            return sb.ToString().Trim();
        }
    }
}
