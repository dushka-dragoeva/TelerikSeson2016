namespace Infestation
{
    public class Weapon : Supplyment
    {
        private const int WeaopnAggressionEffect = 3;
        private const int WeaopnHealthEffect = 0;
        private const int WeaopnPowerEffect = 10;

        public Weapon()
            : base( WeaopnAggressionEffect, WeaopnHealthEffect, WeaopnPowerEffect)
        {
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is WeaponrySkill)
            {
                this.AggressionEffect += otherSupplement.AggressionEffect;
                this.PowerEffect += otherSupplement.PowerEffect;
            }
        }
    }
}

