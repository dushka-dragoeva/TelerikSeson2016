

/*•	. When attacking, the Knight should always pick the first available target to attack,
which is not neutral and does not belong to the same player as the Knight.
*/


namespace AcademyRPG
{
    using System.Collections.Generic;

    public class Knight : Character, IWorldObject, IControllable, IFighter
    {
        private const int InitialAttackPoints = 100;
        private const int InitialDefensePoints = 100;
        public const int InitialHitPoints = 100;

        public Knight(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.HitPoints = InitialHitPoints;
        }

        public int AttackPoints
        {
            get { return InitialAttackPoints; }
        }

        public int DefensePoints
        {
            get { return InitialDefensePoints; }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != this.Owner &&
                      availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
