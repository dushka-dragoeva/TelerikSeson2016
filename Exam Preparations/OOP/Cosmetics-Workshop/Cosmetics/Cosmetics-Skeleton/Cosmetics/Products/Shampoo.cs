namespace Cosmetics.Products
{
    using System.Text;
    using Common;
    using Contracts;

    public class Shampoo : Product, IProduct, IShampoo
    {
        public Shampoo(string name, string brand, decimal price, GenderType gender, decimal milliliters, UsageType usage) :
            base(name, brand, price, gender)

        {
            this.Milliliters = milliliters;
            this.Usage = usage;
            this.Price *= this.Milliliters;
        }

        public decimal Milliliters { get; private set; }

        public UsageType Usage { get; private set; }

        public override string Print()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.Print());
            sb.AppendFormat("  * Quantity: {0} ml", this.Milliliters);
            sb.AppendLine();
            sb.AppendFormat("  * Usage: {0}", this.Usage);
            return sb.ToString();
        }
    }
}
