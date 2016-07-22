namespace ArmyOfCreatures.Extended.Creatures
{
    using Logic.Creatures;
    using Specialties;

    public class WolfRaider : Creature
    {
        private const int WolfRaiderAttack = 8;
        private const int WolfRaiderDefence = 5;
        private const int WolfRaiderHealtPoints = 10;
        private const decimal GoblinWolfRaiderDamage = 3.5m;
        private const int Rounds = 7;

        public WolfRaider()
            : base(WolfRaiderAttack, WolfRaiderDefence, WolfRaiderHealtPoints, GoblinWolfRaiderDamage)
        {
            this.AddSpecialty(new DoubleDamage(Rounds));
        }
    }
}
