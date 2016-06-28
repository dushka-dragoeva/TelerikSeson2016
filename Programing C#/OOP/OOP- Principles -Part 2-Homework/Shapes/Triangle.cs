namespace Shapes
{
    internal class Triangle : Shape, ICalculate
    {
        internal Triangle(double width, double height)
            : base(width, height)
        {
        }

        public override double CalculateSurface()
        {
            return (this.Width * this.Height) / 2;
        }
    }
}
