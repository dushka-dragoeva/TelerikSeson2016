using System;

using Decorator.Decorators;
using Decorator.Models;

namespace Decorator
{
    public class Client
    {
        public static void Main(string[] args)
        {
            /// Creating a car
            var basicCar = new BaseCar("BMW", 85000);
            basicCar.DisplayInfo();
            LineSeparator();

            /// Adding one option
            var upgradedCar = new LeatherInteriorDecorator(1300m, basicCar);
            Console.WriteLine("Upgraded Car Includes:");
            upgradedCar.DisplayInfo();
            LineSeparator();

            /// Adding all options
            var superCar = new V8EngineDecorator(3500m, new NavigationSystemDecorator(300m, upgradedCar));
            Console.WriteLine("Super Car Includes:");
            superCar.DisplayInfo();
            superCar.DriveOnTrack();
            LineSeparator();
        }

        private static void LineSeparator()
        {
            Console.WriteLine(new string('-', 50));
        }
    }
}
