namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Common;
    using Contracts;

    public class Toothpaste : Product, IProduct, IToothpaste
    {
        private readonly IList<string> ingredients;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients)
            : base(name, brand, price, gender)
        {
            this.ingredients = ingredients;
        }

        public string Ingredients
        {
            get
            {
                return string.Join(", ", this.ingredients);
            }
        }

        public override string Print()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.Print());
            sb.AppendFormat("  * Ingredients: {0}", this.Ingredients);
            return sb.ToString();
        }

        public void ValidateIIngredients(IList<string> ingredients)
        {
            if (ingredients.Any(x => x.Length < GlobalRangeConstant.MinIngridientLength ||
            x.Length > GlobalRangeConstant.MaxIngridientLength))
            {
                throw new IndexOutOfRangeException(string.Format(
                    GlobalErrorMessages.InvalidStringLength,
                    GlobalRangeConstant.EachIngredient,
                    GlobalRangeConstant.MinIngridientLength,
                    GlobalRangeConstant.MaxIngridientLength));
            }
        }
    }
}