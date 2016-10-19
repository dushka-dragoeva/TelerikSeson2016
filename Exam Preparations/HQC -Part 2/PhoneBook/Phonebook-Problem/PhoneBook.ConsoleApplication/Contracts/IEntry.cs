using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.ConsoleApplication.Contracts
{
    public interface IEntry
    {
        string Name { get; }

        ICollection<string> PhoneNumbers { get; }
    }
}
