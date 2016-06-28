namespace Shapes
{
    using System;

    internal abstract class Shape : ICalculate
    {
        private const string NegativeSideExceptionMessage = "Value must be positive.";
        private double width;
        private double height;

        protected Shape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        protected double Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(NegativeSideExceptionMessage);
                }

                this.width = value;
            }
        }

        protected double Height
        {
            get
            {
                return this.height;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(NegativeSideExceptionMessage);
                }

                this.height = value;
            }
        }

        public abstract double CalculateSurface();
    }
}