using System;

namespace PersonCreator
{
    public class Startup
    {
        public static void Main()
        {
            var male = new Person(30);
            Console.WriteLine(male);
            var female = new Person(25);
            Console.WriteLine(female);
        }
    }
}
