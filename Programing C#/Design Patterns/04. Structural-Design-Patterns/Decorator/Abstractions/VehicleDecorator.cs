using Decorator.Utilities;
using System;

namespace Decorator.Abstractions
{
    internal abstract class VehicleDecorator : VehicleComponent
    {
        public VehicleDecorator(decimal price, VehicleComponent vehicle)
        {
            this.Price = price;
            this.Vehicle = vehicle;
            this.Vehicle.UpdatePrice(this.Price);
        }

        public VehicleComponent Vehicle { get; private set; }

        public override void DisplayInfo()
        {
            this.Vehicle.DisplayInfo();
            var name = this.GetType().Name;
            var lastIndex = name.IndexOf("Decorator");
            var addedExtra = StringUtilities.SplitCamelCase(name.Substring(0, lastIndex));
            Console.WriteLine($"{string.Join(" ", addedExtra)}");
        }

        public override void UpdatePrice(decimal updateCost)
        {
            this.Vehicle.UpdatePrice(updateCost);
        }
    }
}
