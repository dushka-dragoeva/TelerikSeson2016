using System;
using Decorator.Abstractions;

namespace Decorator.Models
{
    public class BaseCar : VehicleComponent
    {
        public BaseCar(string brand, decimal price)
        {
            this.Brand = brand;
            this.Price = price;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"{this.GetType().Name}");
            Console.WriteLine($"Brand: {this.Brand}");
            Console.WriteLine($"Price: {this.Price}");
        }

        public override void UpdatePrice(decimal updateCost)
        {
            this.Price += updateCost;
        }
    }
}
