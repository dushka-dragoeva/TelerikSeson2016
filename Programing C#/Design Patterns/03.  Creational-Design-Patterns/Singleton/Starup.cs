using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class Starup
    {
        public static void Main()
        {
            var printer = new ConsolePrinter();
            var logger = Logger.Instance;
            logger.Log("The job is done", printer);
        }
    }
}
