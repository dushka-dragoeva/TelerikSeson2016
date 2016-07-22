using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademyRPG
{
    public class Ninja : Character, IFighter, IWorldObject, IControllable, IGatherer
    {
        private const int InitialAttackPoints = 0;
        private const int InitialDefensePoints = int.MaxValue;
        public const int InitialHitPoints = 1;



        public Ninja(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.HitPoints = InitialHitPoints;
            //this.DefensePoints = int.MaxValue;
        }

        public int AttackPoints { get { return InitialHitPoints; } private set { } }

        public int DefensePoints
        {
            get
            {
                return InitialDefensePoints;
            }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            var sortedTargets = availableTargets.OrderByDescending(t => t.HitPoints).ToList();

            for (int i = 0; i < sortedTargets.Count; i++)

            {
                if (sortedTargets[i].Owner != this.Owner && sortedTargets[i].Owner != 0)
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
                this.AttackPoints += resource.Quantity * 2;
                return true;
            }
            else if (resource.Type == ResourceType.Lumber)
            {
                this.AttackPoints += resource.Quantity;
                return true;
            }

            return false;
        }
    }
}
