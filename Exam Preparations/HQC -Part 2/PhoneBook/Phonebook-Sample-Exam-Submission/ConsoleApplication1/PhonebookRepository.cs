using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBookSystem
{
    public class PhonebookRepository : IPhonebookRepository
    {
        public List<PhoneBookContactOutput> PhoneBookEntries = new List<PhoneBookContactOutput>();

        /// <summary>
        /// Gets the count of PhoneBook entries.
        /// </summary>
        /// <value>Return PhoneBook entries</value>
        public int Count
        {
            get
            {
                return PhoneBookEntries.Count;
            }
        }

        /// <summary>
        /// Adds contact to Phone Book.
        /// Method checks if there is allready existing contact in PhoneBookEntries.
        /// If contact name exists only its phone numbers are added.
        /// </summary>
        /// <param name="contactName">The contact name</param>
        /// <param name="contactNumbers">The numbers of contact</param>
        /// <returns>Returns bool. True is returned if contact is added to Phone Book</returns>
        public bool AddPhone(string contactName, IEnumerable<string> contactNumbers)
        {
            var old = from e in this.PhoneBookEntries where e.Name.ToLowerInvariant() == contactName.ToLowerInvariant() select e;
            bool isPhoneAdded = false;

            if (old.Count() == 0)
            {
                PhoneBookContactOutput obj = new PhoneBookContactOutput();
                obj.Name = contactName;
                obj.contactPhones = new SortedSet<string>();

                foreach (var phone in contactNumbers)
                {
                    obj.contactPhones.Add(phone);
                }

                this.PhoneBookEntries.Add(obj);
                isPhoneAdded = true;
            }
            else if (old.Count() == 1)
            {
                PhoneBookContactOutput obj2 = old.First();

                foreach (var phone in contactNumbers)
                {
                    obj2.contactPhones.Add(phone);
                }

                isPhoneAdded = false;
            }
            else
            {
                throw new DuplicateWaitObjectException("Duplicated name in the phonebook found: " + contactName);
            }

            return isPhoneAdded;
        }

        /// <summary>
        /// Changes the phone number in Phone Book.
        /// Replace all old PhoneNumbers with new Phone Numbers in Phone Book.
        /// </summary>
        /// <param name="oldPhoneNumber">The old phone number.</param>
        /// <param name="newPhoneNumber">The new phone number.</param>
        /// <returns>Retrusn count of replaced phone numbers.</returns>
        public int ChangePhone(string oldPhoneNumber, string newPhoneNumber)
        {
            var list = from e in this.PhoneBookEntries where e.contactPhones.Contains(oldPhoneNumber) select e;
            int numbersChanged = 0;

            foreach (var entry in list)
            {
                entry.contactPhones.Remove(oldPhoneNumber);
                entry.contactPhones.Add(newPhoneNumber);
                numbersChanged++;
            }

            return numbersChanged;
        }

        /// <summary>
        /// Lists the entries in Phone Book in given range.
        /// If out of range exception it throwed.
        /// </summary>
        /// <param name="startRange">The start range.</param>
        /// <param name="endRange">The end range.</param>
        /// <returns>Returns orderd list of Phone Book Entries</returns>
        public PhoneBookContactOutput[] ListEntries(int startRange, int endRange)
        {
            if (startRange < 0 || startRange + endRange > this.PhoneBookEntries.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid start index or count.");
            }

            this.PhoneBookEntries.Sort();
            PhoneBookContactOutput[] ent = new PhoneBookContactOutput[endRange];

            for (int i = startRange; i <= startRange + endRange - 1; i++)
            {
                PhoneBookContactOutput entry = this.PhoneBookEntries[i];
                ent[i - startRange] = entry;
            }

            return ent;
        }
    }
}