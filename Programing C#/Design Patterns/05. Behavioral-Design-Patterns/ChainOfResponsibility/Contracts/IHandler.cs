namespace ChainOfResponsibility.Contracts
{
    public interface IHandler
    {
        void SetSuccessor(IHandler successor);

        void HandleRequest(int request);
    }
}
