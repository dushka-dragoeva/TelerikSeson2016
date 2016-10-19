namespace Computers.Common.Models.Components
{
    public class Cpu64 : Cpu
    {
        private const int MaxValue = 1000;

        public Cpu64(byte numberOfCores)
            : base(numberOfCores)
        {
        }

        public override int GetMaxNumber()
        {
            return MaxValue;
        }
    }
}
