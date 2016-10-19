namespace Computers.Common.Contracts
{
    public interface IRam : IMotherboardComponent
    {
        int MaxAmount { get; }

        void SaveValue(int newValue);

        int LoadValue();
    }
}
