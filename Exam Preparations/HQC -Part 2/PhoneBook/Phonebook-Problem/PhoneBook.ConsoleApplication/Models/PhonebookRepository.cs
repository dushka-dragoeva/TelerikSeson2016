using System;
using System.Collections.Generic;
using System.Linq;

using PhoneBook.ConsoleApplication.Contracts;

namespace PhoneBook.ConsoleApplication.Models
{
    public class PhonebookRepository : IPhonebookRepository
    {
        public PhonebookRepository()
        {
            this.Entries = new List<IEntry>();
        }

        public List<IEntry> Entries { get; set; }

        public bool AddPhone(string name, IEnumerable<string> phoneNumbers)
        {
            bool isNewEntry;
            IEntry entryToAdd;

            var existingName = from e in this.Entries
                               where e.Name.ToLowerInvariant() == name.ToLowerInvariant()
                               select e;

            if (existingName.Count() == 0)
            {
                entryToAdd = new Entry(name, new SortedSet<string>());

                foreach (var num in phoneNumbers)
                {
                    entryToAdd.PhoneNumbers.Add(num);
                }

                this.Entries.Add(entryToAdd);

                isNewEntry = true;
            }
            else if (existingName.Count() == 1)
            {
                entryToAdd = existingName.First();
                foreach (var num in phoneNumbers)
                {
                    entryToAdd.PhoneNumbers.Add(num);
                }

                isNewEntry = false;
            }
            else
            {
                throw new ArgumentException();
            }

            return isNewEntry;
        }

        public int ChangePhone(string oldEntry, string newEntry)
        {
            var list = from e in this.Entries
                       where e.PhoneNumbers.Contains(oldEntry)
                       select e;

            int nums = 0;
            foreach (var entry in list)
            {
                entry.PhoneNumbers.Remove(oldEntry);
                entry.PhoneNumbers.Add(newEntry);
                nums++;
            }

            return nums;
        }

        public IEntry[] ListEntries(int startIndex, int count)
        {
            if (startIndex < 0 || startIndex + count > this.Entries.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid start index or count.");
            }

            this.Entries.Sort();

            IEntry[] entriesToBeListed = new IEntry[count];

            for (int i = startIndex; i <= startIndex + count - 1; i++)
            {
                entriesToBeListed[i - startIndex] = this.Entries[i];
            }

            return entriesToBeListed;
        }
    }
}
