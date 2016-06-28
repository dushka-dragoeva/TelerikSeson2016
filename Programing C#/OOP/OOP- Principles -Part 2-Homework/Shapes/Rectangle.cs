namespace Shapes
{
    internal class Rectangle : Shape, ICalculate
    {
        internal Rectangle(double width, double height)
            : base(width, height)
        {
        }

        public override double CalculateSurface()
        {
            return this.Width * this.Height;
        }
    }
}
