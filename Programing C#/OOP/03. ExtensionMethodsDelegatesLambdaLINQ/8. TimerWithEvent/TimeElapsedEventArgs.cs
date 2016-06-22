namespace TimerWithEvent
{
    using System;

    public class TimeElapsedEventArgs : EventArgs
    {
        private int ticksCount;

        public TimeElapsedEventArgs(int ticksCount)
        {
            this.TicksCount = ticksCount;
        }

        public int TicksCount
        {
            get
            {
                return this.ticksCount;
            }

            private set
            {
                this.ticksCount = value;
            }
        }
    }
}
