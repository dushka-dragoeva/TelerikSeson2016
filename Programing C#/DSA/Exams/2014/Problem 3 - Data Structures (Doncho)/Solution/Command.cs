using System;
using System.Collections.Generic;

namespace OnlineMarket.Solution
{
    public enum CommandType
    {
        End,
        Add,
        FilterByPrice,
        FilterByType
    }

    public class Command
    {
        public string Params { get; set; }

        public static Dictionary<string, CommandType> stringToCommandType;

        static Command()
        {
            stringToCommandType = new Dictionary<string, CommandType>();
            stringToCommandType["add"] = CommandType.Add;
            stringToCommandType["end"] = CommandType.End;
            stringToCommandType["filter by type"] = CommandType.FilterByType;
            stringToCommandType["filter by price"] = CommandType.FilterByPrice;
        }

        public CommandType Type { get; set; }

        public static Command ParseCommand(string input)
        {
            foreach (var pair in stringToCommandType) 
            {
                if (input.StartsWith(pair.Key))
                {
                    return new Command()
                    {
                        Type = pair.Value,
                        Params = input.Substring(pair.Key.Length).Trim()
                    };
                }
            }
            return null;
        }
    }
}