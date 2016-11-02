using ChainOfResponsibility.Contracts;

namespace ChainOfResponsibility.Models
{
    public abstract class Handler : IHandler
    {
        protected IHandler successor;
        public void SetSuccessor(IHandler successor)
        {
            this.successor = successor;
        }
        public abstract void HandleRequest(int request);
       
    }
}
