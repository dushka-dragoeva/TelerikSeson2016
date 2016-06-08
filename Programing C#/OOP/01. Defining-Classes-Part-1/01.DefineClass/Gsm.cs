namespace MobileDevice
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class Gsm
    {
        public static readonly Gsm IPhone4S = new Gsm(
            "iPhone 4S",
            "Apple",
            500,
            "Rene",
            new Battery(BatteryType.LiIon, 48, 24),
            new Display(4.5, 16000000));

        private string model;
        private string manufacture;
        private decimal? price;
        private string owner;
        private Battery battery;
        private Display display;
        private List<Call> callHistory = new List<Call>();

        public Gsm(string model, string manufacture)
        {
            this.Model = model;
            this.Manufacture = manufacture;
            this.Price = null;
            this.Owner = null;
            this.Battery = null;
            this.Display = null;
        }

        public Gsm(string model, string manufacture, decimal? price)
            : this(model, manufacture)
        {
            this.Price = price;
        }

        public Gsm(string model, string manufacture, decimal? price, string owner)
           : this(model, manufacture, price)
        {
            this.Owner = owner;
        }

        public Gsm(string model, string manufacture, decimal? price, string owner, Battery baterry)
            : this(model, manufacture, price, owner)
        {
            this.Battery = baterry;
        }

        public Gsm(string model, string manufacture, decimal? price, string owner, Battery baterry, Display display)
           : this(model, manufacture, price, owner, baterry)
        {
            this.Display = display;
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                if (!string.IsNullOrEmpty(value) || !string.IsNullOrWhiteSpace(value))
                {
                    this.model = value;
                }
                else
                {
                    throw new ArgumentNullException("Model {0}", GlobalConstants.NullValue);
                }
            }
        }

        public string Manufacture
        {
            get
            {
                return this.model;
            }

            set
            {
                if (!string.IsNullOrEmpty(value) || !string.IsNullOrWhiteSpace(value))
                {
                    this.manufacture = value;
                }
                else
                {
                    throw new ArgumentNullException("GSM manugacturer {0}", GlobalConstants.NullValue);
                }
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }

            set
            {
                this.owner = value;
            }
        }

        public decimal? Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (this.Price < 0)
                {
                    throw new ArgumentException("Price {0}", GlobalConstants.NegativeNumber);
                }
                else
                {
                    this.price = value;
                }
            }
        }

        public Display Display
        {
            get
            {
                return this.display;
            }

            set
            {
                this.display = value;
            }
        }

        public Battery Battery
        {
            get
            {
                return this.battery;
            }

            set
            {
                this.battery = value;
            }
        }

        public List<Call> CallHistory
        {
            get
            {
                return this.callHistory;
            }
        }

        public decimal CalculateTotalCallPrice(decimal pricePerMinute)
        {
            var totalSeconds = 0;

            for (int i = 0; i < this.callHistory.Count; i++)
            {
                totalSeconds += this.callHistory[i].DurationInSeconds;
            }

            decimal price = totalSeconds * (pricePerMinute / 60);
            //// decimal price = Math.Ceiling(totalSeconds / 60.0m) * pricePerMinute;

            return price;
        }

        public string CallHystoryInfo()
        {
            var callHistoryInfo = new StringBuilder();

            if (this.callHistory.Count == 0)
            {
                return "Call history is empty!";
            }

            callHistoryInfo.Append("Date\t\tTime\t\tDailed number\tDuration seconds\n");

            for (int i = 0; i < this.callHistory.Count; i++)
            {
                callHistoryInfo.Append(this.callHistory[i].ToString());
                callHistoryInfo.Append("\n");
            }

            return callHistoryInfo.ToString();
        }

        public void DisplayInfo()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.Append(string.Format("Model:\t\t {0}", this.model))
                .Append("\n")
                .Append(string.Format("Manufacture:\t {0}", this.manufacture))
                .Append("\n");

            string value;

            if (this.price >= 0)
            {
                value = string.Format("{0:f2} BGN", this.price);
            }
            else
            {
                value = GlobalConstants.NoInformation;
            }

            output.Append(string.Format("Price:\t\t {0}", value))
                .Append("\n");

            if (!string.IsNullOrEmpty(this.owner))
            {
                value = this.owner;
            }
            else
            {
                value = GlobalConstants.NoInformation;
            }

            output.Append(string.Format("Owner:\t\t {0}", value))
               .Append("\n");

            if (this.battery != null)
            {
                value = this.battery.ToString();
            }
            else
            {
                value = GlobalConstants.NoInformation;
            }

            output.Append(string.Format("Battery:\t {0}", value))
            .Append("\n");

            if (this.display != null)
            {
                value = this.display.ToString();
            }
            else
            {
                value = GlobalConstants.NoInformation;
            }

            output.Append(string.Format("Display:\t {0}", value))
            .Append("\n");

            return output.ToString();
        }

        public void AddCall(Call currentCall)
        {
            this.callHistory.Add(currentCall);
        }

        public void DeleteCall(Call currentCall)
        {
            this.callHistory.Remove(currentCall);
        }

        public void ClearHistory()
        {
            this.callHistory.Clear();
        }
    }
}
