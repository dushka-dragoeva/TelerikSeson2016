using Computers.Common.Contracts;

namespace Computers.Common.Models.Components
{
    public class Ram : MotherboardComponent, IRam
    {
        private int value;

        public Ram(int maxAmaount)
        {
            this.MaxAmount = maxAmaount;
        }

        public int MaxAmount { get; private set; }

        public void SaveValue(int newValue)
        {
            this.value = newValue;
        }

        public int LoadValue()
        {
            return this.value;
        }
    }
}