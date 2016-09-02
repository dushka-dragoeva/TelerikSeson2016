/*Task 2. Refactor the following if statements

Potato potato;
//... 
if (potato != null)
   if(!potato.HasNotBeenPeeled && !potato.IsRotten)
    Cook(potato);*/
using System;
using ControlFlowConditionalStatementsLoops.Cooking;
using ControlFlowConditionalStatementsLoops.Cooking.Vegitables;

namespace ControlFlowConditionalStatementsLoops.Task2
{
    public class VegetableCooker
    {
        public static void CookVegitable(Vegetable vegitable, Chef chef)
        {
            Potato potato = new Potato();

            bool isCookable = IsCookable(potato);

            if (isCookable)
            {
                chef.Cook(potato);
            }
            else
            {
                throw new ArgumentException("The vegitable should be peeled and shouldn't be rotten!");
            }
        }

        private static bool IsCookable(Vegetable vegitable)
        {
            bool canBeCooked = vegitable != null && 
                !vegitable.IsRotten && 
                vegitable.IsPeeled;

            return canBeCooked;
        }
    }
}
