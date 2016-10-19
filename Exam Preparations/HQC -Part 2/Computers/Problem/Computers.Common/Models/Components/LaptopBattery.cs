using Computers.Common.Contracts;

namespace Computers.Common.Models.Components
{
    public class LaptopBattery : ILaptopBattery
    {
        public const int MinPersentage = 0;
        public const int MaxPersentage = 100;
        public const int InitialPersentage = 50;

        public LaptopBattery()
        {
            this.Percentage = InitialPersentage;
        }

        public int Percentage { get; set; }

        public void Charge(int percentage)
        {
            this.Percentage += percentage;

            if (this.Percentage > MaxPersentage)
            {
                this.Percentage = MaxPersentage;
            }

            if (this.Percentage < MinPersentage)
            {
                this.Percentage = MinPersentage;
            }
        }
    }
}