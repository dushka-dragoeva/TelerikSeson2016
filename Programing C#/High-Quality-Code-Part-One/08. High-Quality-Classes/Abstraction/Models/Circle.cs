using System;
using Abstraction.Common;
using Abstraction.Contracts;

namespace Abstraction.Models
{
    internal class Circle : Figure, IFigure
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                Validator.CheckIfPositiveDouble(value, $"{nameof(this.Radius)} {GlobalErrorMessage.ShouldBePositiveDouble}");
                Validator.CheckIfValidRadius(value, $" {typeof(Circle)} {GlobalErrorMessage.OverflowDouble}");
                this.radius = value;
            }
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}
