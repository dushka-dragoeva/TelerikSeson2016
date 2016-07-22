namespace Infestation
{
    public class WeaponrySkill : Supplyment, ISupplement
    {


        public WeaponrySkill()
            : base( 0,0,0)
        {
        }

        // TODO
        //public override void ReactTo(ISupplement otherSupplement)
        //{
        //    this.AggressionEffect += otherSupplement.AggressionEffect;
        //    this.HealthEffect += otherSupplement.HealthEffect;
        //    this.PowerEffect += otherSupplement.PowerEffect;
        //}
    }
}
