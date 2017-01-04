using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.Console.JsonModels
{
    public class CarJsonModel
    {
        public ushort Year { get; set; }

        public int TransmissionType { get; set; }

        public string ManufacturerName { get; set; }

        public string Model { get; set; }

        public decimal Price{ get; set; }

        public DealerJsonModel Dealer { get; set; }
    }
}
