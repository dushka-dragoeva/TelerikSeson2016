using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PhoneBookSystem
{
    class PhoneBook
    {
        private const string Code = "+359";
        private static IPhonebookRepository phoneBookRepository = new PhonebookRepository(); 
        private static StringBuilder output = new StringBuilder();

        static void Main()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                if (input == null || input == string.Empty)
                {
                    throw new ArgumentException("Input cannot be empty or null !");
                }

                int indexOfLeftBracket = input.IndexOf('(');

                if (indexOfLeftBracket == -1)
                {
                    throw new ArgumentException("Missing bracket after command !");
                }

                string command = input.Substring(0, indexOfLeftBracket);

                if (!input.EndsWith(")"))
                {
                    Main();
                }

                string inputContactDetails = input.Substring(indexOfLeftBracket + 1, input.Length - indexOfLeftBracket - 2);

                string[] contactDetails = inputContactDetails.Split(',');

                for (int j = 0; j < contactDetails.Length; j++)
                {
                    contactDetails[j] = contactDetails[j].Trim();
                }

                switch (command)
                {
                    case "AddPhone":
                        CommandHandler("AddPhone", contactDetails);
                        break;
                    case "ChangePhone":
                        CommandHandler("ChangePhone", contactDetails);
                        break;
                    case "List":
                        CommandHandler("List", contactDetails);
                        break;
                    default:
                        throw new ArgumentException("Incorect command " + command);
                }

            }

            Console.Write(output);
        }

        private static void CommandHandler(string command, string[] contactDetails)
        {
            if (command == "AddPhone")
            {
                string contactName = contactDetails[0];
                var contactPhoneNumbers = contactDetails.Skip(1).ToList();

                for (int i = 0; i < contactPhoneNumbers.Count; i++)
                {
                    contactPhoneNumbers[i] = ParsePhoneNumber(contactPhoneNumbers[i]);
                }

                bool isPhoneAdded = phoneBookRepository.AddPhone(contactName, contactPhoneNumbers);

                if (isPhoneAdded)
                {
                    Print("Phone entry created.");
                }
                else
                {
                    Print("Phone entry merged");
                }
            }
            else if (command == "ChangePhone") 
            {
                Print(phoneBookRepository.ChangePhone(ParsePhoneNumber(contactDetails[0]), ParsePhoneNumber(contactDetails[1])) + " numbers changed");
            }
            else if (command == "List")
            { 
                try
                {
                    IEnumerable<PhoneBookContactOutput> entries = phoneBookRepository.ListEntries(int.Parse(contactDetails[0]), int.Parse(contactDetails[1]));

                    foreach (var entry in entries)
                    {
                        Print(entry.ToString());
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Print("Invalid range");
                }
            }
        }

        private static string ParsePhoneNumber(string phoneNumbers)
        {
            StringBuilder parsedPhoneNumber = new StringBuilder();

            for (int i = 0; i <= phoneNumbers.Length; i++)
            {
                parsedPhoneNumber.Clear();

                // Here wher a the Bottlenecks
                // A lot of repeted code and bad parsing of phone number with forech loop checking char by char phone number
                // Fixed by removing unnecessary code and foreach loop replaced by Regex.Replace(phoneNumbers, "[^.+.0-9]", "");

                string parsePhoneNumber = Regex.Replace(phoneNumbers, "[^.+.0-9]", "");
                parsedPhoneNumber.Append(parsePhoneNumber);

                if (parsedPhoneNumber.Length >= 2 && parsedPhoneNumber[0] == '0' && parsedPhoneNumber[1] == '0')
                {
                    parsedPhoneNumber.Remove(0, 1);
                    parsedPhoneNumber[0] = '+';
                }

                while (parsedPhoneNumber.Length > 0 && parsedPhoneNumber[0] == '0')
                {
                    parsedPhoneNumber.Remove(0, 1);
                }

                if (parsedPhoneNumber.Length > 0 && parsedPhoneNumber[0] != '+')
                {
                    parsedPhoneNumber.Insert(0, Code);
                }
            }

            return parsedPhoneNumber.ToString();
        }

        private static void Print(string text)
        {
            output.AppendLine(text);
        }
    }
}