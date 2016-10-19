using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PhoneBook.ConsoleApplication.Contracts;

namespace PhoneBook.ConsoleApplication.Models
{
    class ConsoleReader : IReader
    {
        public string Read()
        {
           // var input = Console.ReadLine();
           // return input;
            return Console.ReadLine();
        }
    }
}
