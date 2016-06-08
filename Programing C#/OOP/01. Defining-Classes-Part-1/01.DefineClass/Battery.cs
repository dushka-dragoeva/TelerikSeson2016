﻿namespace MobileDevice
{
    using System;
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
            : this(model)
        {
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
                if (this.hoursIdle <= 0)
                {
                    throw new ArgumentException("Houre idle {0}", GlobalConstants.NegativeNumber);
                }
                else
                {
                    this.hoursIdle = value;
                }
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
                if (this.hoursTalk <= 0)
                {
                    throw new ArgumentException("Houre talk {0}", GlobalConstants.NegativeNumber);
                }
                else
                {
                    this.hoursIdle = value;
                }
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.Append($"Type - {this.model}; ");

            if (this.HourseTalk == null)
            {
                output.Append(string.Format("Hours Talk - {0}; ", GlobalConstants.NoInformation));
            }
            else
            {
                output.Append($" Hours Talk - {this.hoursTalk};");
            }

            if (this.HoursIdle == null)
            {
                output.Append(string.Format("Hours Idle - {0}", GlobalConstants.NoInformation));
            }
            else
            {
                output.Append($" Hours Idle - {this.hoursIdle}");
            }

            return output.ToString();
        }
    }
}
