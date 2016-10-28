using Decorator.Abstractions;

namespace Decorator.Decorators
{
    internal class LeatherInteriorDecorator : VehicleDecorator
    {
        public LeatherInteriorDecorator(decimal price, VehicleComponent vehicle)
            : base(price, vehicle)
        {
            this.Vehicle.UpdatePrice(this.Price);
        }
    }
}
