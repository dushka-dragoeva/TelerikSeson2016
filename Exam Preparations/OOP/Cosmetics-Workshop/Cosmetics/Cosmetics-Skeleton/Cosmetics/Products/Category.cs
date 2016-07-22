namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Common;
    using Contracts;

    public class Category : ICategory
    {
        private string name;

        private IList<IProduct> products;

        public Category(string name)
        {
            this.Name = name;
            this.products = new List<IProduct>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(
                    value,
                  string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, value));

                var exeptionMessage = string.Format(
                    GlobalErrorMessages.InvalidStringLength,
                    GlobalRangeConstant.CategoryName,
                    GlobalRangeConstant.MinBrandCategoryLength,
                    GlobalRangeConstant.MaxCategoryLength);
                Validator.CheckIfStringLengthIsValid(
                    value,
                    GlobalRangeConstant.MaxCategoryLength,
                    GlobalRangeConstant.MinBrandCategoryLength,
                    exeptionMessage);
                this.name = value;
            }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
             Validator.CheckIfNull(
              cosmetics,
              string.Format(GlobalErrorMessages.ObjectCannotBeNull, "Cosmetics to add to category"));
            this.products.Add(cosmetics);
        }

        /// When removing product from category, if the product is not found, the error message should be 
        /// "Product {product name} does not exist in category {category name}!"".
        public void RemoveCosmetics(IProduct cosmetics)
        {
            Validator.CheckIfNull(
               cosmetics,
               string.Format(GlobalErrorMessages.ObjectCannotBeNull, "Cosmetics to remove from category"));
            if (!this.products.Contains(cosmetics))
            {
                throw new ArgumentException(
                    string.Format(
                        GlobalErrorMessages.ProductDoesNotExitInCategory,
                    cosmetics.Name, 
                    this.name));
            }

            this.products.Remove(cosmetics);
        }

        public string Print()
        {
            var sb = new StringBuilder();
            var product = this.products.Count != 1 ? "products" : "product";
            sb.AppendFormat(" {0} category - {1} {2} in total", this.Name, this.products.Count, product);
            sb.AppendLine();

            /// Products in category should be sorted by brand in ascending order and then by 
            /// price in descending order.
            var sortedProducts = this.products
                .OrderBy(p => p.Brand)
                .ThenByDescending(p => p.Price);

                foreach (var item in sortedProducts)
                {
                    sb.AppendLine(item.Print());
                }

            return sb.ToString().Trim();
        }
    }
}
