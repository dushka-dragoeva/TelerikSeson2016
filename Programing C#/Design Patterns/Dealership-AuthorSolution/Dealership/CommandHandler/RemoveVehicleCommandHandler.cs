using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dealership.Engine;

namespace Dealership.CommandHandler
{
    public class RemoveVehicleCommandHandler : BaseCommandHandler
    {
        private const string HandleableCommandName = "RemoveVehicle";
        private const string RemovedVehicleDoesNotExist = "Cannot remove comment! The vehicle does not exist!";
        private const string VehicleRemovedSuccessfully = "{0} removed vehicle successfully!";

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == HandleableCommandName;
        }

        protected override string Handle(ICommand command, IEngine engine)
        {
            var vehicleIndex = int.Parse(command.Parameters[0]) - 1;

            this.ValidateRange(vehicleIndex, 0, engine.LoggedUser.Vehicles.Count, RemovedVehicleDoesNotExist);

            var vehicle = engine.LoggedUser.Vehicles[vehicleIndex];

            engine.LoggedUser.RemoveVehicle(vehicle);

            return string.Format(VehicleRemovedSuccessfully, engine.LoggedUser.Username);
        }
    }
}