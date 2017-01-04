using System.ComponentModel.DataAnnotations;

namespace CarSystem.Models
{
    public class Car
    {
        public int Id { get; set; }

        public int ManufacturerId { get; set; }

        [Required]
        public virtual Manufacturer Manufacturer { get; set; }

        [Required]
        [MaxLength(25)]
        public string Model { get; set; }

        
        public TransmitionType Transmitiontype { get; set; }

        public ushort Year { get; set; }

        public decimal Price { get; set; }

        public int DealerID { get; set; }

        public virtual Dealer Dealer { get; set; }
    }
}
