
namespace Cosmetics.Products
{
    using System;
    using System.Text;

    using Common;
    using Contracts;

    public class Shampoo : Products, IShampoo, IProduct
    {

        private readonly UsageType usage;

        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage) :
            base(name, brand, price, gender)
        {
            this.Milliliters = milliliters;
            this.usage = usage;
            this.Price = price * Milliliters;
        }

        public uint Milliliters { get; private set; }

        public UsageType Usage
        {
            get
            {
                return this.usage;
            }
        }
        public override string Print()
        {
            //* Quantity: {product quantity} ml(when applicable)
            // * Usage: EveryDay/Medical (when applicable)  - TODO

            var print = new StringBuilder(base.ToString());

            print.AppendLine(string.Format(" * Quantity: {0} ", this.Milliliters));
            print.AppendLine(string.Format(" * For gender: {0}", this.Gender));
            print.AppendLine(string.Format(" * Usage: {0}", this.Usage));

            return base.Print();
        }
        
    }
}
