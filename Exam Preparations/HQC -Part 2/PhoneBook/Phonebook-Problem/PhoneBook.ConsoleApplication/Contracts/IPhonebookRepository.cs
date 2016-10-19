using PhoneBook.ConsoleApplication.Models;
using System.Collections.Generic;

namespace PhoneBook.ConsoleApplication.Contracts
{
    public interface IPhonebookRepository
    {
        bool AddPhone(string name, IEnumerable<string> phoneNumbers);

        int ChangePhone(string oldPhoneNumber, string newPhoneNumber);

        IEntry[] ListEntries(int startIndex, int count);
    }
}
