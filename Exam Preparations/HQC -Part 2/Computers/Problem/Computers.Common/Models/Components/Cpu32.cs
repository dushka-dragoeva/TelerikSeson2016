namespace Computers.Common.Models.Components
{
    public class Cpu32 : Cpu
    {
        private const int MaxValue = 500;

        public Cpu32(byte numberOfCores)
            : base(numberOfCores)
        {
        }

        public override int GetMaxNumber()
        {
            return MaxValue;
        }
    }
}