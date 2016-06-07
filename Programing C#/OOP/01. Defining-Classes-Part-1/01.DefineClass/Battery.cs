namespace MobileDevice
{
    using System.Text;

    internal class Battery
    {
        private BatteryType model;
        private int? hoursIdle;
        private int? hoursTalk;

        public Battery(BatteryType model)
        {
            this.model = model;
            this.hoursIdle = null;
            this.hoursTalk = null;
        }

        public Battery(BatteryType model, int hoursIdle, int hoursTalk)
        {
            this.model = model;
            this.hoursIdle = hoursIdle;
            this.hoursTalk = hoursTalk;
        }

        public BatteryType Model
        {
            get
            {
                return this.model;
            }

            set
            {
                this.model = value;
            }
        }

        public int? HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }

            set
            {
                this.hoursIdle = value;
            }
        }

        public int? HourseTalk
        {
            get
            {
                return this.hoursTalk;
            }

            set
            {
                this.hoursTalk = value;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.Append(string.Format("Type - {0}; Hours Talk - {1}; Hours Idle - {2} ", this.Model, this.hoursTalk, this.hoursIdle));

            return output.ToString();
        }
    }
}
