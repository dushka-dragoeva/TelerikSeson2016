using ControlFlowConditionalStatementsLoops.Cooking.Vegitables;

namespace ControlFlowConditionalStatementsLoops.Cooking
{
    internal class VegetableFactory
    {
        public Carrot GetCarrot()
        {
            return new Carrot();
        }

        public Potato GetPotato()
        {
            return new Potato();
        }
    }
}
