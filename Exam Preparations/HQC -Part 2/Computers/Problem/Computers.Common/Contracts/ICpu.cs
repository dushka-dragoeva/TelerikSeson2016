using Computers.Common.Models.Components;

namespace Computers.Common.Contracts
{
    public interface ICpu : IMotherboardComponent
    {
        byte NumberOfCores { get; }

        void SquareNumber();

        void GenerateRandomNumber(int min, int max);
    }
}
