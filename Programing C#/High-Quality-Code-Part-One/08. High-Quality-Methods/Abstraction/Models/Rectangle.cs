using Abstraction.Contracts;

namespace Abstraction
{
    internal class Rectangle : Figure, IFigure
    {
        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Height { get; private set; }

        public double Width { get; private set; }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
