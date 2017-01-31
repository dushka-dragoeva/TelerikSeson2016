using System;

namespace OnlineMarket.Solution
{
    public class Product : IComparable<Product>
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public double Price { get; set; }

        public override string ToString()
        {
            return string.Format("{0}({1})", this.Name, this.Price);
        }

        public override bool Equals(object obj)
        {
            var other = obj as Product;
            if (other == null)
            {
                return false;
            }

            return this.Name.Equals(other.Name);
        }

        public override int GetHashCode()
        {
            return 23 + this.Name.GetHashCode() >> 17 ^
                   (23 + this.Price.GetHashCode() >> 17 ^
                    (23 + this.Type.GetHashCode() >> 17));
        }

        public int CompareTo(Product other)
        {
            var priceCompareResult = this.Price.CompareTo(other.Price);
            if (priceCompareResult == 0)
            {
                var namesCompareResult = this.Name.CompareTo(other.Name);
                if (namesCompareResult == 0)
                {
                    return this.Type.CompareTo(other.Type);
                }
                else
                {
                    return namesCompareResult;
                }
            }
            else
            {
                return priceCompareResult;
            }
        }

        public static Product ParseProduct(string productString)
        {
            string[] parts = productString.Split(' ');
            var name = parts[0];
            var price = double.Parse(parts[1]);
            var type = parts[2];
            return new Product()
            {
                Name = name,
                Price = price,
                Type = type
            };
        }
    }
}