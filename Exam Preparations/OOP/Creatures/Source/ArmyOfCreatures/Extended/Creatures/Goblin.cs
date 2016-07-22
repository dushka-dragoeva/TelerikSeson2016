namespace ArmyOfCreatures.Extended.Creatures
{
    using Logic.Creatures;
    public class Goblin : Creature
    {
        private const int GoblinAttack = 4;
        private const int GoblinDefence = 2;
        private const int GoblinHealtPoints = 5;
        private const decimal GoblinDamage = 1.5m;
        
        public Goblin() :
            base(GoblinAttack, GoblinDefence, GoblinHealtPoints, GoblinDamage)
        {
        }
    }
}
