namespace TimerWithEvent
{
    using System;
    using System.Threading;

    public class Timer
    {
        private int delay;
        private int clicks;

        public Timer(int delay, int clicks)
        {
            this.Delay = delay;
            this.Clicks = clicks;
        }

        public event TimeElapsedEventHandler TimeElapsed;

        public int Delay
        {
            get
            {
                return this.delay;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Delay must be non-negative number.");
                }

                this.delay = value;
            }
        }

        public int Clicks
        {
            get
            {
                return this.clicks;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Clicks must be non-negative number.");
                }

                this.clicks = value;
            }
        }

        public void Run()
        {
            int tick = this.Clicks;

            Thread newThread = new Thread(() =>
            {
                Thread.Sleep(this.Delay * 1000);
                tick--;
                OnTimeElapsed(tick);
            });
            newThread.Start();
        }

        protected internal void OnTimeElapsed(int tick)
        {
            if (this.TimeElapsed != null)
            {
                this.TimeElapsed(this, new TimeElapsedEventArgs(tick));
            }
        }
    }
}
