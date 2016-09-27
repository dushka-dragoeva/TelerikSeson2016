using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Products
{
    using Contracts;
    using Common;


  public  class ShoppingCart: IShoppingCart
    {

      private readonly ICollection<IProduct> myShopingCart;
      
      public ShoppingCart()
      {
          this.myShopingCart=new List<IProduct>();
      }

      public List<IProduct> MyShoppingCart
      {
          get { return new List<IProduct>(this.myShopingCart); }
      }
      
        public void AddProduct(IProduct product)
        {
            this.myShopingCart.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            this.MyShoppingCart.Remove(product);
        }

        public bool ContainsProduct(IProduct product)
        {

            if (product != null)

                return true;
            else
                return false;
        }

        public decimal TotalPrice()
        {
            decimal totalPrice=1;
            foreach (var product in myShopingCart)
            {
                 totalPrice +=product.Price;
                
            }
            return totalPrice;
        }

        
    }
}
