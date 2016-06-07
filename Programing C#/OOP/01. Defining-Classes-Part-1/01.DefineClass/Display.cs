namespace MobileDevice
{
    using System.Text;

    public class Display
    {
        private double? size;
        private int? numberOfColors;

        public Display()
        {
            this.size = null;
            this.numberOfColors = null;
        }

        public Display(double size, int numberOfColors)
            :this()
        {
            this.size = size;
            this.numberOfColors = numberOfColors;
        }

        public double? Size
        {
            get
            {
                return this.size;
            }

            set
            {
                this.size = value;
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
                this.numberOfColors = value;
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
                output.Append($"{this.Size}\"");
            }

            output.Append("Colors -");
            if (this.numberOfColors == null)
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
