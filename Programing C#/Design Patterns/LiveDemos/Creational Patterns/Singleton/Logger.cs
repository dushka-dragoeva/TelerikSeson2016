using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ILogger
{
    void Log(string log);
}

namespace Singleton
{
    public class Logger : ILogger
    {

        


        private static Logger instance;

        private static Object lockedObject = new Object();

        private Logger()
        {
        }

        // public getter
        public static Logger Instance
        {
            get
            {
                if (Instance == null)
                {
                    lock (lockedObject)
                    {
                        if (instance == null)
                        {
                            instance = new Logger();  // Lazy inicialization
                        }
                    }
                }

                return instance;
            }
        }
        public void Log(string log)
        {
            Console.WriteLine($"{DateTime.Now}  {log}");
        }
    }

    class LoggerProvider
    {
        //public static ILogger GetLogger()
        //{
        // logic for creation
        //}
    }
}
