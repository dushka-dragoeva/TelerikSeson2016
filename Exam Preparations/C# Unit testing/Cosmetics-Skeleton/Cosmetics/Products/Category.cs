

namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Common;
    using Contracts;

   public class Category:ICategory
    {
      private const int MinNameLenght = 2;
      private const int MaxNameLenght = 15;
      

      private string name;
      private readonly ICollection <IProduct> cosmetics;

      public Category(string name)
        {
            this.Name = name;
            this.cosmetics = new List<IProduct>();
        }
        public string Name
        {
            get
            {
                return this.name;
            }


            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format
                    (GlobalErrorMessages.StringCannotBeNullOrEmpty, value));
               Validator.CheckIfStringLengthIsValid(value, MaxNameLenght, MinNameLenght, string.Format
                    (GlobalErrorMessages.InvalidStringLength, "Category name", MinNameLenght, MaxNameLenght));
                this.name = value;
            }
        }

        public ICollection< IProduct >Cosmetics
        {
            get { return new List<IProduct>(this.cosmetics); }

        }

        public void AddCosmetics(IProduct cosmetic)
        {
            Validator.CheckIfNull(cosmetic, string.Format(GlobalErrorMessages.ObjectCannotBeNull,cosmetic.Name));
            
            this.cosmetics.Add(cosmetic);
        }

        public void RemoveCosmetics(IProduct cosmetic)
        {
            
            Validator.CheckIfNull(cosmetic,string.Format
                ("Product {0} does not exist in category {category name}!",cosmetic.Name,this.name));
            this.cosmetics.Remove (cosmetic);
        }

        public string Print()
        {
                var sortedCosmetics = this.cosmetics
               .OrderBy(c => c.Brand)
               .ThenBy(c => c.Price);

                var catalog =new StringBuilder();
                var oneProductIncatalog = this.cosmetics.Count > 0
                    ? string.Format( "{0} products" ,this.cosmetics.Count.ToString())
                    : string.Format("{0} products" ,this.cosmetics.Count.ToString());
            
            catalog.AppendLine(string.Format("{0} category - {1} ", this.Name,oneProductIncatalog ));

                foreach (var cosmetic in sortedCosmetics)
                {
                    catalog.Append(cosmetic.Print());
                }

                return catalog.ToString().Trim();
            }
            
            
        

        
    }
}
