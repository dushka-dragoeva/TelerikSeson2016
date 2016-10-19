namespace Computers.Common.Contracts
{
    public interface IHardDriver
    {
        int Capacity { get; }

        void SaveData(int address, string text);

        string LoadData(int address);
    }
}
