using System;
using Dealership.Engine;

namespace Dealership.CommandHandler
{
    public abstract class BaseCommandHandler : ICommandHandler
    {
        private const string InvalidCommand = "Invalid command {0}!";

        private ICommandHandler nextHandler;

        public void AddCommandHandler(ICommandHandler nextHandler)
        {
            this.nextHandler = nextHandler;
        }

        public string HandleCommand(ICommand command, IEngine engine)
        {
            string result;
            if (this.CanHandle(command))
            {
                result = this.Handle(command, engine);
            }
            else if (this.nextHandler != null)
            {
                result = this.nextHandler.HandleCommand(command, engine);
            }
            else
            {
                result = string.Format(InvalidCommand, command.Name);
            }

            return result;
        }

        protected void ValidateRange(int? value, int min, int max, string message)
        {
            if (value < min || value > max)
            {
                throw new ArgumentException(message);
            }
        }

        protected abstract bool CanHandle(ICommand command);

        protected abstract string Handle(ICommand command, IEngine engine);
    }
}
