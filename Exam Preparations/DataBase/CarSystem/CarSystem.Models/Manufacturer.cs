using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.Models
{
    public class Manufacturer
    {
        private ICollection<Car> cars;

        public Manufacturer()
        {
            this.Cars = new HashSet<Car>();
        }

        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(10)]
        public string Name { get; set; }

        public virtual ICollection<Car> Cars
        {
            get { return this.cars; }

            set { this.cars = value; }
        }
    }
}
