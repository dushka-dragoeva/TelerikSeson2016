using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneBookSystem
{
    public class PhoneBookContactOutput : IComparable<PhoneBookContactOutput>
    {
        private string contactName;
        private string contactNameLowerCase;

        public string Name
        {
            get
            {
                return this.contactName;
            }
            set
            {
                this.contactName = value;
                this.contactNameLowerCase = value.ToLowerInvariant();
            }
        }

        public SortedSet<string> contactPhones;

        public override string ToString()
        {
            StringBuilder contactOutput = new StringBuilder();
            contactOutput.Clear();
            contactOutput.Append('[');
            contactOutput.Append(this.Name);
            contactOutput.Append(": ");

            foreach (var phone in this.contactPhones)
            {
                contactOutput.Append(phone);
                contactOutput.Append(", ");
            }

            contactOutput.Length = contactOutput.Length - 2;
            contactOutput.Append(']');

            return contactOutput.ToString();
        }

        public int CompareTo(PhoneBookContactOutput other)
        {
            return this.contactNameLowerCase.CompareTo(other.contactNameLowerCase);
        }
    }
}
