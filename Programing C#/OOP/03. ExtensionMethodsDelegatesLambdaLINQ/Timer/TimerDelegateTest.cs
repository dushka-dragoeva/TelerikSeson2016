namespace TimerWithDelegate
{
    using System;

    public class TimerDelegateTest
    {
        public static void Run()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("07. Timer with delegate");

            Console.ForegroundColor = ConsoleColor.White;
            TimerMethod testDelegate = TestMethod;
            testDelegate += AnotherTestMetod;
            testDelegate += delegate
            {
                Console.WriteLine("I am Anonimus Method");
            };
            Timer testTimer = new Timer(5, 2, testDelegate);
            testTimer.Run();
        }

        private static void TestMethod()
        {
            Console.WriteLine(DateTime.Now);
        }

        private static void AnotherTestMetod()
        {
            Console.WriteLine("After 2 seconds");
        }
    }
}
