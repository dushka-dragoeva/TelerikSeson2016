using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

using _05.DataBindingHomework.Models.Cars;
using _05.DataBindingHomework.Data;

namespace _05.DataBindingHomework
{
    public partial class CarSearcher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                var cars = CarDb.GetProducers();
                this.CarProducer.DataSource = cars;
                this.CarProducer.DataBind();

                Producer producer = cars.FirstOrDefault(x => x.Name == this.CarProducer.Text);
                List<string> models = producer.Models;
                this.CarModel.DataSource = models;
                this.CarModel.DataBind();

                var extras = CarDb.GetExtras();
                this.CarExtras.DataSource = extras;
                this.CarExtras.DataBind();

                var engines = CarDb.GetEngineType();
                this.CarEngine.DataSource = engines;
                this.CarEngine.DataBind();
            }
        }

        protected void CarProducer_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cars = CarDb.GetProducers();
            Producer producer = cars.FirstOrDefault(x => x.Name == this.CarProducer.Text);
            List<string> models = producer.Models;
            this.CarModel.DataSource = models;
            this.CarModel.DataBind();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            this.SearchChoice.Visible = true;

            var chosenExtras = new List<string>();

            foreach (ListItem extra in this.CarExtras.Items)
            {
                if (extra.Selected)
                {
                    chosenExtras.Add(extra.Text);
                }
            }

            var selectedextras = chosenExtras.Count > 0 ? string.Join(", ", chosenExtras) : "Няма избрани екстри";

            this.SearchChoice.Text += Server.HtmlEncode($" {this.CarProducer.Text}, {this.CarModel.Text}, {this.CarEngine.SelectedItem.Text}, екстри: {selectedextras}");
        }
    }
}