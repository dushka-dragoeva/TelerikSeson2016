namespace TimerWithDelegate
{
    using System;
    using System.Threading;

    public delegate void TimerMethod();

    public class Timer
    {
        private int miliSeconds;
        private byte ticks;
        private TimerMethod currentMethod;

        public Timer(byte ticks, int seconds, TimerMethod currentMethod)
        {
            this.Ticks = ticks;
            this.Interval = seconds;
            this.Method = currentMethod;
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

        public TimerMethod Method
        {
            get
            {
                return this.currentMethod;
            }

            set
            {
                this.currentMethod = value;
            }
        }

        public void Run()
        {
            while (this.ticks > 0)
            {
                Thread.Sleep((int)this.miliSeconds);
                --this.ticks;
                this.currentMethod();
            }
        }
    }
}
