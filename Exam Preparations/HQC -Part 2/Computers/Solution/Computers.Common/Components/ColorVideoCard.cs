using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computers.Common.Components
{
    public class ColorVideoCard
    {
        public void Draw(string data)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(data);
            Console.ResetColor();
        }
    }
}
