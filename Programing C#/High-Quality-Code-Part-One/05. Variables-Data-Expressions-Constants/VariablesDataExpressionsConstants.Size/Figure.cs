using System;

namespace VariablesDataExpressionsConstants.Rectangle
{
    public class Figure
    {
        public Figure(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width { get; set; }

        public double Height { get; set; }

        public static Figure GetRotatedfigure(Figure figure, double angleOfRotation)
        {
            var cosinus = Math.Abs(Math.Cos(angleOfRotation));
            var sinus = Math.Abs(Math.Sin(angleOfRotation));
            var rotatedWidth = (cosinus * figure.Width) + (sinus * figure.Height);
            var rotatedHeight = (sinus * figure.Width) + (cosinus * figure.Height);

            var rotatedFigure = new Figure(rotatedWidth, rotatedHeight);

            return rotatedFigure;
        }
    }
}
