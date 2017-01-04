using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.Models
{
    public class City
    {
        private ICollection<Dealer> dealars;

        public City()
        {
            this.Dealars = new HashSet<Dealer>();
        }

        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(10)]
        public string Name { get; set; }

        public virtual ICollection<Dealer> Dealars
        {
            get { return this.dealars; }

            set { this.dealars = value; }
        }
    }
}
