namespace Infestation
{
    public class InfestationSpores : Supplyment, ISupplement
    {

        private const int InfestationSporesAggressionEffect = 20;
        private const int InfestationSporesHealthEffect = 0;
        private const int InfestationSporesPowerEffect = -1;

        public InfestationSpores()
            : base(InfestationSporesAggressionEffect, InfestationSporesHealthEffect, InfestationSporesPowerEffect)
        {
        }
        // TODO
        public override void ReactTo(ISupplement otherSupplement)
        {
            this.AggressionEffect += 0;
            this.PowerEffect += 0;
        }
    }
}
