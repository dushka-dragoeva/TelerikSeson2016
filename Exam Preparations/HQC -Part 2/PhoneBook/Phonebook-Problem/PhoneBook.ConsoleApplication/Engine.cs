using PhoneBook.ConsoleApplication.Contracts;
using PhoneBook.ConsoleApplication.Models;
using System;
using System.Text;

namespace PhoneBook.ConsoleApplication
{
    public class Engine
    {
        private const string AddEntriesCommand = "AddPhone";
        private const string ChangeEntriesCommand = "ChangePhone";
        private const string ListEntiresCommand = "List";
        private const string End = "End";
        private static IPhonebookRepository data = new PhonebookRepository();
        private static readonly StringBuilder output = new StringBuilder();
        private  Command parsedCommand;
        private  CommandProcessor commandProcessor;

        public Engine(IReader reader/*, IPrinter printer*/)
        {
            this.Reader = reader;
           // this.parsedCommand = Command.Parse();
          //  this.commandProcessor = new CommandProcessor(this.parsedCommand);
            //   this.Printer = printer;
        }

        public IReader Reader { get; private set; }

        //   internal IPrinter Printer { get; private set; }



        public string Run()
        {
            while (true)
            {
                string command = this.Reader.Read();
                if (command == End || command == null)
                {
                    break;
                }

                try
                {
                    this.parsedCommand = Command.Parse(command);
                }
                catch (ArgumentException)
                {
                    output.AppendLine("error!");
                    Environment.Exit(0);
                }

               this.commandProcessor = new CommandProcessor(this.parsedCommand);

                if (this.parsedCommand.Name.StartsWith(AddEntriesCommand) && (this.parsedCommand.Arguments.Length >= 2))
                {
                    Print(commandProcessor.ProceedAddCommand());
                }
                else if ((this.parsedCommand.Name == ChangeEntriesCommand) && (this.parsedCommand.Arguments.Length == 2))
                {
                    Print(commandProcessor.ProceedChangeCommand());
                }
                else if ((this.parsedCommand.Name == ListEntiresCommand) && (this.parsedCommand.Arguments.Length == 2))
                {
                    Print(this.commandProcessor.ProceedListCommand());
                }
                else
                {
                    throw new ArgumentException();
                }
            }

            return output.ToString().Trim();
            // Console.Write(output);
        }

        private void  ProceedSingleCommand(string command)
        {
            if (command == End || command == null)
            {
              //  break; what to do
            }

            try
            {
                this.parsedCommand = Command.Parse(command);
            }
            catch (ArgumentException)
            {
                output.AppendLine("error!");
                Environment.Exit(0);
            }

            this.commandProcessor = new CommandProcessor(this.parsedCommand);

            if (this.parsedCommand.Name.StartsWith(AddEntriesCommand) && (this.parsedCommand.Arguments.Length >= 2))
            {
                Print(commandProcessor.ProceedAddCommand());
            }
            else if ((this.parsedCommand.Name == ChangeEntriesCommand) && (this.parsedCommand.Arguments.Length == 2))
            {
                Print(commandProcessor.ProceedChangeCommand());
            }
            else if ((this.parsedCommand.Name == ListEntiresCommand) && (this.parsedCommand.Arguments.Length == 2))
            {
                Print(this.commandProcessor.ProceedListCommand());
            }
            else
            {
                throw new ArgumentException();
            }
        }
    

        private static void Print(string text)
        {
            output.AppendLine(text);
        }
    }
}
