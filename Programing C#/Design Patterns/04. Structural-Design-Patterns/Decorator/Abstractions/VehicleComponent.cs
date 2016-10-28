namespace Decorator.Abstractions
{
    public abstract class VehicleComponent
    {
        public string Brand { get; set; }

        public decimal Price { get; set; }

        public abstract void DisplayInfo();

        public abstract void UpdatePrice(decimal updateCost);
    }
}
