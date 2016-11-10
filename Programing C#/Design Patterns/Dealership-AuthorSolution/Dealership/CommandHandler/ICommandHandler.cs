using Dealership.Engine;

namespace Dealership.CommandHandler
{
    public interface ICommandHandler
    {
        void AddCommandHandler(ICommandHandler nextHandler);

        string HandleCommand(ICommand command, IEngine engine);
    }
}
