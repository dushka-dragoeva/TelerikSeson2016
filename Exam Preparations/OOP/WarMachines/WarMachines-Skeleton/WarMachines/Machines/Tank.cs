namespace WarMachines.Machines
{
    using System.Text;
    using Interfaces;

    public class Tank : Machine, IMachine, ITank
    {
        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, 100)
        {
            this.ToggleDefenseMode();
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            this.DefenseMode = !this.DefenseMode;

            if (DefenseMode)
            {
                this.DefensePoints += 30.0;
                this.AttackPoints -= 40.0;
            }
            else
            {
                this.DefensePoints -= 30.0;
                this.AttackPoints += 40.0;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            var defMode = this.DefenseMode ? "ON" : "OFF";
            sb.Append(string.Format(" *Defense: {0}", defMode));
            return sb.ToString().Trim(); ;
        }
    }
}
