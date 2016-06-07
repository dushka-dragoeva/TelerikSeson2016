/*Define a class that holds information about a mobile phone device: model, manufacturer, price,
owner, battery characteristics (model, hours idle and hours talk) and display characteristics 
(size and number of colors).
Define 3 separate classes (class GSM holding instances of the classes Battery and Display).*/

namespace MobileDevice
{
    using System;
    using System.Text;

    internal class Gsm
    {
        private const string NoInformation = "No information avalable.";
        private const string NullValue = " cannot be null";

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

        public Gsm(string model, string manufacture, decimal price, string owner, Battery baterry, Display display)
            : this(model, manufacture)
        {
            this.price = price;
            this.owner = owner;
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
                    throw new ArgumentNullException(nameof(value) + NullValue);
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
                    throw new ArgumentNullException(nameof(value) + NullValue);
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
                value = NoInformation;
            }

            output.Append(string.Format("Price: {0}", value))
                .Append("/n");

            if (!string.IsNullOrEmpty(this.owner))
            {
                value = this.owner;
            }
            else
            {
                value = NoInformation;
            }

            output.Append(string.Format("Owner: {0}", value))
               .Append("/n");

            if (this.battery != null)
            {
                value = this.battery.ToString();
            }
            else
            {
                value = NoInformation;
            }

            output.Append(string.Format("Battery: {0}", value))
               .Append("/n");




            return output.ToString();


        }
    }
}
