namespace Timer
{
    using System;
    using System.Threading;

    public class Startup
    {
        public static void Main()
        {
            var date = DateTime.Now;
            Timer testTimer = new Timer(15, 2, delegate() { Console.WriteLine(" ticks"); });
            Thread currentThread = new Thread(new ThreadStart(testTimer.Run));
            currentThread.Start();
        }
    }
}
