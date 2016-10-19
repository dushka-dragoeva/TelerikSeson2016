using System;
using System.Collections.Generic;
using System.Text;
using PhoneBook.ConsoleApplication.Contracts;

namespace PhoneBook.ConsoleApplication.Models
{
    internal class Entry : IComparable<Entry>, IEntry
    {
        private string name;

        private ICollection<string> phoneNumbers;

        public Entry(string name, ICollection<string> phoneNumbers)
        {
            this.Name = name;
            this.PhoneNumbers = phoneNumbers;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                this.name = value;
            }
        }

        public ICollection<string> PhoneNumbers
        {
            get
            {
                return this.phoneNumbers;
            }

            private set
            {
                this.phoneNumbers = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Clear();
            sb.Append('[');
            sb.Append(this.Name);
            sb.Append(": ");
            sb.Append(string.Join(", ", this.PhoneNumbers));
            sb.Append(']');

            return sb.ToString();
        }

        public int CompareTo(Entry otherEntry)
        {
            return this.Name.CompareTo(otherEntry.Name);
        }
    }
}
