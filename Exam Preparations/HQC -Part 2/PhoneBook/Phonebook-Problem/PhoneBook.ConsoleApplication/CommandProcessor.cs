using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PhoneBook.ConsoleApplication.Contracts;

namespace PhoneBook.ConsoleApplication.Models
{
    internal class CommandProcessor
    {
        private const string CountryCode = "+359";
        private static IPhonebookRepository data = new PhonebookRepository();
        private static StringBuilder commandResult = new StringBuilder();

        public CommandProcessor(Command command)
        {
            this.Command = command;
        }

        public Command Command { get; private set; }

        public string AddMessage { get; private set; }

        public string ChangeMessage { get; private set; }

        public string ProceedAddCommand()
        {
            string entryName = this.Command.Arguments[0];
            string message = string.Empty;
            var entryPhones = this.Command.Arguments.Skip(1).ToList();
            bool isNewName = false;

            for (int i = 0; i < entryPhones.Count; i++)
            {
                entryPhones[i] = ConvertToValidPhoneNumber(entryPhones[i]);
            }

            try
            {
                isNewName = data.AddPhone(entryName, entryPhones);
            }
            catch (ArgumentException)
            {
                message = "Duplicated name in the phonebook found: " + entryName;
            }

            if (isNewName)
            {
                message = "Phone entry created";
            }
            else
            {
                message = "Phone entry merged";
            }

            return message;
        }

        public string ProceedChangeCommand()
        {
            var message = string.Empty;
            var count = data.ChangePhone(
                    ConvertToValidPhoneNumber(this.Command.Arguments[0]),
                    ConvertToValidPhoneNumber(this.Command.Arguments[1]));
            message = count + " numbers changed";

            return message;
        }

        public string ProceedListCommand()
        {
            var output = new StringBuilder();
            try
            {
                IEnumerable<IEntry> entries = data.ListEntries(
                    int.Parse(this.Command.Arguments[0]),
                    int.Parse(this.Command.Arguments[1]));

                foreach (var entry in entries)
                {
                    output.AppendLine(entry.ToString());
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                output.AppendLine("Invalid range");
            }

            return output.ToString().Trim();
        }

        private static string ConvertToValidPhoneNumber(string number)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char ch in number)
            {
                if (char.IsDigit(ch) || (ch == '+'))
                {
                    sb.Append(ch);
                }
            }

            if (sb.Length >= 2 && sb[0] == '0' && sb[1] == '0')
            {
                sb.Remove(0, 1);
                sb[0] = '+';
            }

            while (sb.Length > 0 && sb[0] == '0')
            {
                sb.Remove(0, 1);
            }

            if (sb.Length > 0 && sb[0] != '+')
            {
                sb.Insert(0, CountryCode);
            }

            return sb.ToString();
        }

    }
}
