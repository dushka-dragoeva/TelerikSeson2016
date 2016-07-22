using System;

namespace AcademyRPG
{
    public class Rock : StaticObject, IWorldObject, IResource
    {
        protected int Size { get; private set; }

        public Rock(int size, Point position)
            : base(position)
        {
            this.Size = size;
            this.HitPoints = size;
        }

        public int Quantity
        {
            get
            {
                return this.HitPoints / 2;
            }
        }

        public ResourceType Type
        {
            get
            {
                return ResourceType.Stone;
            }
        }
    }
}
