using System;

using Decorator.Abstractions;

namespace Decorator.Decorators
{
    internal class V8EngineDecorator : VehicleDecorator
    {
        public V8EngineDecorator(decimal price, VehicleComponent vehicle) : 
            base(price, vehicle)
        {
        }

        public void DriveOnTrack()
        {
            Console.WriteLine("Driving around the local racing track");
        }
    }
}
