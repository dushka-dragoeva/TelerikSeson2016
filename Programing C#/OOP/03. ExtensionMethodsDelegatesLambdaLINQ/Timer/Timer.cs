namespace Timer
{
    using System;
    using System.Threading;

    public delegate void TimerEvent();

    public class Timer
    {
        private int miliSeconds;
        private byte ticks;
        private TimerEvent currentEvent;

        public Timer(byte ticks, int seconds, TimerEvent currentEvent)
        {
            this.Ticks = ticks;
            this.Interval = seconds;
            this.Event = currentEvent;
        }

        public byte Ticks
        {
            get
            {
                return this.ticks;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }

                this.ticks = value;
            }
        }

        public int Interval
        {
            get
            {
                return this.miliSeconds;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }

                this.miliSeconds = value * 1000;
            }
        }

        public TimerEvent Event
        {
            get
            {
                return this.currentEvent;
            }

            set
            {
                this.currentEvent = value;
            }
        }

        public void Run()
        {
            while (this.ticks > 0)
            {
                Thread.Sleep((int)this.miliSeconds);
                Console.Write(this.Ticks);
                --this.ticks;
                this.currentEvent();
            }
        }
    }
}
