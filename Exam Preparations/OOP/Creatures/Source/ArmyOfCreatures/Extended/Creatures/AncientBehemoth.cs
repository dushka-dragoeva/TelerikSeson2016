namespace ArmyOfCreatures.Extended.Creatures
{
    using Logic.Creatures;
    using Logic.Specialties;


    public class AncientBehemoth : Creature
    {
        private const int AncientBehemothAttack = 19;
        private const int AncientBehemothDefence = 19;
        private const int AncientBehemothHealtPoints = 300;
        private const decimal AncientBehemothnDamage = 40m;


        public AncientBehemoth() :
            base(AncientBehemothAttack, AncientBehemothDefence, AncientBehemothHealtPoints, AncientBehemothnDamage)
        {
            this.AddSpecialty(new ReduceEnemyDefenseByPercentage(80));
            this.AddSpecialty(new DoubleDefenseWhenDefending(5));
        }
    }
}
