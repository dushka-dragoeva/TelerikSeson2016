namespace Cosmetics.Products
{
    using System;
   // using System.Collections.Generic;
    //using System.Linq;
    using System.Text;
    
    using Common;
    using Contracts;

  public abstract  class Products:IProduct
    {
      private const int MinNameLenght = 3;
      private const int MaxNameLenght = 10;
      private const int MinBrandLenght = 2;
      private const int MaxBrandLenght = 10;


      private readonly GenderType gender;
      private string name;
      private string brand;
    //  private decimal price;
      
      public Products(string name, string brand, decimal price, GenderType gender)
      {
          this.Name = name;
          this.Brand = brand;
          this.Price = price;
          this.gender = gender;


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
                  (GlobalErrorMessages.StringCannotBeNullOrEmpty, "Product name "));
              Validator.CheckIfStringLengthIsValid(value, MaxNameLenght, MinNameLenght, string.Format
                 (GlobalErrorMessages.InvalidStringLength, "Product name ", MinNameLenght, MaxNameLenght));
              this.name = value;
          }
      }

      public string Brand
      {
          get
          {
              return this.brand;
          }
          private set
          {
              Validator.CheckIfStringIsNullOrEmpty(value, string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, value));
             Validator.CheckIfStringLengthIsValid(value, MaxBrandLenght, MinBrandLenght, string.Format(GlobalErrorMessages.InvalidStringLength, "Product brand ", MinBrandLenght, MaxBrandLenght));
              this.brand = value;
          }
      }

      public decimal Price { get;  set; }
      
      public GenderType Gender
      {
          get 
          { 
              return this.gender;
          }
      }

      public virtual string Print()
      {
    
          var print = new StringBuilder();
          print.AppendLine(string.Format("- {0} - {1}:", this.Brand, this.Name));
          print.AppendLine(string.Format(" * Price: ${0}",this.Price));
          print.AppendLine(string.Format(" * For gender: {0}", this.GetGenderType(gender))); 
          
         return print.ToString();
      }

      public string GetGenderType(GenderType gender)
      {
         return  this.gender.ToString();
      }
    }
}
