namespace MobileDevice
{
    using System;
    using System.Text;

    public class Display
    {
        private double? size;
        private int? numberOfColors;

        public Display()
        {
            this.Size = null;
            this.NumberOfColors = null;
        }

        public Display(double? size)
            : this()
        {
            this.Size = size;
        }

        public Display(double? size, int? numberOfColors)
           : this(size)
        {
            this.NumberOfColors = numberOfColors;
        }

        public double? Size
        {
            get
            {
                return this.size;
            }

            set
            {
                if (this.size <= 0)
                {
                    throw new ArgumentException(string.Format("Size {0}", GlobalConstants.NegativeNumber));
                }
                else
                {
                    this.size = value;
                }
            }
        }

        public int? NumberOfColors
        {
            get
            {
                return this.numberOfColors;
            }

            set
            {
                if (this.numberOfColors <= 0)
                {
                    throw new ArgumentException(string.Format("Number of colors {0}", GlobalConstants.NegativeNumber));
                }
                else
                {
                    this.numberOfColors = value;
                }
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.Append("Size - ");

            if (this.Size == null)
            {
                output.Append(GlobalConstants.NoInformation);
            }
            else
            {
                output.Append($"{this.Size}; ");
            }

            output.Append("Colors - ");
            if (this.NumberOfColors == null)
            {
                output.Append(GlobalConstants.NoInformation);
            }
            else
            {
                output.Append($"{this.NumberOfColors}");
            }

            return output.ToString();
        }
    }
}
