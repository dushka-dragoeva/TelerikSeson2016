/*•	 Giant. should be always neutral. When a Giant gathers 
 * such a resource, his AttackPoints are permanently increased by 100. This should only work once.When attacking, 
 * the Giant should pick the first available target, which is not neutral.

*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademyRPG
{

    public class Giant : Character, IWorldObject, IControllable, IGatherer,IFighter
    {
        private const int InitialAttackPoints = 250;
        private const int InitialDefensePoints = 80;
        public const int InitialHitPoints = 200;

        public Giant(string name, Point position, int owner = 0)
            : base(name, position, owner)
        {
            this.HitPoints = InitialHitPoints;
        }

        public int AttackPoints
        {
            get
            {
                return InitialAttackPoints;
            }

            private set
            {

            }
        }

        public int DefensePoints
        {
            get
            {
                return InitialDefensePoints;
            }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            var groupedTargets = availableTargets.GroupBy(t => t.Owner == 0).ToList();

            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Stone)
            {
                //if (this.AttackPoints == InitialAttackPoints)
                //{
                //    this.AttackPoints += 100;
                //}

                return true;
            }

            return false;
        }
    }
}
