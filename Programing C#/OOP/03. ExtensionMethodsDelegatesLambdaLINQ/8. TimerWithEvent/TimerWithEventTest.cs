namespace TimerWithEvent
{
    using System;

    public delegate void TimeElapsedEventHandler(object sender, TimeElapsedEventArgs e);

    public class TimerWithEventTest
    {
        public static void Run()
        {
            Timer newTimer = new Timer(1, 20);
            newTimer.TimeElapsed += Timer_TimeChanged;
            newTimer.Run();
        }

        public static void Timer_TimeChanged(object sender, TimeElapsedEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("08. Timer with event");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Time elapsed {0} seconds.", e.TicksCount);
        }
    }
}
