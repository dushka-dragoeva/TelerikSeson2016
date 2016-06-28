namespace Shapes
{
    internal class Square : Rectangle, ICalculate
    {
        internal Square(double width)
    : base(width, width)
        {
        }
    }
}