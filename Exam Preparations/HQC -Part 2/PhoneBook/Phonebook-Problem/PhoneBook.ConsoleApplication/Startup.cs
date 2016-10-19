using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PhoneBook.ConsoleApplication.Contracts;
using PhoneBook.ConsoleApplication.Models;

namespace PhoneBook.ConsoleApplication
{
    internal class Startup
    {
        //public static void Main()
        //{
        //    IReader reader = new ConsoleReader();
        //    Engine phoneBook = new Engine(reader);
        //    Console.WriteLine(phoneBook.Run());
        //}

        private const string AddEntriesCommand = "AddPhone";
        private const string ChangeEntriesCommand = "ChangePhone";
        private const string ListEntiresCommand = "List";
        private const string End = "End";

         private static IPhonebookRepository data = new PhonebookRepository(); // this works!
        private static StringBuilder output = new StringBuilder();

        private static void Main()
        {
            while (true)
            {
                string command = Console.ReadLine();
                if (command == End || command == null)
                {
                    break;
                }

                Command parsedCommand = null;
                try
                {
                    parsedCommand = Command.Parse(command);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("error!");
                    Environment.Exit(0);
                }

                var comandProcesor = new CommandProcessor(parsedCommand);

                if (parsedCommand.Name.StartsWith(AddEntriesCommand) && (parsedCommand.Arguments.Length >= 2))
                {
                    Print(comandProcesor.ProceedAddCommand());
                }
                else if ((parsedCommand.Name == ChangeEntriesCommand) && (parsedCommand.Arguments.Length == 2))
                {
                    Print(comandProcesor.ProceedChangeCommand());
                }
                else if ((parsedCommand.Name == ListEntiresCommand) && (parsedCommand.Arguments.Length == 2))
                {
                    Print(comandProcesor.ProceedListCommand());
                }
                else
                {
                    throw new StackOverflowException();
                }
            }

            Console.Write(output);
        }

        private static void Print(string text)
        {
            output.AppendLine(text);
        }
    }
}

/*/internal class REP : IPhonebookRepository
//{
//    private OrderedSet<Entry> sortedEntries = new OrderedSet<Entry>();
//    private Dictionary<string, Entry> EntriesByName = new Dictionary<string, Entry>();
//    private MultiDictionary<string, Entry> multidict = new MultiDictionary<string, Entry>(false);

//    public bool AddPhone(string name, IEnumerable<string> nums)
//    {
//        string name2 = name.ToLowerInvariant();
//        Entry entry;

//        bool flag = !this.EntriesByName.TryGetValue(name2, out entry);

//        if (flag)
//        {
//            entry = new Entry();
//            entry.Name = name;
//            entry.PhoneNumbers = new SortedSet<string>();
//            this.EntriesByName.Add(name2, entry);
//            this.sortedEntries.Add(entry);
//        }

//        foreach (var num in nums)
//        {
//            this.multidict.Add(num, entry);
//        }

//        entry.PhoneNumbers.UnionWith(nums);
//        return flag;
//    }

//    public int ChangePhone(string oldent, string newent)
//    {
//        var found = this.multidict[oldent].ToList();

//        foreach (var entry in found)
//        {
//            entry.PhoneNumbers.Remove(oldent);
//            this.multidict.Remove(oldent, entry);

//            entry.PhoneNumbers.Add(newent);
//            this.multidict.Add(newent, entry);
//        }
//        return found.Count;
//    }

//    public Entry[] ListEntries(int first, int num)
//    {
//        if (first < 0 || first + num > this.EntriesByName.Count) { Console.WriteLine("Invalid start index or count."); return null; }
//        Entry[] list = new Entry[num];

//        for (int i = first; i <= first + num - 1; i++)
//        {
//            Entry entry = this.sortedEntries[i];
//            list[i - first] =

//                entry;
//        }
//        return list;
//    }
//}*/

