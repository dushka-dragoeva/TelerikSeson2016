using ControlFlowConditionalStatementsLoops.Cooking.Contracts;

namespace ControlFlowConditionalStatementsLoops.Cooking
{
    public class Chef
    {
        private readonly VegetableFactory vegetableFactory;
        private readonly DishFactory dishFactory;

        public Chef()
        {
            this.vegetableFactory = new VegetableFactory();
            this.dishFactory = new DishFactory();
        }

        public void CookVegetableSoup()
        {
            var potato = this.vegetableFactory.GetPotato();
            this.Cook(potato);

            var carrot = this.vegetableFactory.GetCarrot();
            this.Cook(carrot);
        }

        public void Cook(IVegetable vegetable)
        {
            this.Peel(vegetable);
            this.Cut(vegetable);
            var bowl = this.dishFactory.GetBowl();
            bowl.Add(vegetable);
        }

        private void Peel(IVegetable vegetable)
        {
            vegetable.IsPeeled = true;
        }

        private void Cut(IVegetable vegetable)
        {
            vegetable.IsCutted = true;
        }
    }
}