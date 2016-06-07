namespace MobileDevice
{
    using System;
    using System.Text;

    internal class Gsm
    {
        private string model;
        private string manufacture;
        private decimal price;
        private string owner;
        private Battery battery;
        private Display display;

        public Gsm(string model, string manufacture)
        {
            this.model = model;
            this.manufacture = manufacture;
            this.price = 0;
            this.owner = null;
            this.battery = null;
            this.display = null;
        }

        public Gsm(string model, string manufacture, decimal price, string owner)
            : this(model, manufacture)
        {
            this.price = price;
            this.owner = owner;
        }


        public Gsm(string model, string manufacture, decimal price, string owner, Battery baterry, Display display)
            : this(model, manufacture, price, owner)
        {
            this.battery = baterry;
            this.display = display;
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
                    throw new ArgumentNullException(nameof(value) + GlobalConstants.NullValue);
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
                    throw new ArgumentNullException(nameof(value) + GlobalConstants.NullValue);
                }
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.Append(string.Format("Model: {0}", this.model))
                .Append("/n")
                .Append(string.Format("Manufacture: {}", this.manufacture))
                .Append("/n");

            string value;
            if (this.price != 0)
            {
                value = this.price.ToString();
            }
            else
            {
                value = GlobalConstants.NoInformation;
            }

            output.Append(string.Format("Price: {0}", value))
                .Append("/n");

            if (!string.IsNullOrEmpty(this.owner))
            {
                value = this.owner;
            }
            else
            {
                value = GlobalConstants.NoInformation;
            }

            output.Append(string.Format("Owner: {0}", value))
               .Append("/n");

            if (this.battery != null)
            {
                value = this.battery.ToString();
            }
            else
            {
                value = GlobalConstants.NoInformation;
            }

            output.Append(string.Format("Battery: {0}", value))
               .Append("/n");




            return output.ToString();


        }
    }
}
