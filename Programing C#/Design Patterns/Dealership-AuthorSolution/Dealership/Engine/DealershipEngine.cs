using Dealership.CommandHandler;
using Dealership.Common;
using Dealership.Common.Enums;
using Dealership.Contracts;
using Dealership.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dealership.Engine
{
    public sealed class DealershipEngine : IEngine
    {
        private const string RegisterUserCommandName = "RegisterUser";
        private const string LoginCommandName = "Login";
        private const string UserNotLogged = "You are not logged! Please login first!";

        private readonly IDealershipFactory factory;
        private readonly IInputOutputProvider ioProvider;
        private readonly ICommandHandler commandHandler;

        private ICollection<IUser> users;
        private IUser loggedUser;

        public DealershipEngine(IDealershipFactory factory, IInputOutputProvider ioProvider, ICommandHandler commandHandler)
        {
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            this.factory = factory;

            if (ioProvider == null)
            {
                throw new ArgumentNullException(nameof(ioProvider));
            }

            this.ioProvider = ioProvider;

            if (commandHandler == null)
            {
                throw new ArgumentNullException(nameof(commandHandler));
            }

            this.commandHandler = commandHandler;

            this.users = new HashSet<IUser>();
            this.loggedUser = null;
        }

        public ICollection<IUser> Users
        {
            get
            {
                return this.users;
            }
        }

        public IUser LoggedUser
        {
            get
            {
                return this.loggedUser;
            }
        }

        public void Start()
        {
            var commands = this.ReadCommands();
            var commandResult = this.ProcessCommands(commands);
            this.PrintReports(commandResult);
        }

        public void Reset()
        {
            this.loggedUser = null;
            this.users = new List<IUser>();
            var commands = new List<ICommand>();
            var commandResult = new List<string>();
            this.PrintReports(commandResult);
        }

        private IList<ICommand> ReadCommands()
        {
            var commands = new List<ICommand>();

            var currentLine = this.ioProvider.ReadLine();

            while (!string.IsNullOrEmpty(currentLine))
            {
                var currentCommand = new Command(currentLine);
                commands.Add(currentCommand);

                currentLine = this.ioProvider.ReadLine();
            }

            return commands;
        }

        private IList<string> ProcessCommands(IList<ICommand> commands)
        {
            var reports = new List<string>();

            foreach (var command in commands)
            {
                try
                {
                    var report = this.ProcessSingleCommand(command);
                    reports.Add(report);
                }
                catch (Exception ex)
                {
                    reports.Add(ex.Message);
                }
            }

            return reports;
        }

        private void PrintReports(IList<string> reports)
        {
            var output = new StringBuilder();

            foreach (var report in reports)
            {
                output.AppendLine(report);
                output.AppendLine(new string('#', 20));
            }

            this.ioProvider.Write(output.ToString());
        }

        private string ProcessSingleCommand(ICommand command)
        {
            if (command.Name != RegisterUserCommandName && command.Name != "Login")
            {
                if (this.LoggedUser == null)
                {
                    return UserNotLogged;
                }
            }

            return this.commandHandler.HandleCommand(command, this);
        }

        private static void ValidateRange(int? value, int min, int max, string message)
        {
            if (value < min || value >= max)
            {
                throw new ArgumentException(message);
            }
        }

        public void SetLoggedUser(IUser user)
        {
            this.loggedUser = user;
        }
    }
}
