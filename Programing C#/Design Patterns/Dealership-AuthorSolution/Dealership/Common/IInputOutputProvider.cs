using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Common
{
    public interface IInputOutputProvider
    {
        void WriteLine(string message);

        void Write(string message);

        string ReadLine();
    }
}
