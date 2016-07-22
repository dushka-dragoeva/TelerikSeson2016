using System;

namespace Infestation
{
    public abstract class Supplyment : ISupplement
    {
        public Supplyment(int aggressionEffect, int healthEffect, int powerEffect)
        {
            this.AggressionEffect = aggressionEffect;
            this.HealthEffect = healthEffect;
            this.PowerEffect = powerEffect;
        }

        public int AggressionEffect { get; set; }

        public int HealthEffect { get; set; }

        public int PowerEffect { get; set; }

        // which improve the Health, Power and Aggression of a unit
        public virtual void ReactTo(ISupplement otherSupplement)
        {
        }
    }
}
