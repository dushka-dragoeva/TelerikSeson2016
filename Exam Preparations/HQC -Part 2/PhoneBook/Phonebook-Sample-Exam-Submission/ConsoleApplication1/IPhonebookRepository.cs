using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBookSystem
{
    public interface IPhonebookRepository
    {
        bool AddPhone(string name, IEnumerable<string> phoneNumbers);

        int ChangePhone(string oldPhoneNumber, string newPhoneNumber);

        PhoneBookContactOutput[] ListEntries(int startIndex, int count);
    }
}
