using System.Text;
using Dealership.Engine;
using Dealership.Common.Enums;

namespace Dealership.CommandHandler
{
    public class ShowUsersCommandHandler : BaseCommandHandler
    {
        private const string HandleableCommandName = "ShowUsers";
        private const string YouAreNotAnAdmin = "You are not an admin!";

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == HandleableCommandName;
        }

        protected override string Handle(ICommand command, IEngine engine)
        {
            if (engine.LoggedUser.Role != Role.Admin)
            {
                return YouAreNotAnAdmin;
            }

            var builder = new StringBuilder();
            builder.AppendLine("--USERS--");
            var counter = 1;
            foreach (var user in engine.Users)
            {
                builder.AppendLine(string.Format("{0}. {1}", counter, user.ToString()));
                counter++;
            }

            return builder.ToString().Trim();
        }
    }
}
