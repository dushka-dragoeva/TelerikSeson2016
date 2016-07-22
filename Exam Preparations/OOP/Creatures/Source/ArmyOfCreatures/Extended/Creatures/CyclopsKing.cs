namespace ArmyOfCreatures.Extended.Creatures
{
    using Logic.Creatures;

    using Specialties;

    public class CyclopsKing : Creature
    {

        private const int CyclopsKingAttack = 17;
        private const int CyclopsKingDefence = 13;
        private const int CyclopsKingnHealtPoints = 70;
        private const decimal CyclopsKingDamage = 18m;

        public CyclopsKing()
            : base(CyclopsKingAttack, CyclopsKingDefence, CyclopsKingnHealtPoints, CyclopsKingDamage)
        {
            this.AddSpecialty(new AddAttackWhenSkip(3)); // ?
            this.AddSpecialty(new DoubleAttackWhenAttacking(4));
            this.AddSpecialty(new DoubleDamage(1));
        }
    }
}
