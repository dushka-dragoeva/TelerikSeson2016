namespace Cosmetics.Products
{
    using System.Text;

    using Common;
    using Contracts;

    public abstract class Product : IProduct
    {
        private string name;
        private string brand;

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
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
                    GlobalRangeConstant.ProductName,
                    GlobalRangeConstant.MinProductNameLength,
                GlobalRangeConstant.MaxProductNameBrandLength);
                Validator.CheckIfStringLengthIsValid(
                    value,
                    GlobalRangeConstant.MaxProductNameBrandLength,
                    GlobalRangeConstant.MinProductNameLength,
                    exeptionMessage);
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
                Validator.CheckIfStringIsNullOrEmpty(
                    value,
                  string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, value));
                var exeptionMessage = string.Format(
                    GlobalErrorMessages.InvalidStringLength,
                    GlobalRangeConstant.ProductBrand,
                    GlobalRangeConstant.MinBrandCategoryLength,
                    GlobalRangeConstant.MaxProductNameBrandLength);
                Validator.CheckIfStringLengthIsValid(
                    value,
                    GlobalRangeConstant.MaxProductNameBrandLength,
                    GlobalRangeConstant.MinBrandCategoryLength,
                    exeptionMessage);
                this.brand = value;
            }
        }

        public GenderType Gender { get; private set; }

        public decimal Price { get; protected set; }

        public virtual string Print()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("- {0} - {1}:", this.Brand, this.Name);
            sb.AppendLine();
            sb.AppendFormat("  * Price: ${0}", this.Price);
            sb.AppendLine();
            sb.AppendFormat("  * For gender: {0}", this.Gender);
            return sb.ToString();
        }
    }
}
