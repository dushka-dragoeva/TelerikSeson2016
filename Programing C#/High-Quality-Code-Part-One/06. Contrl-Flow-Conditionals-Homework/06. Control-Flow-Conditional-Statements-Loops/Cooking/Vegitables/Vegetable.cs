using ControlFlowConditionalStatementsLoops.Cooking.Contracts;

namespace ControlFlowConditionalStatementsLoops.Cooking.Vegitables
{
    public abstract class Vegetable : IVegetable
    {
        public Vegetable()
        {
            this.IsRotten = false;
            this.IsPeeled = false;
            this.IsCutted = false;
        }

        public bool IsRotten { get; set; }

        public bool IsPeeled { get; set; }

        public bool IsCutted { get; set; }
    }
}