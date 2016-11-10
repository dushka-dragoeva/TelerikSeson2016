using Dealership.Engine;

namespace Dealership.CommandHandler
{
    public class LogoutUserCommandHandler : BaseCommandHandler
    {
        private const string HandleableCommandName = "Logout";
        private const string UserLoggedOut = "You logged out!";

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == HandleableCommandName;
        }

        protected override string Handle(ICommand command, IEngine engine)
        {
            engine.SetLoggedUser(null);
            return UserLoggedOut;
        }
    }
}
