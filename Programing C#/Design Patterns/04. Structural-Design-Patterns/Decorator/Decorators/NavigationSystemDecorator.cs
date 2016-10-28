using Decorator.Abstractions;

namespace Decorator.Decorators
{
    internal class NavigationSystemDecorator : VehicleDecorator
    {
        public NavigationSystemDecorator(decimal price, VehicleComponent vehicle) :
            base(price, vehicle)
        {
        }
    }
}
