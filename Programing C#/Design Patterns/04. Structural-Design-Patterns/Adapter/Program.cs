using System;

namespace Adapter
{
    public class MainApp
    {
        public static void Main()
        {
            // Create adapter and place a request
            Target target = new Adapter();
            target.Request();

            // Wait for user
            Console.ReadKey();
        }
    }
}
