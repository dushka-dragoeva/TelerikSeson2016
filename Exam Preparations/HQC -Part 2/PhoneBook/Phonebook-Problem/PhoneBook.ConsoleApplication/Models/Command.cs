using System;

namespace PhoneBook.ConsoleApplication.Models
{
    public class Command
    {
        public Command(string name, string[] arguments)
        {
            this.Name = name;
            this.Arguments = arguments;
        }

        public string Name { get; set; }
        public string[] Arguments { get; set; }

        public static Command Parse(string command)
        {
            int endNameIndex = command.IndexOf('(');
            if (endNameIndex == -1)
            {
                throw new ArgumentException();
            }

            string commandName = command.Substring(0, endNameIndex);
            var startParamsIndex = endNameIndex + 1;
            var paramsLength = command.Length - endNameIndex - 2;
            string paramsAsString = command.Substring(startParamsIndex, paramsLength);
            string[] splitedParams = paramsAsString.Split(',');

            for (int j = 0; j < splitedParams.Length; j++)
            {
                splitedParams[j] = splitedParams[j].Trim();
            }

            return new Command(commandName, splitedParams);
        }
    }
}
