namespace Computers.Common.Contracts
{
    public interface ILaptopBattery
    {
        int Percentage { get; }

       void Charge(int percentage);
    }
}
