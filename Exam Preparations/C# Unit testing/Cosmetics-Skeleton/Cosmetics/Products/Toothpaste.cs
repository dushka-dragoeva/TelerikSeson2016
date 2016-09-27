
namespace Cosmetics.Products
{
    using System.Text;
    using System.Collections.Generic;
    
    using Common;
    using Contracts;

   public  class Toothpaste:Products,IToothpaste,IProduct
    {
       private IEnumerable<string> ingredients;

       public Toothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients)
           :base(name,brand,price,gender)
       {
           this.ingredients = new List<string>();
       }


       public string Ingredients
       {
           get { return string .Join(", ", new List<string>(this.ingredients)) ; }
          
       }

       public override string Print()
       {
           var print = new StringBuilder(base.ToString());
           print.Insert(0,$" * Ingredients: " );
          // print.AppendLine(  string.Join(", ", new List<string>(this.ingredients)));

           return print.ToString() ;
       }
    }
}
