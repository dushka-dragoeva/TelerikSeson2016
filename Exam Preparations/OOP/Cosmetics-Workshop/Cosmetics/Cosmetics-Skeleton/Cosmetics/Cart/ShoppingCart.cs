namespace Cosmetics.Cart
{
    using System.Collections.Generic;
    using System.Linq;

    using Common;
    using Contracts;

    public class ShoppingCart : IShoppingCart
    {
        private ICollection<IProduct> productList;

        public ShoppingCart()
        {
            this.productList = new List<IProduct>();
        }

        public ICollection<IProduct> ProductList
        {
            get { return this.productList; }
            set { productList = value; }
        }

        public void AddProduct(IProduct product)
        {
            Validator.CheckIfNull(product, string.Format(GlobalErrorMessages.ObjectCannotBeNull, "Product to add to cart"));
            this.productList.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            Validator.CheckIfNull(product, string.Format(GlobalErrorMessages.ObjectCannotBeNull, "roduct to remove from cart"));
            this.productList.Remove(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            
            return this.productList.Contains(product);
        }

        public decimal TotalPrice()
        {
            var totalPrice = this.productList.Sum(p => p.Price);

            return totalPrice;
        }
    }
}
