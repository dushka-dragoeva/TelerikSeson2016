using System.Linq;
using Dealership.Engine;

namespace Dealership.CommandHandler
{
    public class RemoveCommentCommandHandler : BaseCommandHandler
    {
        private const string HandleableCommandName = "RemoveComment";
        private const string NoSuchUser = "There is no user with username {0}!";
        private const string RemovedVehicleDoesNotExist = "Cannot remove comment! The vehicle does not exist!";
        private const string CommentRemovedSuccessfully = "{0} removed comment successfully!";
        private const string RemovedCommentDoesNotExist = "Cannot remove comment! The comment does not exist!";

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == HandleableCommandName;
        }

        protected override string Handle(ICommand command, IEngine engine)
        {
            var vehicleIndex = int.Parse(command.Parameters[0]) - 1;
            var commentIndex = int.Parse(command.Parameters[1]) - 1;
            var username = command.Parameters[2];

            var user = engine.Users.FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                return string.Format(NoSuchUser, username);
            }

            this.ValidateRange(vehicleIndex, 0, user.Vehicles.Count, RemovedVehicleDoesNotExist);
            this.ValidateRange(commentIndex, 0, user.Vehicles[vehicleIndex].Comments.Count, RemovedCommentDoesNotExist);

            var vehicle = user.Vehicles[vehicleIndex];
            var comment = user.Vehicles[vehicleIndex].Comments[commentIndex];

            engine.LoggedUser.RemoveComment(comment, vehicle);

            return string.Format(CommentRemovedSuccessfully, engine.LoggedUser.Username);
        }
    }
}
