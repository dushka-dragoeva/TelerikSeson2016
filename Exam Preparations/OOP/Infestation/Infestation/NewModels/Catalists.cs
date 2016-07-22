using System;

namespace Infestation
{
    public class Catalists : Supplyment, ISupplement

    {
        private const int CatalistsAggressionEffect = 3;
        private const int CatalistsHealthEffect = 3;
        private const int CatalistsPowerEffect = 3;

        public Catalists()
            : base(CatalistsAggressionEffect, CatalistsHealthEffect, CatalistsPowerEffect)
        {
        }
    }
}
