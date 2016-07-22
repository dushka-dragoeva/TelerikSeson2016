namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Common;
    using Interfaces;

    public abstract class Machine : IMachine
    {
        private string name;// = null;
        private IPilot pilot;// = null;
        private IList<string> targets;

        protected Machine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
            this.targets = new List<string>();
        }


        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new  NullReferenceException("Name");
                }

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Pilot");
                }

                this.pilot = value;
            }
        }

        // Ako neshto ne trebva da validirame si slagame avtomatichni properties

        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets
        {
            get
            {
                return new List<string>(this.targets);
            }
        }


        public void Attack(string target)
        {
          //  if (this.Pilot != null)
          //  {
              //  this.DefensePoints = 100;  // why?????
                this.Targets.Add(target);
           // }
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendFormat("- {0}\n", this.Name);
            output.AppendFormat(" *Type: {0}\n", this.GetType().Name);
            output.AppendFormat(" *Health: {0}\n", this.HealthPoints);
            output.AppendFormat(" *Attack: {0}\n", this.AttackPoints);
            output.AppendFormat(" *Defense: {0}\n", this.DefensePoints);
            output.AppendFormat(" *Targets: {0}\n", this.Targets.Count > 0 
                ? string.Join(", ", this.targets) : "None");

            return output.ToString().Trim();
        }
    }
}
