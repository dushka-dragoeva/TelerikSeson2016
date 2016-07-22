namespace ArmyOfCreatures.Extended.Creatures
{
    using Logic.Creatures;
    using Logic.Specialties;

    public class Griffin : Creature
    {
        private const int GriffinAttack = 8;
        private const int GriffinDefence = 8;
        private const int GriffinHealtPoints = 25;
        private const decimal GriffinDamage = 4.5m;
        private const int Rounds = 5;
        private const int DefensePoints = 3;

        public Griffin() :
            base(GriffinAttack, GriffinDefence, GriffinHealtPoints, GriffinDamage)
        {
            this.AddSpecialty(new DoubleDefenseWhenDefending(Rounds));
            this.AddSpecialty(new AddDefenseWhenSkip(DefensePoints));
            this.AddSpecialty(new Hate(typeof(WolfRaider)));
        }
    }
}
