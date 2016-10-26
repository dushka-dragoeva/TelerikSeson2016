using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class Logger : ILogger
    {
        private static Logger instance;

        private static Object lockedObject = new Object();

        private Logger()
        {
        }

        public static Logger Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Logger();
                }

                return instance;
            }
        }
        public void Log(string log, IPrinter printer)
        {
            printer.Print($"{DateTime.Now}  {log}");
        }
    }
}
