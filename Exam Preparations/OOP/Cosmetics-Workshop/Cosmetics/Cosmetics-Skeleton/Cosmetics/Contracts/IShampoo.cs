namespace Cosmetics.Contracts
{
    using Common;

    public interface IShampoo : IProduct
    {
        decimal Milliliters { get; }

        UsageType Usage { get; }
    }
}