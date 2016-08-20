using System;
using System.Collections.Generic;

namespace Poker
{
    using Enumerable = System.Linq.Enumerable;

    public class Hand : IHand
    {
        public IList<ICard> Cards { get; private set; }

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public override string ToString()
        {
            return string.Join(", ", this.Cards);
        }
    }
}